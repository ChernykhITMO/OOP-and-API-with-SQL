using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;
using Npgsql;

namespace LaboratoryWork5.Adapters;

public class AccountRepository : IAccountRepository
{
    private readonly string _connectionString;

    public AccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<AccountDTO?> GetAccountByIdAsync(long id)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        await using var command = new NpgsqlCommand($"SELECT * FROM accounts WHERE id = @id", connection);

        command.Parameters.AddWithValue("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new AccountDTO
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                Pin = reader.GetString(reader.GetOrdinal("pin")),
                Balance = reader.GetDecimal(reader.GetOrdinal("balance")),
            };
        }

        return null;
    }

    public async Task AddAccountAsync(AccountDTO account)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        await using var command =
            new NpgsqlCommand(
                "INSERT INTO accounts (Id, Pin, Balance, Date) VALUES (@Id, @Pin, @Balance, @Date)",
                connection);

        command.Parameters.AddWithValue("@Id", account.Id);
        if (account.Pin != null) command.Parameters.AddWithValue("@Pin", account.Pin);
        command.Parameters.AddWithValue("@Balance", account.Balance);
        command.Parameters.AddWithValue("@Date", DateTime.Now);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAccountBalanceAsync(AccountDTO account, TransactionDTO transaction)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using NpgsqlTransaction transactionScope = await connection.BeginTransactionAsync();

        var command = new NpgsqlCommand($"UPDATE accounts SET balance = @Balance WHERE id = @Id", connection);
        command.Parameters.AddWithValue("@Id", account.Id);
        command.Parameters.AddWithValue("@Balance", account.Balance);

        await command.ExecuteNonQueryAsync();

        var insertCommand =
            new NpgsqlCommand(
                "INSERT INTO transactions (account_id, amount, type, date) VALUES (@AccountId, @Amount, @Type, @Date)",
                connection);
        insertCommand.Parameters.AddWithValue("@AccountId", account.Id);
        insertCommand.Parameters.AddWithValue("@Amount", transaction.Amount);
        if (transaction.Type != null) insertCommand.Parameters.AddWithValue("@Type", transaction.Type);
        insertCommand.Parameters.AddWithValue("@Date", transaction.Date);

        await insertCommand.ExecuteNonQueryAsync();
        await transactionScope.CommitAsync();
    }

    public async Task<List<TransactionDTO>> GetTransactionsAsync(long accountId)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        var transactions = new List<TransactionDTO>();

        var command = new NpgsqlCommand("SELECT * FROM transactions WHERE account_id = @id", connection);
        command.Parameters.AddWithValue("@id", accountId);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var transaction = new TransactionDTO
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                AccountId = reader.GetInt64(reader.GetOrdinal("account_id")),
                Amount = reader.GetDecimal(reader.GetOrdinal("amount")),
                Type = reader.GetString(reader.GetOrdinal("type")),
                Date = reader.GetDateTime(reader.GetOrdinal("date")),
            };

            transactions.Add(transaction);
        }

        return transactions;
    }
}
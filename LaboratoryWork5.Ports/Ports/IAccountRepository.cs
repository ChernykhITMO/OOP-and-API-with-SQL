using LaboratoryWork5.Ports.DTO;

namespace LaboratoryWork5.Ports.Ports;

public interface IAccountRepository
{
    Task<AccountDTO?> GetAccountByIdAsync(long id);

    Task AddAccountAsync(AccountDTO account);

    Task UpdateAccountBalanceAsync(AccountDTO account, TransactionDTO transaction);

    Task<List<TransactionDTO>> GetTransactionsAsync(long accountId);
}
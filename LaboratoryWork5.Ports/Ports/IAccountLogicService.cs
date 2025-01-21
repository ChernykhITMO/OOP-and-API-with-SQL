using LaboratoryWork5.Ports.DTO;

namespace LaboratoryWork5.Ports.Ports;

public interface IAccountLogicService
{
    Task<IResult<AccountDTO>> GetAccountAsync(long id, string pin);

    Task<IResult<AccountDTO>> DepositAsync(long accountId, string pin, decimal amount);

    Task<IResult<AccountDTO>> WithdrawAsync(long accountId, string pin, decimal amount);

    Task<IResult<AccountDTO>> CreateAccountAsync(long id, string pin);

    Task<IResult<List<TransactionDTO>>> GetTransactionsAsync(long accountId);

    Task<IResult<List<TransactionDTO>>> GetTransactionsAsync(long accountId, string pin);
}
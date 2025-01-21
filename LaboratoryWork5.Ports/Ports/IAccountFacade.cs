using LaboratoryWork5.Ports.DTO;

namespace LaboratoryWork5.Ports.Ports;

public interface IAccountFacade
{
    Task<IResult<AccountDTO>> GetAccountAsync(long id, string pin);

    Task<IResult<AccountDTO>> CreateAccountAsync(long id, string pin);

    Task<IResult<AccountDTO>> DepositAccountAsync(long id, string pin, decimal amount);

    Task<IResult<AccountDTO>> WithdrawAccountAsync(long id, string pin, decimal amount);

    Task<IResult<List<TransactionDTO>>> TakeTransactionAsync(long accountId);

    Task<IResult<List<TransactionDTO>>> TakeTransactionAsync(long accountId, string pin);
}

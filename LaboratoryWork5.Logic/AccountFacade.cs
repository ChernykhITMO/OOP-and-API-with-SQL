using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;

namespace Logic;

public class AccountFacade : IAccountFacade
{
    private readonly IAccountLogicService _logicService;

    public AccountFacade(IAccountLogicService logicService)
    {
        _logicService = logicService ?? throw new ArgumentNullException(nameof(logicService));
    }

    public async Task<IResult<AccountDTO>> GetAccountAsync(long id, string pin)
    {
        return await _logicService.GetAccountAsync(id, pin);
    }

    public async Task<IResult<AccountDTO>> CreateAccountAsync(long id, string pin)
    {
        return await _logicService.CreateAccountAsync(id, pin);
    }

    public async Task<IResult<AccountDTO>> DepositAccountAsync(long id, string pin, decimal amount)
    {
        return await _logicService.DepositAsync(id, pin, amount);
    }

    public async Task<IResult<AccountDTO>> WithdrawAccountAsync(long id, string pin, decimal amount)
    {
        return await _logicService.WithdrawAsync(id, pin, amount);
    }

    public async Task<IResult<List<TransactionDTO>>> TakeTransactionAsync(long accountId)
    {
        return await _logicService.GetTransactionsAsync(accountId);
    }

    public async Task<IResult<List<TransactionDTO>>> TakeTransactionAsync(long accountId, string pin)
    {
        return await _logicService.GetTransactionsAsync(accountId, pin);
    }
}

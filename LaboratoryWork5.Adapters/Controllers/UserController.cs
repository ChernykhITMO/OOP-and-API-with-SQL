using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoryWork5.Adapters.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IAccountFacade _accountFacade;

    public UserController(IAccountFacade accountFacade)
    {
        _accountFacade = accountFacade ?? throw new ArgumentNullException(nameof(accountFacade));
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateAccountAsync(long id, string pin)
    {
        IResult<AccountDTO> result = await _accountFacade.CreateAccountAsync(id, pin);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok($"Account created successfully with ID: {result.Value?.Id}");
    }

    [HttpGet("balance")]
    public async Task<ActionResult> GetBalanceAsync(long id, string pin)
    {
        IResult<AccountDTO> result = await _accountFacade.GetAccountAsync(id, pin);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok($"Balance: {result.Value?.Balance}");
    }

    [HttpPost("deposit")]
    public async Task<ActionResult> DepositAsync(long id, string pin, decimal amount)
    {
        IResult<AccountDTO> result = await _accountFacade.DepositAccountAsync(id, pin, amount);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok($"Deposit successful. New balance: {result.Value?.Balance}");
    }

    [HttpPost("withdraw")]
    public async Task<ActionResult> WithdrawAsync(long id, string pin, decimal amount)
    {
        IResult<AccountDTO> result = await _accountFacade.WithdrawAccountAsync(id, pin, amount);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok($"Withdrawal successful. New balance: {result.Value?.Balance}");
    }

    [HttpGet("transactions")]
    public async Task<ActionResult> GetTransactionsAsync(long id, string pin)
    {
        IResult<AccountDTO> result = await _accountFacade.GetAccountAsync(id, pin);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        IResult<List<TransactionDTO>> transactionsResult = await _accountFacade.TakeTransactionAsync(id, pin);
        if (!transactionsResult.IsSuccess)
        {
            return BadRequest(transactionsResult.ErrorMessage);
        }

        return Ok(transactionsResult.Value);
    }
}

using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoryWork5.Adapters.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private const string _adminPassword = "admin";
    private readonly IAccountFacade _accountFacade;

    public AdminController(IAccountFacade accountFacade)
    {
        _accountFacade = accountFacade ?? throw new ArgumentNullException(nameof(accountFacade));
    }

    [HttpGet("transactions")]
    public async Task<ActionResult> GetAccountTransactionsAsync(long accountId, string password)
    {
        if (password != _adminPassword)
        {
            return BadRequest("Passwords do not match");
        }

        IResult<List<TransactionDTO>> result = await _accountFacade.TakeTransactionAsync(accountId);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(result.Value);
    }
}

using LaboratoryWork5.Adapters.Controllers;
using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class WithdrawFailTest
{
    [Fact]
    public async Task Withdraw_Failure_ReturnsBadRequest()
    {
        long accountId = 1;
        string validPin = "1234";
        decimal withdrawAmount = 100;

        var withdrawResult = new Result<AccountDTO>(false, null, "Insufficient funds.");

        var accountFacadeMock = new Mock<IAccountFacade>();
        accountFacadeMock
            .Setup(facade => facade.WithdrawAccountAsync(accountId, validPin, withdrawAmount))
            .ReturnsAsync(withdrawResult);

        var controller = new UserController(accountFacadeMock.Object);

        ActionResult result = await controller.WithdrawAsync(accountId, validPin, withdrawAmount);

        BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Insufficient funds.", badRequestResult.Value);

        accountFacadeMock.Verify(facade => facade.WithdrawAccountAsync(accountId, validPin, withdrawAmount), Times.Once);
    }
}
using LaboratoryWork5.Adapters.Controllers;
using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class WithdrawSuccessTest
{
    [Fact]
    public async Task Withdraw_Success_ReturnsOk()
    {
        long accountId = 1;
        string validPin = "1234";
        decimal initialBalance = 150;
        decimal withdrawAmount = 100;
        decimal expectedBalance = initialBalance - withdrawAmount;

        var updatedAccountDto = new AccountDTO
        {
            Id = accountId,
            Pin = validPin,
            Balance = expectedBalance,
        };

        var withdrawResult = new Result<AccountDTO>(true, updatedAccountDto, null);

        var accountFacadeMock = new Mock<IAccountFacade>();
        accountFacadeMock
            .Setup(facade => facade.WithdrawAccountAsync(accountId, validPin, withdrawAmount))
            .ReturnsAsync(withdrawResult);

        var controller = new UserController(accountFacadeMock.Object);

        ActionResult result = await controller.WithdrawAsync(accountId, validPin, withdrawAmount);

        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal($"Withdrawal successful. New balance: {expectedBalance}", okResult.Value);

        accountFacadeMock.Verify(facade => facade.WithdrawAccountAsync(accountId, validPin, withdrawAmount), Times.Once);
    }
}
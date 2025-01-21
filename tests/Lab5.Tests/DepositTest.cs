using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;
using Logic;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class DepositTest
{
    [Fact]
    public async Task Deposit_Success_ReturnsUpdatedAccount()
    {
        long accountId = 1;
        string validPin = "1234";
        decimal initialBalance = 200;
        decimal depositAmount = 300;
        decimal expectedBalance = initialBalance + depositAmount;

        var accountDto = new AccountDTO
        {
            Id = accountId,
            Pin = validPin,
            Balance = initialBalance,
        };

        var updatedAccountDto = new AccountDTO
        {
            Id = accountId,
            Pin = validPin,
            Balance = expectedBalance,
        };

        var mockRepo = new Mock<IAccountRepository>();

        mockRepo.Setup(repo => repo.GetAccountByIdAsync(accountId))
            .ReturnsAsync(accountDto);

        mockRepo.Setup(repo => repo.UpdateAccountBalanceAsync(
                It.IsAny<AccountDTO>(), It.IsAny<TransactionDTO>()))
            .Returns(Task.CompletedTask);

        var validator = new OperationValidator();

        var service = new AccountLogicService(mockRepo.Object, validator);

        IResult<AccountDTO> result = await service.DepositAsync(accountId, validPin, depositAmount);

        Assert.True(result.IsSuccess);
        if (result.Value != null) Assert.Equal(expectedBalance, result.Value.Balance);
        Assert.Null(result.ErrorMessage);

        mockRepo.Verify(
            repo => repo.UpdateAccountBalanceAsync(
                It.Is<AccountDTO>(a => a.Balance == expectedBalance),
                It.IsAny<TransactionDTO>()),
            Times.Once);
    }
}


using LaboratoryWork5.Ports.DTO;
using LaboratoryWork5.Ports.Ports;

namespace Logic;

public class AccountLogicService : IAccountLogicService
{
    private readonly IAccountRepository _accountRepository;
    private readonly OperationValidator _validator;

    public AccountLogicService(IAccountRepository accountRepository, OperationValidator validator)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<IResult<AccountDTO>> GetAccountAsync(long id, string pin)
    {
        Result<bool> pinValidation = _validator.ValidatePin(pin);
        if (!pinValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, pinValidation.ErrorMessage);
        }

        AccountDTO? accountDto = await _accountRepository.GetAccountByIdAsync(id);
        Result<bool> accountValidation = _validator.ValidateAccountExistence(accountDto);
        if (!accountValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, accountValidation.ErrorMessage);
        }

        return new Result<AccountDTO>(true, accountDto);
    }

    public async Task<IResult<AccountDTO>> DepositAsync(long accountId, string pin, decimal amount)
    {
        AccountDTO? accountDto = await _accountRepository.GetAccountByIdAsync(accountId);

        Result<bool> accountValidation = _validator.ValidateAccountExistence(accountDto);
        if (!accountValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, accountValidation.ErrorMessage);
        }

        Result<bool> pinValidation = _validator.ValidatePin(pin);
        if (!pinValidation.IsSuccess || pin != accountDto?.Pin)
        {
            return new Result<AccountDTO>(false, null, "Invalid PIN.");
        }

        Result<bool> amountValidation = _validator.ValidateAmount(amount);
        if (!amountValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, amountValidation.ErrorMessage);
        }

        accountDto.Balance += amount;

        var transaction = new TransactionDTO
        {
            AccountId = accountId,
            Amount = amount,
            Type = "Deposit",
            Date = DateTime.UtcNow,
        };

        await _accountRepository.UpdateAccountBalanceAsync(accountDto, transaction);

        return new Result<AccountDTO>(true, accountDto);
    }

    public async Task<IResult<AccountDTO>> WithdrawAsync(long accountId, string pin, decimal amount)
    {
        AccountDTO? accountDto = await _accountRepository.GetAccountByIdAsync(accountId);

        Result<bool> accountValidation = _validator.ValidateAccountExistence(accountDto);
        if (!accountValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, accountValidation.ErrorMessage);
        }

        Result<bool> pinValidation = _validator.ValidatePin(pin);
        if (!pinValidation.IsSuccess || pin != accountDto?.Pin)
        {
            return new Result<AccountDTO>(false, null, "Invalid PIN.");
        }

        Result<bool> amountValidation = _validator.ValidateAmount(amount);
        if (!amountValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, amountValidation.ErrorMessage);
        }

        Result<bool> balanceValidation = _validator.ValidateBalance(accountDto.Balance, amount);
        if (!balanceValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, balanceValidation.ErrorMessage);
        }

        accountDto.Balance -= amount;

        var transaction = new TransactionDTO
        {
            AccountId = accountId,
            Amount = amount,
            Type = "Withdraw",
            Date = DateTime.UtcNow,
        };

        await _accountRepository.UpdateAccountBalanceAsync(accountDto, transaction);

        return new Result<AccountDTO>(true, accountDto);
    }

    public async Task<IResult<AccountDTO>> CreateAccountAsync(long id, string pin)
    {
        Result<bool> pinValidation = _validator.ValidatePin(pin);
        if (!pinValidation.IsSuccess)
        {
            return new Result<AccountDTO>(false, null, pinValidation.ErrorMessage);
        }

        AccountDTO? existingAccount = await _accountRepository.GetAccountByIdAsync(id);
        if (existingAccount != null)
        {
            return new Result<AccountDTO>(false, null, "Account with this ID already exists.");
        }

        var newAccount = new AccountDTO
        {
            Id = id,
            Pin = pin,
            Balance = 0,
        };

        await _accountRepository.AddAccountAsync(newAccount);

        return new Result<AccountDTO>(true, newAccount);
    }

    public async Task<IResult<List<TransactionDTO>>> GetTransactionsAsync(long accountId)
    {
        AccountDTO? accountDto = await _accountRepository.GetAccountByIdAsync(accountId);
        Result<bool> accountValidation = _validator.ValidateAccountExistence(accountDto);
        if (!accountValidation.IsSuccess)
        {
            return new Result<List<TransactionDTO>>(false, null, accountValidation.ErrorMessage);
        }

        List<TransactionDTO> transactions = await _accountRepository.GetTransactionsAsync(accountId);
        return new Result<List<TransactionDTO>>(true, transactions);
    }

    public async Task<IResult<List<TransactionDTO>>> GetTransactionsAsync(long accountId, string pin)
    {
        AccountDTO? accountDto = await _accountRepository.GetAccountByIdAsync(accountId);
        Result<bool> accountValidation = _validator.ValidateAccountExistence(accountDto);
        if (!accountValidation.IsSuccess)
        {
            return new Result<List<TransactionDTO>>(false, null, accountValidation.ErrorMessage);
        }

        Result<bool> pinValidation = _validator.ValidatePin(pin);
        if (!pinValidation.IsSuccess || pin != accountDto?.Pin)
        {
            return new Result<List<TransactionDTO>>(false, null, "Invalid PIN.");
        }

        List<TransactionDTO> transactions = await _accountRepository.GetTransactionsAsync(accountId);
        return new Result<List<TransactionDTO>>(true, transactions);
    }
}

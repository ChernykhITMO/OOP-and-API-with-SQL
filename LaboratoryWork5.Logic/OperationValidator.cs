using LaboratoryWork5.Ports.DTO;

namespace Logic;

public class OperationValidator
{
    public Result<bool> ValidatePin(string pin)
    {
        if (string.IsNullOrEmpty(pin) || pin.Length != 4 || !pin.All(char.IsDigit))
        {
            return new Result<bool>(false, false, "PIN must be 4 digits.");
        }

        return new Result<bool>(true, true);
    }

    public Result<bool> ValidateAccountExistence(AccountDTO? account)
    {
        if (account == null)
        {
            return new Result<bool>(false, false, "Account not found.");
        }

        return new Result<bool>(true, true);
    }

    public Result<bool> ValidateAmount(decimal amount)
    {
        if (amount <= 0)
        {
            return new Result<bool>(false, false, "Amount must be greater than zero.");
        }

        return new Result<bool>(true, true);
    }

    public Result<bool> ValidateBalance(decimal balance, decimal amount)
    {
        if (balance < amount)
        {
            return new Result<bool>(false, false, "Insufficient funds.");
        }

        return new Result<bool>(true, true);
    }
}

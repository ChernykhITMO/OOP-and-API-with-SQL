using LaboratoryWork5.Ports;

namespace Logic;

public class Transaction
{
    public long Id { get; set; }

    public long AccountId { get; private set; }

    public decimal Amount { get; private set; }

    public TypeTransaction Type { get; init; }

    public DateTime Date { get; init; }

    public Transaction(long accountId, decimal amount, TypeTransaction type, DateTime date)
    {
        AccountId = accountId;
        Amount = amount;
        Type = type;
        Date = date;
    }
}
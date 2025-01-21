namespace Logic;

public class Account
{
    public long Id { get; private set; }

    public decimal Balance { get; private set; }

    public string? Pin { get; private set; }

    private readonly List<Transaction> _transactions;

    public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();

    public Account(long id, string? pin, decimal balance = 0)
    {
        Id = id;
        Balance = balance;
        Pin = pin;
        _transactions = new List<Transaction>();
    }
}
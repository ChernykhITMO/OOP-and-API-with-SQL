namespace LaboratoryWork5.Ports.DTO;

public class TransactionDTO
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public decimal Amount { get; set; }

    public string? Type { get; set; }

    public DateTime Date { get; set; }
}
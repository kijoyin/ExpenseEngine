namespace ExpenseEngine.Domain
{
    public class ExpenseEntity:EntityBase
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string? Tags { get; set; }
        public DateOnly SpendOn { get; set; }
    }
}
using ExpenseEngine.Domain.Entities;

namespace ExpenseEngine.Domain
{
    public class ExpenseEntity:EntityBase
    {
        public string Description { get; set; }
        public string UniqueKey { get; set; }
        public decimal Amount { get; set; }
        public List<TagRuleEntity> Tags { get; set; } = new List<TagRuleEntity>();
        public DateOnly SpendOn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid BankId { get; set; }
        public BankEntity Bank { get; set; }

    }
}
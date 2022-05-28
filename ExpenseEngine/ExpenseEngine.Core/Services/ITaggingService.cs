using ExpenseEngine.Domain.Entities;

namespace ExpenseEngine.Core.Services
{
    public interface ITaggingService
    {
        Task<List<TagRuleEntity>> GetTags(string text);
    }
}
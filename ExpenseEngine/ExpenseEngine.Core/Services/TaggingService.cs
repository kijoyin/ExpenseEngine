using ExpenseEngine.Domain;
using ExpenseEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Services
{
    public class TaggingService : ITaggingService
    {
        private static ExpenseContext? _context;
        private  static List<TagRuleEntity>? _rules;
        private static TagRuleEntity? _untagged;

        public TaggingService(ExpenseContext context)
        {
            _context = context;
        }
        
        private async static Task LoadTagTules()
        {
            _rules  = _rules ?? await _context.TagRules.Where(r => !r.Tag.Equals("Untagged")).ToListAsync();
            _untagged = _untagged ?? await _context.TagRules.FirstOrDefaultAsync(r => !r.Tag.Equals("Untagged"));
        }
        public async Task<List<TagRuleEntity>> GetTags(string text)
        {
            await LoadTagTules();
            var tags = new List<TagRuleEntity>();
            
            foreach (var rule in _rules)
            {
                if(rule.Matches.Any(r=>text.Contains(r,StringComparison.InvariantCultureIgnoreCase)))
                {
                    tags.Add(rule);
                }
            }
            if(tags.Count == 0)
            {
                tags.Add(_untagged);
            }
            return tags;
        }
    }
}

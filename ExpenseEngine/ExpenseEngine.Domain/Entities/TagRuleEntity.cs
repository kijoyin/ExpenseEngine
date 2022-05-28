using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Domain.Entities
{
    public class TagRuleEntity: EntityBase
    {
        public string Tag { get; set; }
        public List<string> Matches { get; set; }
        public List<ExpenseEntity> Expenses { get; set; }
    }
    //public class Match:EntityBase
    //{
    //    public TagRuleEntity TagRule { get; set; }
    //    public Match(string value)
    //    {
    //        Value = value;
    //    }

    //    public string Value { get; set; }
    //}
}

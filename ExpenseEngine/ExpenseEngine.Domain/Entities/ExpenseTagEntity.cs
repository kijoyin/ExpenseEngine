using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Domain.Entities
{
    public class ExpenseTagEntity
    {
        public virtual ExpenseEntity Expense { get; set; }
        public virtual TagRuleEntity Tag { get; set; }
    }
}

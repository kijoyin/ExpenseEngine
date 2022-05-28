using CsvHelper;
using CsvHelper.Configuration;
using ExpenseEngine.Core.Models;
using ExpenseEngine.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Core.Services
{
    public class ExpenseReaderService : IExpenseReaderService
    {
        private readonly ExpenseContext _context;
        private readonly ITaggingService _taggingService;

        public ExpenseReaderService(ExpenseContext context,
            ITaggingService taggingService)
        {
            _context = context;
            _taggingService = taggingService;
        }
        public async Task ReadStatement()
        {
            using (var reader = new StreamReader("C:\\Users\\kijoyin\\Downloads\\Transactions.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-AU")))
            {
                csv.Context.RegisterClassMap<ExpenseEntityMap>();
                var records = csv.GetRecords<ExpenseEntity>();
                foreach (var record in records)
                {
                    if(_context.Expenses.FirstOrDefault(e => e.Description == record.Description) == null)
                    {
                        record.Tags = new List<Domain.Entities.TagRuleEntity>();
                        record.Tags.AddRange(await _taggingService.GetTags(record.Description));
                        await _context.AddAsync(record);
                    }
                }
                _context.SaveChanges();
            }
         }
    }
    public class ExpenseEntityMap : ClassMap<ExpenseEntity>
    {
        public ExpenseEntityMap()
        {
            Map(m => m.Description).Name("Description");
            Map(m => m.Amount).Name("Debit");
            Map(m => m.SpendOn).Name("Date");
        }
    }
}

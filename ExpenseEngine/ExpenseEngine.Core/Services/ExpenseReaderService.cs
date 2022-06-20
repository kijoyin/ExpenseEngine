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
        private readonly Guid KoganCredit = new Guid("3d2b2614-f3f2-479d-8ddb-9ab32ef5237e");
        private readonly Guid INGBlow = new Guid("d1ab2846-f529-436d-8473-2d583873af73");

        public ExpenseReaderService(ExpenseContext context,
            ITaggingService taggingService)
        {
            _context = context;
            _taggingService = taggingService;
        }
        public async Task ReadStatement()
        {
            using (var reader = new StreamReader("C:\\Users\\kijoyin\\OneDrive\\Expenses\\ING.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-AU")))
            {
                csv.Context.RegisterClassMap<ExpenseEntityMap>();  // dynamically select this
                var records = csv.GetRecords<ExpenseEntity>();
                foreach (var record in records.Where(r=>r.Amount < 0))
                {
                    record.UniqueKey =record.SpendOn.ToShortDateString()+record.Description+record.Amount;
                    if(_context.Expenses.FirstOrDefault(e => e.UniqueKey == record.UniqueKey) == null)
                    {
                        record.Tags = new List<Domain.Entities.TagRuleEntity>();
                        record.Tags.AddRange(await _taggingService.GetTags(record.Description));
                        record.BankId = INGBlow; // pick this dynamically
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

    public class KoganEntityMap : ClassMap<ExpenseEntity>
    {
        public KoganEntityMap()
        {
            Map(m => m.Description).Name("DESCRIPTION");
            Map(m => m.Amount).Name("AMOUNT");
            Map(m => m.SpendOn).Name("TRANSACTION DATE");
        }
    }
}

using ExpenseEngine.Core.Models;
using ExpenseEngine.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseEngine.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        // GET: api/<ExpenseController>
        [HttpGet]
        public async Task<IEnumerable<Expense>> Get()
        {
            return await _expenseService.GetExpenses();
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

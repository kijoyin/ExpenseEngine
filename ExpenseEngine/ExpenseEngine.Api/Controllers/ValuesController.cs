using ExpenseEngine.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseEngine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<bool>> ProcessTransactions (List<StatementItem> statementItems)
        {
            return true;
        }
    }
}

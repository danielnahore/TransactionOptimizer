using Microsoft.AspNetCore.Mvc;
using TransactionProcessor.Models;
using TransactionProcessor.Services;

namespace TransactionProcessor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionQueue _transactionQueue;

        public TransactionController(ITransactionQueue transactionQueue)
        {
            _transactionQueue = transactionQueue;
        }

        [HttpPost("submit")]
        public IActionResult SubmitTransaction([FromBody] Transaction transaction)
        {
            if (transaction == null || string.IsNullOrEmpty(transaction.Id))
                return BadRequest("Invalid transaction data.");

            _transactionQueue.EnqueueTransaction(transaction);

            return Ok(new { Status = "Transaction submitted successfully", TransactionId = transaction.Id });
        }
    }
}
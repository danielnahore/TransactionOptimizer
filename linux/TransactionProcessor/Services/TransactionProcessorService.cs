using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace TransactionProcessor.Services
{
    public class TransactionProcessorService : BackgroundService
    {
        private readonly ITransactionQueue _transactionQueue;

        public TransactionProcessorService(ITransactionQueue transactionQueue)
        {
            _transactionQueue = transactionQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _transactionQueue.ProcessQueue(stoppingToken);
        }
    }
}

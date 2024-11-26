using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TransactionProcessor.Models;

namespace TransactionProcessor.Services
{
    public class TransactionQueue : ITransactionQueue
    {
        private readonly BlockingCollection<Transaction> _transactionQueue;

        public TransactionQueue()
        {
            _transactionQueue = new BlockingCollection<Transaction>(new ConcurrentQueue<Transaction>());
        }

        public void EnqueueTransaction(Transaction transaction)
        {
            _transactionQueue.Add(transaction);
        }

        public async Task ProcessQueue(CancellationToken cancellationToken)
        {
            foreach (var transaction in _transactionQueue.GetConsumingEnumerable(cancellationToken))
            {
                await ProcessTransactionAsync(transaction);
            }
        }

        private Task ProcessTransactionAsync(Transaction transaction)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500); // Simulate transaction processing
                System.Console.WriteLine($"Processed transaction {transaction.Id}");
            });
        }
    }
}
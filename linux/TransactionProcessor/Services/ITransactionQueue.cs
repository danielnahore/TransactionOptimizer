using TransactionProcessor.Models;

namespace TransactionProcessor.Services
{
    public interface ITransactionQueue
    {
        void EnqueueTransaction(Transaction transaction);
        Task ProcessQueue(CancellationToken cancellationToken);
    }
}
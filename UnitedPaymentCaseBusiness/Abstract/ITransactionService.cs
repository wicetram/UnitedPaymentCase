using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Transaction;

namespace UnitedPaymentCaseBusiness.Abstract
{
    public interface ITransactionService
    {
        int Add(TransactionRequestDto transactionRequest);

        List<Transaction> GetTransactions();

        Transaction GetTransaction(string transactionId);
    }
}

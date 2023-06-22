using UnitedPaymentCaseBusiness.Abstract;
using UnitedPaymentCaseDataAccess.Concrete.EntityFramework;
using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Transaction;

namespace UnitedPaymentCaseBusiness.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private readonly EfTransactionDal _transactionDal;

        public TransactionManager(EfTransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        /// <summary>
        /// Ödeme kaydetme
        /// </summary>
        /// <param name="transactionRequest"></param>
        /// <returns></returns>
        public int Add(TransactionRequestDto transactionRequest)
        {
            try
            {
                var transaction = CreateTransaction(transactionRequest);
                return _transactionDal.Add(transaction);
            }
            catch (Exception)
            {
            }
            return 0;
        }

        /// <summary>
        /// DTO Oluşturur
        /// </summary>
        /// <param name="transactionRequest"></param>
        /// <returns></returns>
        private static Transaction CreateTransaction(TransactionRequestDto transactionRequest)
        {
            return new Transaction
            {
                Amount = transactionRequest.Amount,
                CustomerId = transactionRequest.CustomerId,
                CVV = transactionRequest.CVV,
                ExpDay = transactionRequest.ExpYear,
                ExpMonth = transactionRequest.ExpMonth,
                OrderId = transactionRequest.OrderId,
                Pan = transactionRequest.Pan,
                TransactionId = transactionRequest.TransactionId,
                Type = transactionRequest.Type,
            };
        }

        /// <summary>
        /// Ödeme getirme
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public Transaction GetTransaction(string transactionId)
        {
            try
            {
                return _transactionDal.Get(p => p.TransactionId == transactionId);
            }
            catch (Exception)
            {
            }
            return null;
        }

        /// <summary>
        /// Tüm ödemeleri getirme
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetTransactions()
        {
            try
            {
                return _transactionDal.GetAll();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}

using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Transaction;

namespace UnitedPaymentCaseWebApi.Business.Abstract
{
    public interface IPaymentService
    {
        TransactionResponseDto Transaction(TransactionRequestDto transactionRequest);
        List<Transaction> GetAll();
    }
}

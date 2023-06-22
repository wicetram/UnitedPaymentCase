using UnitedPaymentCaseCore.DataAccess.EntityFramework;
using UnitedPaymentCaseDataAccess.Abstract;
using UnitedPaymentCaseDataAccess.Concrete.EntityFramework.Context;
using UnitedPaymentCaseEntity.Concrete;

namespace UnitedPaymentCaseDataAccess.Concrete.EntityFramework
{
    public class EfTransactionDal : EfEntityRepositoryBase<Transaction, SimpleContextDb>, ITransactionDal
    {
    }
}

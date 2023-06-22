using UnitedPaymentCaseCore.DataAccess;
using UnitedPaymentCaseEntity.Concrete;

namespace UnitedPaymentCaseDataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}

using UnitedPaymentCaseCore.DataAccess.EntityFramework;
using UnitedPaymentCaseDataAccess.Abstract;
using UnitedPaymentCaseDataAccess.Concrete.EntityFramework.Context;
using UnitedPaymentCaseEntity.Concrete;

namespace UnitedPaymentCaseDataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, SimpleContextDb>, ICustomerDal
    {
    }
}

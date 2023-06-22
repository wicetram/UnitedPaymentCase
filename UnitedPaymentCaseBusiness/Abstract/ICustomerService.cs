using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Customer;

namespace UnitedPaymentCaseBusiness.Abstract
{
    public interface ICustomerService
    {
        int Add(CustomerRequestDto customerRequest);
        List<Customer> GetList();
        Customer GetCustomer(string id);
    }
}

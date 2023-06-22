using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Register;

namespace UnitedPaymentCaseWebApi.Business.Abstract
{
    public interface IUserService
    {
        RegisterResponseDto AddCustomer(RegisterRequestDto requestDto);
        List<Customer> GetAll();
        Customer GetCustomer(string customerId);
    }
}

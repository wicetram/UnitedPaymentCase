using UnitedPaymentCaseBusiness.Abstract;
using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Customer;
using UnitedPaymentCaseEntity.Dto.Register;
using UnitedPaymentCaseWebApi.Business.Abstract;

namespace UnitedPaymentCaseWebApi.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly ICustomerService _customer;
        private readonly IVerificationService _verification;
        public UserManager(ICustomerService customer, IVerificationService verification)
        {
            _customer = customer;
            _verification = verification;
        }

        /// <summary>
        /// Kullanıcı ekleme işlemi
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public RegisterResponseDto AddCustomer(RegisterRequestDto requestDto)
        {
            try
            {
                var check = _verification.VerifyTCKN(requestDto);
                if (check)
                {
                    var customerId = Guid.NewGuid().ToString().Replace("-", "");
                    var customer = new CustomerRequestDto
                    {
                        BirthDate = requestDto.BirthDate,
                        IdentityNo = requestDto.IdentityNo,
                        Name = requestDto.Name,
                        Surname = requestDto.Surname,
                        Status = "1",
                        IdentityNoVerified = check,
                        CustomerId = customerId
                    };
                    var result = _customer.Add(customer);
                    if (result > 0)
                    {
                        return new RegisterResponseDto
                        {
                            CustomerId = customerId,
                            IdentityNoVerified = check,
                            Status = check
                        };
                    }
                }
            }
            catch (Exception)
            {

            }
            return new RegisterResponseDto();
        }

        /// <summary>
        /// Kayıtlı tüm kullanıcıları getirme işlemi
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAll()
        {
            try
            {
                return _customer.GetList();
            }
            catch (Exception)
            {
            }
            return null;
        }

        /// <summary>
        /// Parametreye göre kullanıcı getirme işlemi
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomer(string customerId)
        {
            try
            {
                return _customer.GetCustomer(customerId);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}

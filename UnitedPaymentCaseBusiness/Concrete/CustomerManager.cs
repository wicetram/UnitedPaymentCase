using UnitedPaymentCaseBusiness.Abstract;
using UnitedPaymentCaseDataAccess.Concrete.EntityFramework;
using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Customer;

namespace UnitedPaymentCaseBusiness.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly EfCustomerDal _customerDal;

        public CustomerManager(EfCustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        /// <summary>
        /// Ekleme
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <returns></returns>
        public int Add(CustomerRequestDto customerRequest)
        {
            try
            {
                var user = CreateUser(customerRequest);
                return _customerDal.Add(user);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// DTO Oluşturur
        /// </summary>
        /// <param name="customerRequest"></param>
        /// <returns></returns>
        private static Customer CreateUser(CustomerRequestDto customerRequest)
        {
            try
            {
                string verify = customerRequest.IdentityNoVerified ? "true" : "false";
                return new Customer
                {
                    Name = customerRequest.Name,
                    Surname = customerRequest.Surname,
                    CustomerId = customerRequest.CustomerId,
                    BirthDate = customerRequest.BirthDate,
                    IdentityNo = customerRequest.IdentityNo,
                    IdentityNoVerified = verify,
                    Status = customerRequest.Status,
                };
            }
            catch (Exception)
            {
            }

            return new Customer();
        }

        /// <summary>
        /// Kullanıcı getirme
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomer(string customerId)
        {
            try
            {
                return _customerDal.Get(p => p.CustomerId == customerId);
            }
            catch (Exception)
            {
            }
            return null;
        }

        /// <summary>
        /// Tüm kullanıcıları getirme
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetList()
        {
            try
            {
                return _customerDal.GetAll();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using UnitedPaymentCaseEntity.Dto.Register;
using UnitedPaymentCaseEntity.Dto.Transaction;
using UnitedPaymentCaseWebApi.Business.Abstract;

namespace UnitedPaymentCaseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IPaymentService _payment;
        private readonly IUserService _userService;

        public BaseController(IUserService userService, IPaymentService payment)
        {
            _userService = userService;
            _payment = payment;
        }

        /// <summary>
        /// Kullanıcı ekleme işlemi
        /// </summary>
        /// <param name="registerRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public object RegisterCustomer(RegisterRequestDto registerRequestDto)
        {
            return _userService.AddCustomer(registerRequestDto);
        }

        /// <summary>
        /// Kayıtlı kullanıcıyı getirme işlemi
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getCustomer")]
        public object GetCustomer(string customerId)
        {
            return _userService.GetCustomer(customerId);
        }

        /// <summary>
        /// Kayıtlı tüm kullanıcıları getirme işlemi
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("allCustomer")]
        public object AllCustomer()
        {
            return _userService.GetAll();
        }

        /// <summary>
        /// Ödeme işlemi
        /// </summary>
        /// <param name="transactionRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Payment")]
        public object NonSecurePayment(TransactionRequestDto transactionRequestDto)
        {
            return _payment.Transaction(transactionRequestDto);
        }
    }
}

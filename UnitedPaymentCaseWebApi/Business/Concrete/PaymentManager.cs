using Newtonsoft.Json;
using RestSharp;
using UnitedPaymentCaseBusiness.Abstract;
using UnitedPaymentCaseCore.Util.Const;
using UnitedPaymentCaseCore.Util.Hash;
using UnitedPaymentCaseEntity.Concrete;
using UnitedPaymentCaseEntity.Dto.Transaction;
using UnitedPaymentCaseEntity.Dto.UnitedPaymentRequest;
using UnitedPaymentCaseEntity.Dto.UnitedPaymentToken;
using UnitedPaymentCaseWebApi.Business.Abstract;

namespace UnitedPaymentCaseWebApi.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly string TokenUrl = "https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg";
        private readonly string NonSecureUrl = "https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/Payment";

        public string Token { get; set; }

        private readonly ITransactionService _transaction;

        public PaymentManager(ITransactionService transaction)
        {
            _transaction = transaction;
            GetToken();
        }

        /// <summary>
        /// Tüm işlemleri getirir
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetAll()
        {
            try
            {
                return _transaction.GetTransactions();
            }
            catch (Exception)
            {
            }
            return null;
        }

        /// <summary>
        /// NonSecure Ödeme İşlemi
        /// </summary>
        /// <param name="transactionRequest"></param>
        /// <returns></returns>
        public TransactionResponseDto Transaction(TransactionRequestDto transactionRequest)
        {
            try
            {
                var newAmount = transactionRequest.Amount.Replace(".", "").Replace(",", "");

                var rnd = Guid.NewGuid().ToString();

                string userCode = LoginInfo.Email;
                string customerId = LoginInfo.Email;

                var hashString = $"{LoginInfo.ApiKey}{userCode}{rnd}{transactionRequest.Type}{newAmount}{customerId}{transactionRequest.OrderId}";

                var hash = AESCrypto.CreateHash(hashString);

                var payment = new NonSecurePaymentRequestDto
                {
                    memberId = "1",
                    merchantId = "1894",
                    customerId = customerId,
                    cardNumber = transactionRequest.Pan,
                    expiryDateMonth = transactionRequest.ExpMonth,
                    expiryDateYear = transactionRequest.ExpYear,
                    cvv = transactionRequest.CVV,
                    userCode = userCode,
                    txnType = transactionRequest.Type,
                    installmentCount = "1",
                    currency = "949",
                    orderId = transactionRequest.OrderId,
                    totalAmount = newAmount,
                    rnd = rnd,
                    hash = hash,
                    description = "Ödeme işlemi",
                    secureDataId = 1,
                };

                if (string.IsNullOrEmpty(Token))
                {
                    GetToken();
                }

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("Authorization", $"Bearer {Token}");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(payment), ParameterType.RequestBody);

                var client = new RestClient($"{NonSecureUrl}/NoneSecurePayment");
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var responseResult = JsonConvert.DeserializeObject<NonSecureResponseDto>(response.Content);
                    if (responseResult.fail == true && responseResult.statusCode == 200)
                    {
                        var add = _transaction.Add(transactionRequest);
                        if (add > 0)
                        {
                            return new TransactionResponseDto
                            {
                                ResponseCode = responseResult.statusCode,
                                ResponseMessage = responseResult.result.responseMessage,
                                Status = responseResult.fail
                            };
                        }
                    }
                    else
                    {
                        return new TransactionResponseDto
                        {
                            ResponseCode = responseResult.statusCode,
                            ResponseMessage = responseResult.result.responseMessage,
                            Status = responseResult.fail
                        };
                    }
                }
            }
            catch (Exception)
            {
            }
            return new TransactionResponseDto();
        }

        /// <summary>
        /// Token Servisi
        /// </summary>
        /// <returns></returns>
        private TokenResponseDto GetToken()
        {
            try
            {
                var token = new TokenRequestDto
                {
                    Email = LoginInfo.Email,
                    Lang = LoginInfo.Lang,
                    ApiKey = LoginInfo.ApiKey
                };

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(token), ParameterType.RequestBody);

                var client = new RestClient($"{TokenUrl}/Securities/authenticationMerchant");
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<TokenResponseDto>(response.Content);
                    if (result.fail == false && result.statusCode == 200)
                    {
                        Token = result.result.token;
                    }
                }
            }
            catch (Exception)
            {
            }
            return new TokenResponseDto();
        }
    }
}

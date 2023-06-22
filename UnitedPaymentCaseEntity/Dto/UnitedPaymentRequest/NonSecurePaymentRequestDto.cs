﻿namespace UnitedPaymentCaseEntity.Dto.UnitedPaymentRequest
{
    public class NonSecurePaymentRequestDto
    {
        public string memberId { get; set; }
        public string merchantId { get; set; }
        public string customerId { get; set; }
        public string cardNumber { get; set; }
        public string expiryDateMonth { get; set; }
        public string expiryDateYear { get; set; }
        public string cvv { get; set; }
        public int secureDataId { get; set; }
        public string cardAlias { get; set; }
        public string userCode { get; set; }
        public string txnType { get; set; }
        public string installmentCount { get; set; }
        public string currency { get; set; }
        public string orderId { get; set; }
        public string totalAmount { get; set; }
        public string pointAmount { get; set; }
        public string rnd { get; set; }
        public string hash { get; set; }
        public string description { get; set; }
        public string cardHolderName { get; set; }
        public string requestIp { get; set; }
        public NonSecurePaymentRequesBillingInfo billingInfo { get; set; }
        public NonSecurePaymentRequesDeliveryInfo deliveryInfo { get; set; }
        public List<NonSecurePaymentRequesOrderProductList> orderProductList { get; set; }
    }

    public class NonSecurePaymentRequesBillingInfo
    {
        public string taxNo { get; set; }
        public string taxOffice { get; set; }
        public string firmName { get; set; }
        public string identityNumber { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string zipCode { get; set; }
    }

    public class NonSecurePaymentRequesDeliveryInfo
    {
        public string taxNo { get; set; }
        public string taxOffice { get; set; }
        public string firmName { get; set; }
        public string identityNumber { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string zipCode { get; set; }
    }

    public class NonSecurePaymentRequesOrderProductList
    {
        public string merchantId { get; set; }
        public string productId { get; set; }
        public string amount { get; set; }
        public string productName { get; set; }
        public string commissionRate { get; set; }
    }
}

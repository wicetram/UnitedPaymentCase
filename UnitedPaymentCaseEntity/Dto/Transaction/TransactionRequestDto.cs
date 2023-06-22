namespace UnitedPaymentCaseEntity.Dto.Transaction
{
    public class TransactionRequestDto
    {
        public string TransactionId { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public string Pan { get; set; }
        public string CVV { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
    }
}

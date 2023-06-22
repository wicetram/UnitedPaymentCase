namespace UnitedPaymentCaseEntity.Concrete
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public string Pan { get; set; }
        public string CVV { get; set; }
        public string ExpMonth { get; set; }
        public string ExpDay { get; set; }
    }
}

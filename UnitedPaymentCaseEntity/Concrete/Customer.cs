namespace UnitedPaymentCaseEntity.Concrete
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string IdentityNo { get; set; }
        public string IdentityNoVerified { get; set; }
        public string Status { get; set; }
    }
}

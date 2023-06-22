namespace UnitedPaymentCaseEntity.Dto.Customer
{
    public class CustomerRequestDto
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }
        public string Status { get; set; }
    }
}

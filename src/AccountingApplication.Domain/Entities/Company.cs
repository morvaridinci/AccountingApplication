namespace AccountingApplication.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Date { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxOffice { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Password { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

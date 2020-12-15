using System.ComponentModel.DataAnnotations;

namespace RestArtIS.Shared.Models
{
    public class Settings : BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }    
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string ICO { get; set; }
        [StringLength(20)]
        public string DIC { get; set; }

        public Address BillingAddress { get; set; }
        public Address MailingAddress { get; set; }
        public bool MailingAddressSameAsBillingAddress { get; set; }

        [StringLength(30)]
        public string BankAccount { get; set; }
    }
}

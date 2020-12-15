using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class BusinessPartner: BaseEntity
    {
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public int Order { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string ICO { get; set; }
        [StringLength(20)]
        public string DIC { get; set; }
        [StringLength(30)]
        public string BankAccount { get; set; }
        public bool IsActive { get; set; }

        public Address BillingAddress { get; set; }
        public Address MailingAddress { get; set; }
        public bool MailingAddressSameAsBillingAddress { get; set; }

        public BusinessPartner()
        {
            IsActive = true;
        }
    }
}

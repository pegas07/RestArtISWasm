using System.ComponentModel.DataAnnotations;

namespace RestArtIS.Shared.Models
{
    public class Invoice : BaseEntity
    {
        [StringLength(20)]
        public string InvoiceNumber { get; set; }
        
    }
}

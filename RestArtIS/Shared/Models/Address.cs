using System.ComponentModel.DataAnnotations;

namespace RestArtIS.Shared.Models
{
    public class Address : BaseEntity
    {
        [StringLength(150)]
        public string Street { get; set; }
        [StringLength(150)]
        public string City { get; set; }
        [StringLength(20)]
        public string ZipCode { get; set; }

    }
}

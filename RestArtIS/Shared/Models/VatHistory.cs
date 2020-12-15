using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class VatHistory : BaseEntity
    {
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Rate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Vat Vat { get; set; }
        public int VatId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class Allergen :BaseEntity
    {
        [StringLength(2)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string NameAddition { get; set; }
    }
}

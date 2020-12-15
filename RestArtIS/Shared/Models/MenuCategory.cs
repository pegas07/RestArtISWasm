using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class MenuCategory: BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }
        public int? MenuTypeId { get; set; }
        public MenuType MenuType { get; set; }
        public bool IsDelivery { get; set; }
    }
}

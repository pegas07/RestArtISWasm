using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class MenuItemTemplate : BaseEntity
    {
        [StringLength(2)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public MenuCategory MenuCategory { get; set; }
        [StringLength(20)]
        public string Weight { get; set; }
    }
}

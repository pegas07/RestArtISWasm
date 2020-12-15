using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public enum MenuTypes { Day = 1, Week = 2, Permanent = 3 }
    public class Menu : BaseEntity
    {
        public MenuType MenuType { get; set; }
        public bool IsDelivery { get; set; }
    }
}

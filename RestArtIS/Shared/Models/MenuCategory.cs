using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class MenuCategory : BaseEntity
    {
        

        [StringLength(200)]
        public string Name { get; set; }
        [ForeignKey("MenuType")]
        public int? MenuTypeId { get; set; }
        
        private MenuType menuType;
        public virtual MenuType MenuType 
        { 
            get => menuType;
            set
            {
                menuType = value;
                MenuTypeId = menuType?.Id;
            }
        }

        public ICollection<MenuItemCategory> MenuItemCategories { get; set; }
        public bool IsDelivery { get; set; }
    }
}

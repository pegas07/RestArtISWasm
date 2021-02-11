using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class MenuItem : BaseEntity
    {
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Amount { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("Menu")]
        public int? MenuId { get; set; }

        private Menu menu;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Menu Menu
        {
            get => menu;
            set
            {
                menu = value;
                MenuId = menu?.Id;
            }
        }

        [ForeignKey("MenuItemCategory")]
        public int? MenuItemCategoryId { get; set; }

        private MenuItemCategory menuItemCategory;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual MenuItemCategory MenuItemCategory
        {
            get => menuItemCategory;
            set
            {
                menuItemCategory = value;
                MenuItemCategoryId = menuItemCategory?.Id;
            }
        }

        public DateTime? Date { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public bool IsOnlyNote { get; set; }
    }
}

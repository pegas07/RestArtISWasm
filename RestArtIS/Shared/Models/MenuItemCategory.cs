using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestArtIS.Shared.Models
{
    public class MenuItemCategory : BaseEntity
    {
        [StringLength(500)]
        public string Name { get; set; }
        [ForeignKey("MenuCategory")]        
        public int? MenuCategoryId { get; set; }

        private MenuCategory menuCategory;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual MenuCategory MenuCategory
        {
            get => menuCategory;
            set
            {
                menuCategory = value;
                MenuCategoryId = menuCategory?.Id;
            }
        }
        public int CategoryOrder { get; set; }
    }
}

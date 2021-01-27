using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestArtIS.Shared.Models
{
    public class OrderItem : BaseEntity
    {
        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        private Order order;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Order Order
        {
            get => order;
            set
            {
                order = value;
                OrderId = order?.Id;
            }
        }
        public int Amount { get; set; }

        [StringLength(200)]
        public string ItemDescription { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("MenuItem")]
        public int? MenuItemId { get; set; }
        private MenuItem menuItem;        
        public MenuItem MenuItem
        {
            get => menuItem;
            set
            {
                menuItem = value;
                MenuItemId = value?.Id;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public enum MenuTypes { Day = 1, Week = 2, Permanent = 3 }
    public class Menu : BaseEntity
    {
        [StringLength(500)]
        public string Name { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        [ForeignKey("MenuCategory")]
        public int? MenuCategoryId { get; set; }

        private MenuCategory menuCategory;
        public virtual MenuCategory MenuCategory
        {
            get => menuCategory;
            set
            {
                menuCategory = value;
                MenuCategoryId = menuCategory?.Id;
            }
        }
        public bool MenuCategory_IsReadOnly => Id != 0 && MenuCategoryId != null;
        public bool IsDelivery { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}

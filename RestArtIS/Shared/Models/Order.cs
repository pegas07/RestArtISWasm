﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestArtIS.Shared.Models
{
    public class Order : BaseEntity
    {
        public DateTime DateCreated { get; set; }

        [ForeignKey("BusinessPartner")]
        public int? BusinessPartnerId { get; set; }
        private BusinessPartner businessPartner;
        public BusinessPartner BusinessPartner 
        { 
            get => businessPartner; 
            set 
            {
                businessPartner = value; 
                BusinessPartnerId = value?.Id;
                if (BusinessPartner != null && BusinessPartner.DeliveryRoute != null)
                    DeliveryRoute = BusinessPartner.DeliveryRoute;
            }
        }

        [ForeignKey("DeliveryRoute")]
        public int? DeliveryRouteId { get; set; }
        private DeliveryRoute deliveryRoute;        

        public DeliveryRoute DeliveryRoute
        {
            get => deliveryRoute;
            set
            {
                deliveryRoute = value;
                DeliveryRouteId = value?.Id;
            }
        }

        [StringLength(2000)]
        public string Note { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            DateCreated = DateTime.Now;
        }
    }
}
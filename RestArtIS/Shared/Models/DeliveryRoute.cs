using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestArtIS.Shared.Models
{
    public class DeliveryRoute: BaseEntity
    {
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
    }
}

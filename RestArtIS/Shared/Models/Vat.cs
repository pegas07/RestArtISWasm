using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace RestArtIS.Shared.Models
{
    public class Vat: BaseEntity
    {
        public string Name { get; set; }
        [NotMapped]
        public decimal ActualRate => GetActualVatRate(DateTime.Now);
        public ICollection<VatHistory> VatHistories { get; set; }

        public decimal GetActualVatRate(DateTime dateTime)
        {
            if (VatHistories == null)
                return 0;
            return VatHistories.FirstOrDefault(v => v.ValidFrom <= dateTime && (!v.ValidTo.HasValue || v.ValidTo.Value > dateTime)).Rate;
        } 
    }
}

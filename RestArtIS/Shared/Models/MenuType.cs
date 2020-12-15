using System.ComponentModel.DataAnnotations;

namespace RestArtIS.Shared.Models
{
    public class MenuType : BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }
    }
}

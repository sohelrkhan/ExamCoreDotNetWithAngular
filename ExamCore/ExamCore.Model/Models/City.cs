using ExamCore.Shared.Mappings;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamCore.Model.Models
{
    public class City : IAuditableEntity, IDelatableEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        [Required(ErrorMessage = "Please, provide city name!")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        //Foreign Key
        public int CountryId { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Country Country { get; set; } = null!;
    }
}

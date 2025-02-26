﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamCore.Shared.Mappings;

namespace ExamCore.Model.Models
{
    public class Country : IAuditableEntity, IDelatableEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please, provide name.")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
using AutoMapper;
using ExamCore.Model.Models;
using ExamCore.Shared.Mappings;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace ExamCore.Application.ApplicationLogic.CityLogic.Model
{
    public class CityViewModel
    {
        public CityCreateModel CreateModel { get; set; }
        public CityUpdateModel UpdateModel { get; set; }
        public CityGridModel GridModel { get; set; }
        public dynamic OptionsDataSources { get; set; } = new ExpandoObject();
    }

    public class CityCreateModel : IMapFrom<City>
    {
        [Column(TypeName = "NVARCHAR(50)")]
        [Required(ErrorMessage = "Please, provide city name!")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityCreateModel>();
            profile.CreateMap<CityCreateModel, City>();
        }
    }

    public class CityUpdateModel : IMapFrom<City>
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        [Required(ErrorMessage = "Please, provide city name!")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityUpdateModel>();
            profile.CreateMap<CityUpdateModel, City>();
        }
    }

    public class CityGridModel : IMapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityGridModel>();
            profile.CreateMap<CityGridModel, City>();
        }
    }
}

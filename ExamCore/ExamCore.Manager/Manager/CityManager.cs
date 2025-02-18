using ExamCore.Manager.Base;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using ExamCore.Repository.Contracts;
using ExamCore.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCore.Manager.Manager
{
    public class CityManager : BaseManager<City>, ICityManager
    {
        private readonly ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository) : base(cityRepository) => _cityRepository = cityRepository;

        public override async Task<ICollection<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }
    }
}

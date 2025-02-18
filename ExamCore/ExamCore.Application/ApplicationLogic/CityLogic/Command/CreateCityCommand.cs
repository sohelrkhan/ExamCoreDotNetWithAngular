using AutoMapper;
using ExamCore.Application.ApplicationLogic.CityLogic.Model;
using ExamCore.Application.ApplicationLogic.CountryLogic.Command;
using ExamCore.Application.ApplicationLogic.CountryLogic.Model;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ExamCore.Application.ApplicationLogic.CityLogic.Command
{
    public class CreateCityCommand : CityCreateModel, IRequest<CityCreateModel>
    {
        public class Handler : IRequestHandler<CreateCityCommand, CityCreateModel>
        {
            private readonly ICityManager _cityManager;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(ICityManager cityManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _cityManager = cityManager;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<CityCreateModel> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var createdCity = _mapper.Map<City>(request);
                createdCity.CreatedById = Guid.NewGuid().ToString();
                createdCity.CreatedDateTime = DateTime.UtcNow;

                createdCity = await _cityManager.CreateAsync(createdCity);
                return request;
            }
        }
    }
}

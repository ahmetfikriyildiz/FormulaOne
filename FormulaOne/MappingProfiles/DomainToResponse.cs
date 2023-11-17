using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achivement, DriverAchivementResponses>()
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.RaceWins));

            CreateMap<Driver, GetDriverResponse>()
                .ForMember(dest=>dest.DriverId,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName + " " + src.LastName}"));


        }

    }
}

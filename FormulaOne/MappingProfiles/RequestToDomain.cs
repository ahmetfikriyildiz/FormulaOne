using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;

namespace FormulaOne.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain() 
        {
            CreateMap<CreateDriverAchivementRequest, Achivement>()
                .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.AddedTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateDriverAchivementRequest, Achivement>()
                .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
                .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateDriverRequest, Driver>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.AddedTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(src => DateTime.UtcNow));


        }
    }
}

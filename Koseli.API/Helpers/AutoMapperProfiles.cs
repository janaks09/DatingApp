using System.Linq;
using AutoMapper;
using Koseli.API.Dtos;
using Koseli.API.Models;

namespace Koseli.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                    .ForMember(dest => dest.PhotoUrl, opt => {
                        opt.MapFrom(src =>src.Photos.FirstOrDefault(x => x.IsMain).Url);
                    })
                    .ForMember(dest => dest.Age, opt => {
                        opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                    });
            CreateMap<User, UserForDetailDto>()
                    .ForMember(dest => dest.PhotoUrl, opt => {
                        opt.MapFrom(src =>src.Photos.FirstOrDefault(x => x.IsMain).Url);
                    })
                    .ForMember(dest => dest.Age, opt => {
                        opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                    });
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}
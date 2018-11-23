using System.Linq;
using AutoMapper;
using PokemonApp.API.DTOs;
using PokemonApp.API.Models;

namespace PokemonApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsPrimary == true).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge()); 
                });

            CreateMap<AppUser, UserDetailedDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsPrimary == true).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge()); 
                });
                
            CreateMap<Photo, PhotoDetailedDTO>();
        }
    }
}
using AspNet.Data.Dtos;
using AspNet.Models;
using AutoMapper;

namespace AspNet.Profiles
{
    //Extends Profile
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
        }
    }
}

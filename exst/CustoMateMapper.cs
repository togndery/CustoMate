using AutoMapper;
using CustoMate.dtos;
using CustoMate.entity;

namespace CustoMate.exst
{
    public class CustoMateMapper :Profile
    {
        public CustoMateMapper()
        {
            CreateMap<User , UserCreateDto>().ReverseMap();
            CreateMap<UserResponsDto,User>().ReverseMap();
        }
    }
}

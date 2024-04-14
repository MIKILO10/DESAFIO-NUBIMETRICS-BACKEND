using AutoMapper;
using Desafios.Nubimetrics.Application.UsuariosEntity.Handler;
using Desafios.Nubimetrics.Domain.Entities;
using Desafios.Nubimetrics.DTO.UsuarioEntity;
using Desafios.Nubimetrics.DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.UsuariosEntity.Others
{
    public class UsuariosProfile:Profile
    {
        public UsuariosProfile()
        {
            // mapear de la entidad Usuarios a UsuariosGetDTO
            CreateMap<Usuarios, UsuariosGetDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUsuario))
                .ReverseMap();

            CreateMap<Result<Usuarios>, Result<UsuariosGetDTO>>().ReverseMap();


            CreateMap<Result<List<Usuarios>>, Result<List<UsuariosGetDTO>>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            CreateMap<UsuariosCreateDTO,  Usuarios>().ReverseMap();
            CreateMap<UsuariosUpdateDTO, Usuarios>().ReverseMap();
            CreateMap<UsuariosDeleteDTO, Usuarios>().ReverseMap();

        

            CreateMap<UsuariosCreateDTO, UsuariosGetDTO>();
        }
    }
}

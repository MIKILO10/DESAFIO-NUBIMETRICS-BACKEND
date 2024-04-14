using AutoMapper;
using Desafios.Nubimetrics.DTO.PaisEntity;
using Desafios.Nubimetrics.DTO.Utils;

namespace Desafios.Nubimetrics.Application.PaisesEntity.Others
{
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<Result<PaisGetDTO>, PaisGetDTO>();
        }
    }
}

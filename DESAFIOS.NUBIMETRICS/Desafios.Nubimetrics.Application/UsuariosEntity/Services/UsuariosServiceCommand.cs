using Desafios.Nubimetrics.Domain.Entities;
using Desafios.Nubimetrics.DTO.UsuarioEntity;
using Desafios.Nubimetrics.DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Application.UsuariosEntity.Services
{
    public partial class UsuariosService
    {
        public async Task<Result<UsuariosGetDTO>> Create(UsuariosCreateDTO request)
        {
            var entityMap = _mapper.Map<Usuarios>(request);
            var result =  await _unitOfWork.usuariosRepository.Create(entityMap);
            var mapeo = _mapper.Map<Result<UsuariosGetDTO>>(result);
            return mapeo;
        }

        public async Task<Result<UsuariosGetDTO>> Update(UsuariosUpdateDTO request)
        {
            var entityMap = _mapper.Map<Usuarios>(request);
            var result = await _unitOfWork.usuariosRepository.Update(entityMap, entityMap.IdUsuario);
            var mapeo = _mapper.Map<Result<UsuariosGetDTO>>(result);
            return mapeo;
        }
    

        public async Task<Result<UsuariosGetDTO>> Delete(UsuariosDeleteDTO request)
        {
            var result = await _unitOfWork.usuariosRepository.Delete(request.Id);
            var mapeo = _mapper.Map<Result<UsuariosGetDTO>>(result);
            return mapeo;
        }
    }
}

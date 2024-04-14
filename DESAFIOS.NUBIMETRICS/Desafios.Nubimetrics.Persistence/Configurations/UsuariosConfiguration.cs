using Desafios.Nubimetrics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafios.Nubimetrics.Persistence.Configurations
{
    internal class UsuariosConfiguration: IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> entityBuilder)
        {
            entityBuilder.Ignore(x => x.Id);
            entityBuilder.HasKey(e => e.IdUsuario);
            entityBuilder.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Apellido).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Password).HasMaxLength(50).IsRequired();
        }
    }
}

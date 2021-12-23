namespace Curso.Api.Infraestruture.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using Curso.Api.Business.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Descricao);
            builder.HasOne(p => p.Usuario)
                .WithMany().HasForeignKey(fk => fk.CodigoUsuario);            

        }
    }
}

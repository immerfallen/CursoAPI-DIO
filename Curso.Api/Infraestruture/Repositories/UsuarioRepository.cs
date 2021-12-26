using Curso.Api.Business.Entities;
using Curso.Api.Business.Repositories;
using Curso.Api.Infraestruture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Infraestruture.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _context;

        public UsuarioRepository(CursoDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);           
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}

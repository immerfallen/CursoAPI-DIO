namespace Curso.Api.Infraestruture.Repositories
{
    using Curso.Api.Business.Entities;
    using Curso.Api.Business.Repositories;
    using Curso.Api.Infraestruture.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CursoRepository : ICursoRepository
    {

        private readonly CursoDbContext _context;

        public CursoRepository(CursoDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Curso curso)
        {
            _context.Curso.Add(curso);
        }

        public void Commit()
        {
           _context.SaveChanges();
        }

        public IList<Business.Entities.Curso> ObterPorUsuario(int codigoUsuario)
        {
            return _context.Curso.Include(i => i.Usuario).Where(w=>w.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}

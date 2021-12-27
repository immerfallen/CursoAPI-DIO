namespace Curso.Api.Business.Repositories
{

    using Curso.Api.Business.Entities;
    using System.Collections.Generic;

    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Commit();
        IList<Curso> ObterPorUsuario(int codigoUsuario);
    }
}


namespace Curso.Api.Controllers
{
    using Curso.Api.Business.Repositories;
    using Curso.Api.Business.Entities;
    using Curso.Api.Models.Cursos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;



    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase

    {

        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        /// <summary>
        /// Este servico permite cadastrar curso para um usuario autenticado
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso e usuario</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {

            Curso curso = new Curso();
            curso.Nome = cursoViewModelInput.Nome;
            curso.Descricao = cursoViewModelInput.Descricao;
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            curso.CodigoUsuario = codigoUsuario;
            _cursoRepository.Adicionar(curso);
            _cursoRepository.Commit();
            return Created("", cursoViewModelInput);
        }

        /// <summary>
        /// Este servico permite obter todos os cursos ativos do usuario 
        /// </summary>
        /// <returns>Retorna status ok e dados do curso do usuario</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
           

           
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = _cursoRepository.ObterPorUsuario(codigoUsuario)
                .Select(s=> new CursoViewModelOutput() { 
                Nome = s.Nome,
                Descricao = s.Descricao,
                Login = s.Usuario.Login});
           
           
            return Ok(cursos);
        }
    }
}

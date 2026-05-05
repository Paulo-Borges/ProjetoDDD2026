using Domain.Interfaces;
using Domain.InterfacesServicos;
using Entities.Entidades;
using Entities.EntidadesNoMap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisasController : ControllerBase
    {
        private readonly IPesquisaRepository _IPesquisaRepository;


        public PesquisasController(IPesquisaRepository IPesquisaRepository)
        {
            _IPesquisaRepository = IPesquisaRepository;
           
        }

        [HttpGet("/api/GetAllPesquisa")]              // Os Metódos
        [Produces("aplication/json")]
        public async Task<object> GetAllPesquisa(int id)
        {
            return await _IPesquisaRepository.GetByIdAsync(id);
        }


        [HttpPost("/api/GetAddPesquisa")]              // Os Metódos
        [Produces("aplication/json")]
        public async Task<object> GetAddPesquisa(Pesquisa pesquisa)
        {
            await _IPesquisaRepository.AddAsync(pesquisa);
            return pesquisa;
        }

        [HttpPost("/api/UpdatePesquisa")]                // Metódo 
        [Produces("aplication/json")]
        public async Task<object> UpdatePesquisa(Pesquisa pesquisa)
        {
            await _IPesquisaRepository.UpdateAsync(pesquisa);

            return pesquisa;
        }


        [HttpGet("/api/PesquisaById")]                // Metódo 
        [Produces("aplication/json")]
        public async Task<object> GetPesquisaById(int id)
        {
            return await _IPesquisaRepository.GetByIdAsync(id);
           
        }

        [HttpDelete("/api/DeletePesquisa")]                // Metódo 
        [Produces("aplication/json")]
        public async Task<object> DeletePesquisa(int id)
        {
            try
            {
                var categoria = await _IPesquisaRepository.GetByIdAsync(id);
                await _IPesquisaRepository.DeleteAsync(categoria);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}


using DataAccess.Models;
using Business.Services.Depto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("get", Name = "GetEmpresaList")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var empresas = await _empresaService.GetEmpresa();
                return Ok(empresas);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("add", Name = "AddEmpresa")]
        public async Task<IActionResult> Add(Empresa empresa)
        {
            try
            {
                var newEmpresa = await _empresaService.AddEmpresa(empresa);
                return StatusCode(201, "Creado exitosamente");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{id}", Name = "GetEmpresa")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empresa = _empresaService.GetEmpresaId(id);
                return Ok(empresa);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

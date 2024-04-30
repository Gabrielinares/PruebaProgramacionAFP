using DataAccess.Models;
using Business.Services.Depto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService _departamentoService;
        private readonly IEmpresaService _empresaService;
        public DepartamentoController(IDepartamentoService departamentoService, IEmpresaService empresaService)
        {
            _departamentoService = departamentoService;
            _empresaService = empresaService;
        }

        [HttpGet("get", Name = "GetDepartamentoList")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var departamentos = await _departamentoService.GetDepartamentos();
                return Ok(departamentos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("add", Name = "AddDepartamento")]
        public async Task<IActionResult> Add(Departamento departamento)
        {
            try
            {
                Empresa emp = _empresaService.GetEmpresaId(departamento.IdEmpresa);

                if (emp == null)
                {
                    return BadRequest();
                }
                var newDepartamento = await _departamentoService.AddDepartamento(departamento);
                return StatusCode(201, "Creado exitosamente");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{id}", Name = "GetDepartamento")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Empresa emp =  _empresaService.GetEmpresaId(id);

                if(emp == null)
                {
                    return BadRequest();
                }

                var departamento = _departamentoService.GetDepartamentoId(id);

                if (departamento.Count == 0)
                {
                    return NotFound();
                }

                return Ok(departamento);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

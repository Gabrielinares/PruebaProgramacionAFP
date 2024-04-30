using DataAccess.Models;
using Business.Services.Depto;
using DataAccess.Repositories.Depto;

namespace Business.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository<Empresa> _repository;

        public EmpresaService(IEmpresaRepository<Empresa> repository)
        {
            _repository = repository;
        }

        public async Task<List<Empresa>> GetEmpresa()
        {
            try
            {
                return (List<Empresa>)await _repository.GetEmpresa();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Empresa> AddEmpresa(Empresa empresa)
        {
            try
            {
                return await _repository.AddEmpresa(empresa);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Empresa> EditEmpresa(Empresa empleado)
        {
            try
            {
                return await _repository.EditEmpresa(empleado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Empresa> EliminarEmpresa(int id)
        {
            try
            {
                return await _repository.DeleteEmpresa(id);
            }
            catch
            {
                throw;
            }
        }
        public Empresa GetEmpresaId(int id)
        {
            try
            {
                return _repository.GetEmpresaId(id);
            }
            catch
            {
                throw;
            }
        }

    }
}
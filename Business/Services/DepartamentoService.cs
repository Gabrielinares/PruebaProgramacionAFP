using DataAccess.Models;
using Business.Services.Depto;
using DataAccess.Repositories.Depto;

namespace Business.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository<Departamento> _repository;

        public DepartamentoService(IDepartamentoRepository<Departamento> repository)
        {
            _repository = repository;
        }

        public async Task<List<Departamento>> GetDepartamentos()
        {
            try
            {
                return (List<Departamento>)await _repository.GetDepartamento();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Departamento> AddDepartamento(Departamento empleado)
        {
            try
            {
                return await _repository.AddDepartamento(empleado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Departamento> EditDepartamento(Departamento empleado)
        {
            try
            {
                return await _repository.EditDepartamento(empleado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Departamento> EliminarDepartamento(int id)
        {
            try
            {
                return await _repository.DeleteDepartamento(id);
            }
            catch
            {
                throw;
            }
        }
        public List<Departamento> GetDepartamentoId(int id)
        {
            try
            {
                return _repository.GetDepartamentoId(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
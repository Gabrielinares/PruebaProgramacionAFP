using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Business.Services.Depto
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> GetDepartamentos();

        Task<Departamento> AddDepartamento(Departamento departamento);

        Task<Departamento> EditDepartamento(Departamento departamento);

        Task<Departamento> EliminarDepartamento(int id);

        List<Departamento> GetDepartamentoId(int id);
    }
}
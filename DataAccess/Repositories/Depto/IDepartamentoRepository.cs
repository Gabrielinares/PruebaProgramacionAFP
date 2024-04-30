using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories.Depto
{
    public interface IDepartamentoRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetDepartamento();

        Task<TModel> AddDepartamento(TModel departamento);

        Task<TModel> EditDepartamento(TModel departamento);

        Task<Departamento> DeleteDepartamento(int id);

        Departamento GetDepartamentoId(int id);
    }
}
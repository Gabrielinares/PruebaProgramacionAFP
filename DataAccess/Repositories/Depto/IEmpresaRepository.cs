using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories.Depto
{
    public interface IEmpresaRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetEmpresa();

        Task<TModel> AddEmpresa(TModel departamento);

        Task<TModel> EditEmpresa(TModel departamento);

        Task<Empresa> DeleteEmpresa(int id);

        Empresa GetEmpresaId(int id);
    }
}
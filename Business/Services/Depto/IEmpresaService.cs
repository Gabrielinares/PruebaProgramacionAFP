using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Business.Services.Depto
{
    public interface IEmpresaService
    {
        Task<List<Empresa>> GetEmpresa();

        Task<Empresa> AddEmpresa(Empresa empresa);

        Task<Empresa> EditEmpresa(Empresa empresa);

        Task<Empresa> EliminarEmpresa(int id);

        Empresa GetEmpresaId(int id);
    }
}
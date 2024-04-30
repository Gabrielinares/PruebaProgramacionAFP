using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repositories.Depto;
using Microsoft.EntityFrameworkCore;

namespace layer.access.Repositories
{
    public class DepartamentoRepository<TModel> : IDepartamentoRepository<TModel> where TModel : class
    {
        private readonly BDContext _dbcontext;
        public DepartamentoRepository(BDContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<TModel>> GetDepartamento()
        {
            try
            {
                await _dbcontext.SaveChangesAsync();

                return await _dbcontext.Set<TModel>().ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> AddDepartamento(TModel model)
        {
            try
            {
                _dbcontext.Add(model);
                _dbcontext.SaveChanges();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> EditDepartamento(TModel model)
        {
            try
            {
                _dbcontext.Update(model);
                _dbcontext.SaveChanges();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Departamento> DeleteDepartamento(int id)
        {
            try
            {
                Departamento e = await _dbcontext.Departamentos.FirstOrDefaultAsync(m => m.Id == id);

                if (e != null)
                {
                    _dbcontext.Departamentos.Remove(e);
                    _dbcontext.SaveChanges();
                }

                return e;
            }
            catch
            {
                throw;
            }
        }

        public Departamento GetDepartamentoId(int id)
        {
            try
            {
                return _dbcontext.Departamentos.FromSqlRaw("EXEC SP_OBTENER_DEPARTAMENTO_ID @p0", parameters: new[] {id.ToString()})
                        .AsEnumerable()
                        .FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
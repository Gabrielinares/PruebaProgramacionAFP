using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repositories.Depto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace layer.access.Repositories
{
    public class EmpresaRepository<TModel> : IEmpresaRepository<TModel> where TModel : class
    {
        private readonly BDContext _dbcontext;
        public EmpresaRepository(BDContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<TModel>> GetEmpresa()
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

        public async Task<TModel> AddEmpresa(TModel model)
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

        public async Task<TModel> EditEmpresa(TModel model)
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

        public async Task<Empresa> DeleteEmpresa(int id)
        {
            try
            {
                Empresa e = await _dbcontext.Empresas.FirstOrDefaultAsync(m => m.Id == id);

                if (e != null)
                {
                    _dbcontext.Empresas.Remove(e);
                    _dbcontext.SaveChanges();
                }

                return e;
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
                var result = _dbcontext.Empresas
                                    .FromSqlRaw($"EXEC SP_OBTENER_EMPRESA_ID @p0", parameters: new[] { id.ToString() })
                                    .AsEnumerable()
                                    .FirstOrDefault();

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
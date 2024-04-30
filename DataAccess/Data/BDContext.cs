using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
        }

        public BDContext()
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
    }
}
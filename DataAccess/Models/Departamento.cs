using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("DEPARTAMENTO")]
    public class Departamento
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_EMPRESA")]
        public int IdEmpresa { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("NRO_EMPLEADOS")]
        public int NumeroEmpleados { get; set; }

        [Column("NIVEL_ORGANIZACION")]
        public string NivelOrganizacion { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("EMPRESA")]
    public class Empresa
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("RAZON_SOCIAL")]
        public string RazonSocial { get; set; }

        [Column("FECHA_REGISTRO")]
        public DateTime FecRegistro { get; set; }

        [Column("DETALLE_BITACORA")]
        public string DetalleBitacora { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; }
    }
}

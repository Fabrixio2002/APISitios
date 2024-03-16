namespace APISitios.Models
{
    public class Sitios
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public Double Latitud { get; set; }
        public Double Longitud { get; set; }

        public required string Audio { get; set; }
        public required string Foto { get; set; }

    }
}

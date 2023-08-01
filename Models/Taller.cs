namespace API_TallerCapacitacion_SW.Models
{
    public class Taller
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CupoMaximo { get; set; }
        public List<Participante> Participantes { get; set; }
        public List<Asistencia> Asistencias { get; set; } 


    }
}

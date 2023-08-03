namespace API_TallerCapacitacion_SW.Models
{
    public class Asistencia
    {
        public int Id { get; set; }
        public Taller Taller { get; set; }
        public List<Participante> Participantes { get; set; }
        public DateTime FechaHora { get; set; }


    }
}

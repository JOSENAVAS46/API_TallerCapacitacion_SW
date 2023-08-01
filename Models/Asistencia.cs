namespace API_TallerCapacitacion_SW.Models
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int TallerId { get; set; }
        public Taller Taller { get; set; } 
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }
        public DateTime FechaHora { get; set; }


    }
}

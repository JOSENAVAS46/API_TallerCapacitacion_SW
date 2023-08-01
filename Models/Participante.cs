namespace API_TallerCapacitacion_SW.Models
{
    public class Participante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Email { get; set; }
        public List<Taller> Talleres { get; set; } 
        public List<Asistencia> Asistencias { get; set; } 


    }
}

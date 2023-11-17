namespace AnalisisProyecto.Models.DB
{
    public class ClassroomAvailability
    {

        public string Day { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClassroomId { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }

    }

}
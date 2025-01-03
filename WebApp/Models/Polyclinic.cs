namespace WebApp.Models
{
    public class Polyclinic
    {
        public int PolyclinicID { get; set; }
        public string PolyclinicName { get; set; }
        public string Image { get; set; }

        public ICollection<AppointmentDetails>? AppointmentsDetails { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}

namespace WebApp.Models
{
    public class Hour
    {
        public int HourID { get; set; }
        public string DateHouri { get; set; }
        public ICollection<AppointmentDetails> DateDetails { get; set; }
    }
}

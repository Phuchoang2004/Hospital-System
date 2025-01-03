namespace WebApp.Models
{
    public class Day
    {
        public int DayID { get; set; }
        public string DayName { get; set; }
        public ICollection<AppointmentDetails> DateDetails { get; set; }
    }
}

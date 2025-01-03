namespace WebApp.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string? DoctorName { get; set; }
        public int PolyclinicID { get; set; }
        public ICollection<Polyclinic>? Polyclinics { get; set; }
    }
}
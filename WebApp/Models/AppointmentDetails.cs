using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class AppointmentDetails
    {
        public int AppointmentDetailsID { get; set; }
        public int PolyclinicID { get; set; }
        [ForeignKey(nameof(AppointmentDetailsID))]
        public AppointmentDetails? Parent { get; set; }
        public int DayID { get; set; }
        public int HourID { get; set; }
        public bool DateStatus { get; set; }
        // Foreign keys for Doctor and Patient
        public int? DoctorID { get; set; }
        public int? PatientID { get; set; }
        [ForeignKey(nameof(DoctorID))]
        public User? Doctor { get; set; }
        [ForeignKey(nameof(PatientID))]
        public User? Patient { get; set; }
        [ForeignKey(nameof(DayID))]
        public Day? Day { get; set; }
        [ForeignKey(nameof(HourID))]
        public Hour? Hour { get; set; }
        public int RoomNumber { get; set; }
        [ForeignKey(nameof(RoomNumber))]
        public Room? Room { get; set; }

        public ICollection<AppointmentDetails>? DateDetails { get; set; }
        [ForeignKey(nameof(PolyclinicID))]
        public Polyclinic? Polyclinics { get; set; }
    }
}

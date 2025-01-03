namespace WebApp.Models
{
    public class Date
    {
        public int ID { get; set; }

        public int DoctorID { get; set; } 

        public int PatientID { get; set; }

        public int AppointmentDetailsID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool DidUserArrive { get; set; }

        // Navigation properties
        public User? Doctor { get; set; } // Navigation property for Doctor

        public User? Patient { get; set; } // Navigation property for Patient

        public AppointmentDetails? AppointmentDetails { get; set; }

    }
}
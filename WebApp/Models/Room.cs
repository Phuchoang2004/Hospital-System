using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }
        public string Status { get; set; }
        public int PolyclinicID { get; set; }
        public Polyclinic Polyclinic { get; set; }
    }
}

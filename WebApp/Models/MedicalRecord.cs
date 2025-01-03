using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class MedicalRecord
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        [ValidateNever]
        public User User { get; set; }
        public string Detail { get; set; }

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApp.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nameres { get; set; }

        public ICollection<Date>? Appointments { get; set; }

        [ValidateNever]
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
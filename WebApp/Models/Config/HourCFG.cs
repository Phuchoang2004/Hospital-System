using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class HourCFG : IEntityTypeConfiguration<Hour>
    {
        public void Configure(EntityTypeBuilder<Hour> builder)
        {
            builder.HasData(
                new Hour { HourID = 1, DateHouri = "10:00 AM" },
                new Hour { HourID = 2, DateHouri = "11:00 AM" },
                new Hour { HourID = 3, DateHouri = "12:00 PM" },
                new Hour { HourID = 4, DateHouri = "1:00 PM" },
                new Hour { HourID = 5, DateHouri = "2:00 PM" },
                new Hour { HourID = 6, DateHouri = "3:00 PM" },
                new Hour { HourID = 7, DateHouri = "4:00 PM" }
            );
        }
    }
}
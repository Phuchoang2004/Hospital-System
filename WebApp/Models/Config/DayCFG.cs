using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class DayCFG : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.HasData(
                new Day { DayID = 1, DayName = "Monday" },
                new Day { DayID = 2, DayName = "Tuesday" },
                new Day { DayID = 3, DayName = "Wednesday" },
                new Day { DayID = 4, DayName = "Thursday" },
                new Day { DayID = 5, DayName = "Friday" }
            );
        }
    }
}
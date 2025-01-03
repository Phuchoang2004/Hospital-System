using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class PolyclinicCFG : IEntityTypeConfiguration<Polyclinic>
    {
        public void Configure(EntityTypeBuilder<Polyclinic> builder)
        {
            builder.HasData(
                new Polyclinic { PolyclinicID = 1, PolyclinicName = "Ear, Nose, and Throat", Image = "image1.jpg" },
                new Polyclinic { PolyclinicID = 2, PolyclinicName = "General Surgery", Image = "image2.jpg" },
                new Polyclinic { PolyclinicID = 3, PolyclinicName = "Eye", Image = "image3.jpg" }
            );
        }
    }
}
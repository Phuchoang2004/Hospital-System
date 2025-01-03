using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Config;
using WebApplication1.Models;

namespace WebApp.DAL
{
    //public class LibraryDB:IdentityDbContext
    public class hospitalDB : IdentityDbContext<User, Rol, int>
    {
        public hospitalDB(DbContextOptions<hospitalDB> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roller { get; set; }

        public DbSet<Polyclinic> Polyclinics { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<AppointmentDetails> DateDetails { get; set; }
        public DbSet<Date> Appointments { get; set; }
        public DbSet<Date_VM> date_VMs { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration<Author>(new AuthorCFG());
            //builder.ApplyConfiguration<Book>(new BookCFG());
            //builder.ApplyConfiguration<Rol>(new RolCFG());

            builder.ApplyConfiguration<Day>(new DayCFG());
            builder.ApplyConfiguration<Hour>(new HourCFG());
            builder.ApplyConfiguration<Polyclinic>(new PolyclinicCFG());
            builder.ApplyConfiguration<Rol>(new RolCFG());

            base.OnModelCreating(builder);
            builder.Entity<MedicalRecord>()
           .HasOne(m => m.User)
           .WithMany(u => u.MedicalRecords)
           .HasForeignKey(m => m.UserID)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MedicalRecord>().HasData(
            new MedicalRecord
            {
                ID = 1,
                UserID = 1,
                Detail = "Has high blood pressure"
            },
            new MedicalRecord
            {
                ID = 2,
                UserID = 1,
                Detail = "Thang nay bi benh dep trai giai doan cuoi, dep trai ko the chua dc, noi chung la vay!"
            });

            builder.Entity<Polyclinic>()
            .HasMany(p => p.Rooms)
            .WithOne(r => r.Polyclinic)
            .HasForeignKey(r => r.PolyclinicID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Room>().HasData(
        new Room { RoomNumber = 101, Status = "Available", PolyclinicID = 1 },
        new Room { RoomNumber = 102, Status = "Available", PolyclinicID = 1 },
        new Room { RoomNumber = 201, Status = "Available", PolyclinicID = 2 },
        new Room { RoomNumber = 202, Status = "Available", PolyclinicID = 2 },
        new Room { RoomNumber = 301, Status = "Available", PolyclinicID = 3 },
        new Room { RoomNumber = 302, Status = "Available", PolyclinicID = 3 }
    );
            builder.Entity<AppointmentDetails>().HasData(
        new AppointmentDetails
        {
            AppointmentDetailsID = 1,
            PolyclinicID = 1,
            DayID = 1,
            HourID = 1, 
            RoomNumber = 101,
            DateStatus = true
        },
        new AppointmentDetails
        {
            AppointmentDetailsID = 2,
            PolyclinicID = 1,
            DayID = 1, 
            HourID = 2, 
            RoomNumber = 102,
            DateStatus = true 
        },
        new AppointmentDetails
        {
            AppointmentDetailsID = 3,
            PolyclinicID = 2,
            DayID = 2, 
            HourID = 3,
            RoomNumber = 201,
            DateStatus = true
        },
        new AppointmentDetails
        {
            AppointmentDetailsID = 4,
            PolyclinicID = 2,
            DayID = 2, 
            HourID = 4,  
            RoomNumber = 202,
            DateStatus = true 
        },
        new AppointmentDetails
        {
            AppointmentDetailsID = 5,
            PolyclinicID = 3,
            DayID = 3,
            HourID = 3,
            RoomNumber = 301,
            DateStatus = true
        },
        new AppointmentDetails
        {
            AppointmentDetailsID = 6,
            PolyclinicID = 2,
            DayID = 3,
            HourID = 4,
            RoomNumber = 302,
            DateStatus = true
        }
        );

            builder.Entity<AppointmentDetails>()
            .HasOne(ad => ad.Doctor)
            .WithMany()
            .HasForeignKey(ad => ad.DoctorID)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppointmentDetails>()
                .HasOne(ad => ad.Patient)
                .WithMany()
                .HasForeignKey(ad => ad.PatientID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<AppointmentDetails>()
            .HasOne(ad => ad.Day)
            .WithMany(d => d.DateDetails)
            .HasForeignKey(ad => ad.DayID)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppointmentDetails>()
                .HasOne(ad => ad.Hour)
                .WithMany(h => h.DateDetails)
                .HasForeignKey(ad => ad.HourID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppointmentDetails>()
                .HasOne(ad => ad.Room)
                .WithMany()
                .HasForeignKey(ad => ad.RoomNumber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppointmentDetails>()
                .HasOne(ad => ad.Polyclinics)
                .WithMany(p => p.AppointmentsDetails)
                .HasForeignKey(ad => ad.PolyclinicID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Date>()
                .HasOne(d => d.Doctor)
                .WithMany()
                .HasForeignKey(d => d.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Date>()
                .HasOne(d => d.Patient)
                .WithMany()
                .HasForeignKey(d => d.PatientID)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

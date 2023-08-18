using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HR_System.Models
{
    public class HREntity : DbContext
    {
        public HREntity()
        {

        }
        public HREntity(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<GroupPermissions> GroupPermissions { get; set; }
        public DbSet<OfficialVocations> OfficialVocations { get; set; }
        public DbSet<Permissions> Permissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneralSettings>()
                .HasData(new GeneralSettings {ID=1, Add_hours = 100, Sub_hours = 100, vacation1 = "Friday", vacation2 = "Saturday" });

            modelBuilder.Entity<GroupPermissions>()
                .HasKey(ea => new { ea.GroupID, ea.PermissionID });
        }
    }
}

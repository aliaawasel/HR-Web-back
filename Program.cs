
using HR_System.Models;
using HR_System.Repositories.Attendance;
using HR_System.Repositories.Department;
using HR_System.Repositories.Employee;
using HR_System.Repositories.GeneralSettings;
using HR_System.Repositories.Group;
using HR_System.Repositories.Official_Vocations;
using HR_System.Repositories.Salary;
using HR_System.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HR_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HREntity>(Options=>Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IGeneralSettingsRepository, GeneralSettingsRepository>();
            builder.Services.AddScoped<IAttendenceRepository, AttendenceRepository>();
            builder.Services.AddScoped<IOfficialVocationsRepository, OfficialVocationsRepository>();
            builder.Services.AddScoped<ISalaryReportRepository, SalaryReportRepository>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowingAPIClientsAccess", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowingAPIClientsAccess");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
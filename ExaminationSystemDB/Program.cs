
using ExaminationSystemDB.MapperConfig;
using ExaminationSystemDB.Models;
using ExaminationSystemDB.Repositories;
using ExaminationSystemDB.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers();
            builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddDbContext<ExamContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
            builder.Services.AddAutoMapper(typeof(MapConfig));
            builder.Services.AddOpenApi();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

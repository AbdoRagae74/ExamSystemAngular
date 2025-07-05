
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

            string corsText = "";
            builder.Services.AddControllers();
            builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddDbContext<ExamContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
            builder.Services.AddAutoMapper(typeof(MapConfig));
            builder.Services.AddOpenApi();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsText, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(corsText);

            app.MapControllers();

            app.Run();
        }
    }
}

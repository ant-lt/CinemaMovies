using CinemaMovies.Data;
using CinemaMovies.Repositories.IRepository;
using CinemaMovies.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Reflection;
using CinemaMovies.Service;

namespace CinemaMovies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            builder.Services.AddDbContext<CinemaMoviesContext>(option =>
            {
                option.UseSqlite(builder.Configuration.GetConnectionString("MySQLiteConnection"));
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserWrapper, UserWrapper>();

            builder.Services.AddControllers()
                .AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // papildomai swager dokumentacijai. Reikia projekte uzdeti varnele prie Output: Documentation file -> Generate a file containing API documentation.
            builder.Services.AddSwaggerGen(option =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);

            });

                var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using ALSiteBack.Data;
using ALSiteBack.Interfaces;
using ALSiteBack.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ALSiteBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IActualDateRepository, ActualDateRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();

            /*
             * builder.Services.AddCors(options =>
                    {
                        options.AddPolicy("AllowSpecificOrigin",
                            builder => builder.WithOrigins("file:///C:/Users/%D0%9A%D0%BE%D0%BC%D0%BF%D1%8C%D1%8E%D1%82%D0%B5%D1%80/Desktop/front/index.html") // Замените на ваш домен
                                                .AllowAnyHeader()
                                                .AllowAnyMethod());
                    });*/

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalFile",
                    builder => builder.AllowAnyOrigin() // Это может быть небезопасно для продакшена
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();
            app.UseCors("AllowLocalFile");
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

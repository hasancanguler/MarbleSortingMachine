
using MarbleSortingMachine.Infrastructure.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Arm;
using MarbleSortingMachine.Infrastructure.Interfaces.Container;
using MarbleSortingMachine.Infrastructure.Interfaces.Marble;
using MarbleSortingMachine.Infrastructure.Interfaces.Services.Container;
using MarbleSortingMachine.Infrastructure.Marble;
using MarbleSortingMachine.Infrastructure.Services.Arm;
using MarbleSortingMachine.Infrastructure.Services.Container;

namespace MarbleSortingMachineAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IContainerGenerator, ContainerGenerator>();
            builder.Services.AddScoped<IContainerService, ContainerService>();
            builder.Services.AddScoped<IMarbleGenerator, MarbleGenerator>();
            builder.Services.AddScoped<IArmService, ArmService>();
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

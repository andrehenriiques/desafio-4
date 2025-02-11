

using Desafio4.Application.Services;
using Desafio4.Data.Rest.Repository;
using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Interfaces.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonService, PersonService>();
const string baseUrl = "https://viacep.com.br/ws"; // ou outro valor configurado dinamicamente
EventHandler? onUnauthorizedResponse = (sender, args) =>
{
    Console.WriteLine("Resposta não autorizada!");
};

builder.Services.AddScoped<IViaCepRepository>(provider =>
    new ViaCepRepository(baseUrl, onUnauthorizedResponse)
);

builder.Services.AddScoped<IAddressService, AddressService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // Mapear os controladores
});

app.Run();
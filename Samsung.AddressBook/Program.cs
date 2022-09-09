using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Samsung.AddressBook.DataAccess;
using Samsung.AddressBook.Api;
using Samsung.AddressBook.Application.Interops;
using Samsung.AddressBook.DataAccess.Interops;
using Samsung.AddressBook.DataAccess.Interops.Repositories;
using Samsung.AddressBook.DataAccess.Repositories;
using Samsung.AddressBook.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(Assembly.GetAssembly(typeof(ControllersAssembly))!);

builder.Services.AddDbContext<DataContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddScoped<IDataContext, DataContext>();

builder.Services.AddScoped<IPhonesRepository, PhonesRepository>();
builder.Services.AddScoped<IPhonesService, PhonesService>();

builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();
builder.Services.AddScoped<IAddressesService, AddressesService>();

builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IContactsService, ContactsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsDefault", builder =>
{
    builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsDefault");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
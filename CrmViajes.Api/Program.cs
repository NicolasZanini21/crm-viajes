using CrmViajes.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularDev", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("AngularDemo", policy =>
    {
        policy.WithOrigins("https://crm-viajes-demo.netlify.app")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CrmViajesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// En todo entorno que NO sea desarrollo local (es decir, la demo pública
// desplegada), bloqueamos DELETE y PUT para que nadie pueda borrar o editar
// datos desde afuera. En desarrollo local (dotnet run sin más) el CRUD
// sigue completo.
if (!app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        if (HttpMethods.IsDelete(context.Request.Method) || HttpMethods.IsPut(context.Request.Method))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Esta es una demo pública de solo lectura/alta. Editar y eliminar están deshabilitados."
            });
            return;
        }
        await next();
    });
}

app.UseHttpsRedirection();

app.UseCors(app.Environment.IsDevelopment() ? "AngularDev" : "AngularDemo");

app.MapControllers();

app.Run();

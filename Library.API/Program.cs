using Library.API.Data;
using Library.API.Services.Author;
using Library.API.Services.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Joselito Machado",
            Email = "opaguelosantos@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/joselitomachado/")
        }
    });

    var xmlFile = "Library.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<IAuthorInterface, AuthorService>();
builder.Services.AddScoped<IBookInterface, BookService>();

builder.Services.AddRouting(options => options.LowercaseUrls = false);

builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryCs"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

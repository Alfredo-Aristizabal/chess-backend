using ChessBackend;
using ChessBackend.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGraphQLServer().AddQueryType<UserData>().AddProjections().AddFiltering().AddSorting();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", b =>
{
    b.WithOrigins("http://localhost:3000")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddDbContext<ChessBackendDbContext>(options => options.UseNpgsql("name=DefaultConnection"));
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();
app.MapGraphQL("/graphql");

app.Run();

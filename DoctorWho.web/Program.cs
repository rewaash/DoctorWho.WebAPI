using DoctorWho.Db.DAL;
using DoctorWho.Db.Repositories.AuthorRepository;
using DoctorWho.Db.Repositories.DoctorRepository;
using DoctorWho.Db.Repositories.EpisodeRepository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
  //.AddFluentValidation(S => S.RegisterValidatoresFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DoctorWhoCoreDbContext>(dbContextBuilder => dbContextBuilder
.UseSqlServer(builder.Configuration["ConnectionStrings:DbContextConnectionString"]));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using DoctorWho.Db.DAL;
using DoctorWho.Db.Repositories.DoctorRepository;
using FluentValidation;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
  //.AddFluentValidation(S => S.RegisterValidatoresFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DoctorWhoCoreDbContext>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

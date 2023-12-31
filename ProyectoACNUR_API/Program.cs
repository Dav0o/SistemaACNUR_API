using DataAccess;
using Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccess.Model;

var builder = WebApplication.CreateBuilder(args);

//Add external services
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

//builder.Services.AddDbContext<AcnurContext>(options =>
//{
//    options.UseSqlServer("Server=DAVID\\SQLEXPRESS;Database=ACNUR;Trusted_Connection=True;TrustServerCertificate=True");
//});
// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
app.UseCors("NgOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

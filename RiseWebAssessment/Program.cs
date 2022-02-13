global using RiseWebAssessment.Data;
global using Microsoft.EntityFrameworkCore;
global using Npgsql;
using RiseWebAssessment.Service.ServiceAbstracts;
using RiseWebAssessment.Service.ServiceConcretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddControllers();
//sync problem
//builder.Services.AddTransient<DataContext>();
builder.Services.AddDbContext<DataContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
//builder.Services.AddDbContext<DataContext>(options => {
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDistributedRedisCache(options => {
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    //options.Configuration = builder.Configuration["Redis"];
    //options.InstanceName = "redisCache";
});
//builder.Services.AddStackExchangeRedisCache(options => {
//    options.Configuration = options.Configuration = builder.Configuration["Redis"];
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Time problem
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

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

using Microsoft.EntityFrameworkCore;
using Serilog;
using Tickets.API.DbContexts;
using Tickets.API.Services;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/ticket.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TicketContext>(
    dbContextOptions => dbContextOptions
    .UseSqlite(builder.Configuration["ConnectionStrings:TicketDBConnectionString"]));

builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddScoped<IMessageProducer, MessageProducer>();

builder.Services.AddHttpClient<ICityInfoService, CityInfoService>(c =>
               c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CityInfo:Uri"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

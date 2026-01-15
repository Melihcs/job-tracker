using JobTracker.Modules.Applications;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddApplicationPart(ApplicationsModule.Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationsModule(builder.Configuration);

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

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Bật Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; // Truy cập tại http://localhost:5000/swagger
});

// **Tự động mở Swagger khi chạy API**
var url = "http://localhost:5276/swagger";
Process.Start(new ProcessStartInfo
{
    FileName = url,
    UseShellExecute = true
});
var reactProcess = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "powershell",
        Arguments = "-NoExit -Command \"Start-Process cmd -ArgumentList '/k cd ../web-client && npm install && npm run dev'\"",
        UseShellExecute = true
    }
};
reactProcess.Start();
app.Run();

using System.Text;
using API;
using API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add Application Services
builder.Services.AddApplicationServices(builder.Configuration);
//Add Identity Services
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();


app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithOrigins(
    "http://localhost:4200", "https://localhost:4200"
));

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

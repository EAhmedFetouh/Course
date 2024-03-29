using Microsoft.EntityFrameworkCore;
using TranningApp.API.Data;
using TranningApp.API.IRepository;
using TranningApp.API.Repository;
 using Microsoft.IdentityModel.Tokens;
 using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using TranningApp.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x=>x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors();
builder.Services.AddScoped<IAuthRepository , AuthRepository>();
builder.Services.AddTransient<TrialData>();

builder.Services.AddScoped<IZawajRepository,ZawajRepository>();
 builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options=>{
    options.TokenValidationParameters =  new TokenValidationParameters{
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes
        (builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer=false,
        ValidateAudience=false
    };
 });



 var app = builder.Build();
  // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler(BuilderExtentions=>{
        BuilderExtentions.Run(async context=> 
        {
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
            var error = context.Features.Get<IExceptionHandlerFeature>();
            if(error != null){
                context.Response.AddApplicationError(error.Error.Message);
                await context.Response.WriteAsync(error.Error.Message);            }
        });
    });
}


app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

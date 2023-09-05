using ApiComIdentity.Authorization;
using ApiComIdentity.Data;
using ApiComIdentity.Models;
using ApiComIdentity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("20931401EWIYEWF973HFUP3YF98Y8983YFEI839POWFJB23984")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
}); 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("VerificarIdade", options => options.AddRequirements(new VerificarIdade(18)));
});





var conexao = builder.Configuration.GetConnectionString("UsuarioConnection");
builder.Services.AddDbContext<UsuarioDbContext>(
        opts =>
        {
            opts.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
        }
    );

builder.Services.
    AddIdentity<Usuario, IdentityRole>().
    AddEntityFrameworkStores<UsuarioDbContext>().
    AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

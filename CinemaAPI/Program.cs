using CinemaAPI.Data;
using CinemaAPI.Repository;
using CinemaAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inject DB connection service
builder.Services.AddDbContext<CinemaDbContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("CinemaDB"));
});


//Add scope for interfaces (when you call the interface then the class is implemented instead)
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//responses can be delivered in xml format if specified on the header (json still default)
builder.Services.AddMvc().AddXmlSerializerFormatters();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Tokens:Issuer"],
                        ValidAudience = builder.Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"])),
                        ClockSkew = TimeSpan.Zero,
                    };
                });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (var scope = app.Services.CreateScope()) {
//    var dbContext = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
//    dbContext.Database.EnsureCreated();
//}

app.UseStaticFiles();

app.UseHttpsRedirection();
//For JWT needs to be before use authorization
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices {
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection) {
        serviceCollection.AddEntityFrameworkMySQL();
        new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
            .TryAddCoreServices();
    }
}

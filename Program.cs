using CriticalConditionBackend.CriticalConditionExceptions;
using CriticalConditionBackend.Services;
using CriticalConditionBackend.Utillities;
using CriticalConditionBackend.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<CriticalConditionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CriticalConditionDB")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = TokenUtilities.GetTokenValidationParameters(builder.Configuration);

                });

builder.Services.AddScoped<ISuperUserServices, SuperUserServices>();
builder.Services.AddScoped<ISubUserServices, SubUserServices>();

builder.Services.AddControllers(options =>
    options.Filters.Add(new HttpResponseExceptionFilter()));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod();
                          policy.WithOrigins("https://jolly-wave-0a1368003.1.azurestaticapps.net").AllowAnyHeader().AllowAnyMethod();
                      });
});

//--------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

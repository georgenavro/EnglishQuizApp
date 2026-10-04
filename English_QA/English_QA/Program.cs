global using English_QA.Middleware;
global using English_QA.Pagination;
global using English_QA.Repositories;
global using English_QA.Globals;
global using English_QA.Seeders;
using English_QA.Models;
using English_QA.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using English_QA.Models.DatabaseModels;
using English_QA.Interface;

if (!Directory.Exists(Variables.DatabaseDirectory))
{
    Directory.CreateDirectory(Variables.DatabaseDirectory);
}

if (!File.Exists(Variables.DatabasePath))
{
    var db = File.Create(Variables.DatabasePath);
    db.Close();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Swagger Authorization
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(x => x.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Please enter a valid Token",
        Name = "Authorization",
        BearerFormat = "jwt",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme{Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,Id = "Bearer" } },
            new string[]{}
         }});
});
//Connect to DB
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlite(Variables.connectionString);
});
//Migrate
var serviceProvider = builder.Services.BuildServiceProvider();
var dbContext = serviceProvider.GetRequiredService<DBContext>();
dbContext.Database.Migrate();
DbSetInitializer.Initializer(dbContext);
//Pagination conf
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<UriService>(o => { 
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor?.HttpContext?.Request;
    var uri = string.Concat(request?.Scheme,"://",request?.Host.ToUriComponent());
    return new UriService(uri);
        });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Injection
builder.Services.AddScoped<AnswerTypeRepo>();
builder.Services.AddScoped<QARepo>();
builder.Services.AddScoped<UsersRepo>();
builder.Services.AddScoped<UserTypeRepo>();
builder.Services.AddScoped<QuestionCategoryRepo>();
builder.Services.AddScoped<TestResultsRepo>();
builder.Services.AddScoped<UserTestRepo>();
//Auth
var jwtSettings = builder.Configuration.GetSection("jwtSettings").Get<JWTSettings>();
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(Options =>
    {
        Options.RequireHttpsMetadata = false;
        Options.SaveToken = true;
        Options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JWTSettings.Issuer,
            ValidAudience = JWTSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTSettings.SecurityKey)),
            ClockSkew = TimeSpan.Zero

        };
    });
//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Add this ONLY if you’re using cookies/auth
    });
});


var app = builder.Build();
Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

// Add this BEFORE any controller middleware
app.UseCors("LocalFrontend");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:8095");

using Api.Contexts;
using Api.Helpers.Repositories;
using Api.Helpers.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Data")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));
#endregion

#region Repositories
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<UserProfileRepository>();
builder.Services.AddScoped<CommentRepository>();
#endregion

#region services
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
#endregion

#region Authentication
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{ options.User.RequireUniqueEmail = true; })
	.AddEntityFrameworkStores<IdentityContext>()
	.AddDefaultTokenProviders();


builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(x =>
{
	x.Events = new JwtBearerEvents
	{
		OnTokenValidated = context =>
		{
			//if (string.IsNullOrEmpty(context?.Principal?.Identity?.Name))
			//    context?.Fail("Unauthorized");

			return Task.CompletedTask;
		}
	};

	x.RequireHttpsMetadata = true;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidIssuer = builder.Configuration.GetSection("TokenValidation").GetValue<string>("Issuer")!,
		ValidateAudience = true,
		ValidAudience = builder.Configuration.GetSection("TokenValidation").GetValue<string>("Audience")!,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!))
	};
});
#endregion

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

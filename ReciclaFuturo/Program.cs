using Fiap.Api.Alunos.Repositories;
using Fiap.Api.Alunos.Services;
using Fiap.Api.Alunos.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

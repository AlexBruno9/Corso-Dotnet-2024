using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcAuthApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)


//  AGGIUNGERE UN RUOLO

.AddRoles<IdentityRole>()       //  ASSICURATI DI AVERE QUESTO PER ABILITARE IL SUPPORTO AI RUOLI 



    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


//  CREA UN AMBITO DI SERVIZIO

//  QUESTE DICHIARAZIONI SONO DA 'COPIA-INCOLLA' QUANDO VUOI ABILITARE L'UTILIZZO DEI RUOLI

using(var scope=app.Services.CreateScope())
{
    var services= scope.ServiceProvider;

    try
    {

        //  RISOLVI IL ROLE MANAGER DAL PROVIDER DI SERVIZI
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        //  CHIAMATA AL METODO PER ASSICURARSI CHE I RUOLI ESISTANO
        await ApplicationDbInitializer.EnsureRolesAsync(roleManager);
    }

    catch(Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante la creazione dei ruoli");
    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();



//  AGGIUNGO CREAZIONE DEI RUOLI ALL'INTERNO DEL DATABASE

public static class ApplicationDbInitializer
{
    public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string> {"Admin", "User"};
        foreach(var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}

//  ADESSO DEVO CREARE ACCOUNTCONTROLLER.CS 




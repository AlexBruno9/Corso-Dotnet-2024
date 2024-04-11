# APP BraniMVC

1. Generazione del Progetto
Apri un terminale e naviga alla directory dove desideri creare il tuo progetto. Utilizza il seguente comando per generare un nuovo progetto MVC con autenticazione individuale:

```bash
dotnet new mvc --auth Individual -o BraniMVC
```

2. Configurazione del Progetto

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

3.Nella cartella Models, crea un nuovo file chiamato AppUser.cs e definisci il modello come segue:

```csharp
using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    // Aggiungi qui le proprietà personalizzate per i fornitori
    public string Nome { get; set; }
    public string Codice { get; set; }
    public bool Stato { get; set; }
}
```

4. aggiornare ApplicationDbContext per utilizzare il nuovo modello utente esteso invece di IdentityUser. Troverai ApplicationDbContext nella cartella Data

```csharp
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Se necessario, puoi aggiungere DbSet per altri modelli qui
}
```

5. Migrazione ed Aggiornamento del Database

Contesto ApplicationDbContext

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
6. Program.cs

```csharp
using Microsoft.AspNetCore.Identity; 
using Microsoft.EntityFrameworkCore;
using BraniMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
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
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "user",
		pattern: "User/{email}",
		defaults: new { controller = "Users", action = "Index" });
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Seeding del database
using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
		var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
		await SeedData.InitializeAsync(userManager, roleManager);
	}
	catch (Exception ex)
	{
		var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "Un errore è avvenuto durante il seeding del database.");
	}
}

app.Run();
```

7. SeedData.cs

```csharp
using Microsoft.AspNetCore.Identity; 

public class SeedData
{
	public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		// Creazione dei ruoli se non esistono
		string[] roleNames = { "Admin", "Fornitore", "Cliente" };
		foreach (var roleName in roleNames)
		{
			if (!await roleManager.RoleExistsAsync(roleName))
			{
				await roleManager.CreateAsync(new IdentityRole(roleName));
			}
		}

		// Creazione dell'utente Admin se non esiste
		if (await userManager.FindByEmailAsync("fdfdf@∂fdf.com") == null)
	  {
		  var adminUser = new AppUser
		  {
			  UserName = "admin@admin.com",
			  Email = "admin@admin.com",
			  Nome = "Admin",
			  Codice = "12345678", // Genera un codice fornitore univoco per ogni fornitore
			  EmailConfirmed = true // Accettazione in automatico
		  };
		  await userManager.CreateAsync(adminUser, "AdminPass1!");
		  await userManager.AddToRoleAsync(adminUser, "Admin");
	  }
	  else
	  {
		  var adminUser = await userManager.FindByEmailAsync("fdfdf@∂fdf.com");
		  await userManager.AddToRoleAsync(adminUser, "Admin");
	  }
	  
	  
			  

		
	}
}
```

8. Modifica del file _LoginPartial.cshtml

```html
@using Microsoft.AspNetCore.Identity
@inject SignInManager<AppUser> SignInManager
@inject UserManager<AppUser> UserManager
@{
    var user = await UserManager.GetUserAsync(User);
    var ruoli = await UserManager.GetRolesAsync(user);
}
```

9. scaffolding di identity ed assegnazione ruolo fornitore in automatico

```bash
dotnet aspnet-codegenerator identity -dc BraniMVC.Data.ApplicationDbContext --files "Account.Register"
```

oppure ogni files

```bash
dotnet aspnet-codegenerator identity -dc BraniMVC.Data.ApplicationDbContext --files "all"
```

10. Modifica del file Register.cshtml.cs

```csharp
// Licensed to the .NET Foundation under one or more agreements. 
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BraniMVC.Areas.Identity.Pages.Account
{
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly IUserStore<IdentityUser> _userStore;
		private readonly IUserEmailStore<IdentityUser> _emailStore;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;

		public RegisterModel(
			UserManager<AppUser> userManager,
	SignInManager<AppUser> signInManager,
	ILogger<RegisterModel> logger,
	IEmailSender emailSender)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[BindProperty]
		public InputModel Input { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string ReturnUrl { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public class InputModel
		{
			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

			[Required]
			[Display(Name = "Nome")]
			public string Nome { get; set; }

			[Display(Name = "Codice Fornitore")]
			public string Codice { get; set; }

			[Required]
			[Display(Name = "Stato Attivo")]
			public bool Stato { get; set; }



		}
		
		// metodo per la creazione di un codice fornitore di 8 caratteri in automatico numeri ed caratteri maiuscoli ed minuscoli 
		public string SetCodice()
		{
			string Codice = "";
			Random random = new Random();
			for (int i = 0; i < 8; i++)
			{
				int casuale = random.Next(0, 3);
				switch (casuale)
				{
					case 0:
						Codice += (char)random.Next(48, 58);
						break;
					case 1:
						Codice += (char)random.Next(65, 91);
						break;
					case 2:
						Codice += (char)random.Next(97, 123);
						break;
				}
			}
			return Codice;
		}
		
		public async Task OnGetAsync(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)

		{
			returnUrl = returnUrl ?? Url.Content("~/");
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			if (ModelState.IsValid)
			{
				var user = new AppUser { UserName = Input.Email, Email = Input.Email, Nome = Input.Nome, Codice = SetCodice(), Stato = Input.Stato };
				var result = await _userManager.CreateAsync(user, Input.Password);
				if (result.Succeeded)
				{
					// Assegna il ruolo "Fornitore" all'utente
					await _userManager.AddToRoleAsync(user, "Cliente");
					
					// assegna un codice fornitore di 8 caratteri in automatico con il metodo SetCodice
					SetCodice();
					await _userManager.UpdateAsync(user);

					_logger.LogInformation("User created a new account with password.");

					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
						protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
						$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					if (_userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
					}
					else
					{
						await _signInManager.SignInAsync(user, isPersistent: false);
						return LocalRedirect(returnUrl);
					}
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}
```

11. Modifica del file Register.cshtml

```html
@page 
@model RegisterModel
@{
    ViewData["Title"] = "Register";
}

<h1>@ViewData["Title"]</h1>
<div class="row">
    <div class="col-md-4">
        <form id="account" method="post">
            <h4>Create a new account.</h4>
            <hr />
            <div asp-validation-summary="All" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Input.Email"></label>
                <input asp-for="Input.Email" class="form-control" />
                <span asp-validation-for="Input.Email" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Input.Nome"></label>
                <input asp-for="Input.Nome" class="form-control" />
                <span asp-validation-for="Input.Nome" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Input.Codice"></label>
                <input asp-for="Input.Codice" class="form-control" />
                <span asp-validation-for="Input.Codice" class="text-danger"></span>
            </div>
            
            <div class="form-group">
                <label asp-for="Input.Password"></label>
                <input asp-for="Input.Password" class="form-control" />
                <span asp-validation-for="Input.Password" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Input.ConfirmPassword"></label>
                <input asp-for="Input.ConfirmPassword" class="form-control" />
                <span asp-validation-for="Input.ConfirmPassword" class="text-danger"></span>
            </div>
            <button type="submit" class="btn btn-primary">Register</button>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

12. creare un'area riservata per i fornitori

creare un'area riservata per i fornitori in cui ogni fornitore ha la propria rotta identificata da un CodiceFornitore unico, e una pagina accessibile digitando il CodiceFornitore (anche da parte di clienti non fornitori), dovrai seguire alcuni passaggi. Questa funzionalità implica l'implementazione di una logica di routing personalizzata e la gestione dell'accesso basata sui ruoli e sui codici fornitori

in UsersController.cs in Controllers

```csharp
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BraniMVC.Models;
using BraniMVC.Data;
using System.Linq;

public class UsersController : Controller
{

	private readonly ApplicationDbContext _context;
	private readonly UserManager<AppUser> _userManager;

	public UsersController(ApplicationDbContext context, UserManager<AppUser> userManager)
	{
		_context = context;
		_userManager = userManager;
	}

	// metodo per visualizzare i dettagli di un fornitore
	[Authorize]
	public IActionResult Index(string email)
	{
		var fornitore = _context.Users.FirstOrDefault(u => u.Email == email);
		if (fornitore == null)
		{
			return NotFound();
		}
		return View(fornitore);
	}

	// metodo per attivare/disattivare un fornitore
	[Authorize(Roles = "Admin")]
	[HttpPost]
	public async Task<IActionResult> ToggleActive(string id)
	{
		var fornitore = await _userManager.FindByIdAsync(id);
		if (fornitore == null)
		{
			return NotFound();
		}

		fornitore.Stato = !fornitore.Stato;
		await _userManager.UpdateAsync(fornitore);

		return RedirectToAction(nameof(Index), new { email = fornitore.Email });
	}

}
```

Nella cartella Views/Users, crea una vista Index.cshtml

la vista Index.cshtml mostra i dati dell'utente, inclusi il nome, lo stato attivo e il codice fornitore. Inoltre, se l'utente è un amministratore, verrà visualizzato un pulsante per attivare o disattivare l'utente

```html
@model AppUser 
@{
    ViewData["Title"] = "User";

    var stato = Model.Stato ? "Attivo" : "Disattivo";
    var colore = Model.Stato ? "green" : "red";
    var icona = Model.Stato ? "fa-check" : "fa-times";

    ViewData["Icona"] = icona;
    ViewData["Colore"] = colore;
    ViewData["Stato"] = stato;
}

<h1>@Model.Nome</h1>
<div class="row">
    <div class="col-md-6">
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Dettagli</h3>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label>Nome</label>
                    <p>@Model.Nome</p>
                </div>
                <div class="form-group">
                    <label>Stato</label>
                    <p style="color:@ViewData["Colore"]"><i class="fa @ViewData["Icona"]"></i> @ViewData["Stato"]</p>
                </div>
            </div>
        </div>
    </div>
    @if (User.IsInRole("Admin"))
    {
        <form method="post">
    <button type="submit" asp-action="ToggleActive" asp-route-id="@Model.Id">Toggle Active</button>
</form>
    }
</div>
```



crea un modello di vista ManageRolesViewModel.cs in Models

```csharp
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class ManageRolesViewModel
{
	public AppUser User { get; set; }
	public IEnumerable<IdentityRole> Roles { get; set; }
	public IEnumerable<string> UserRoles { get; set; }
}
```

in Controllers, crea un nuovo controller chiamato AdminController.cs

```csharp
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BraniMVC.Models;
using BraniMVC.Data;
using System.Linq;

public class AdminController : Controller
{
	private readonly ApplicationDbContext _context;
	private readonly UserManager<AppUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;

	public AdminController(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		_context = context;
		_userManager = userManager;
		_roleManager = roleManager;
	}

	[Authorize(Roles = "Admin")]
	public IActionResult Index()
	{
		var users = _context.Users.ToList();
		return View(users);
	}

	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> ToggleActive(string id)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		user.Stato = !user.Stato;
		await _userManager.UpdateAsync(user);

		return RedirectToAction(nameof(Index));
	}

	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> ManageRoles(string id)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		var roles = _roleManager.Roles.ToList();
		var userRoles = await _userManager.GetRolesAsync(user);

		var model = new ManageRolesViewModel
		{
			User = user,
			Roles = roles,
			UserRoles = userRoles
		};

		return View(model);
	}

	[Authorize(Roles = "Admin")]
	[HttpPost]
	public async Task<IActionResult> ManageRoles(string id, List<string> roles)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		var userRoles = await _userManager.GetRolesAsync(user);
		var result = await _userManager.AddToRolesAsync(user, roles.Except(userRoles));
		if (!result.Succeeded)
		{
			ModelState.AddModelError(string.Empty, "Impossibile aggiungere i ruoli selezionati all'utente.");
			return View();
		}

		result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(roles));
		if (!result.Succeeded)
		{
			ModelState.AddModelError(string.Empty, "Impossibile rimuovere i ruoli selezionati dall'utente.");
			return View();
		}

		return RedirectToAction(nameof(Index));
	}

	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(string id)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		return View(user);
	}

	[Authorize(Roles = "Admin")]
	[HttpPost]
	public async Task<IActionResult> Delete(string id, bool confirm)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		if (confirm)
		{
			await _userManager.DeleteAsync(user);
			return RedirectToAction(nameof(Index));
		}

		return RedirectToAction(nameof(Index));
	}

	// metodo per eliminare un utente
	/* [Authorize(Roles = "Admin")]
	public async Task<IActionResult> Delete(string id)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		} */

	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> EditCodice(string id)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		return View(user);
	}

	[Authorize(Roles = "Admin")]
	[HttpPost]
	public async Task<IActionResult> EditCodice(string id, string Codice)
	{
		var user = await _userManager.FindByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		user.Codice = Codice;
		await _userManager.UpdateAsync(user);

		return RedirectToAction(nameof(Index));
	}
}
```

Crea una vista Index.cshtml in Views/Admin

```html
@model IEnumerable<AppUser>
@{
	ViewData["Title"] = "Admin";
}

<h1>Admin</h1>

<table class="table">
	<thead>
		<tr>
			<th>
				Email
			</th>
			<th>
				Nome
			</th>
			<th>
				Codice
			</th>
			<th>
				Stato
			</th>
			<th></th>
		</tr>
	</thead>
	<tbody>
		@foreach (var user in Model)
		{
			<tr>
				<td>
					@user.Email
				</td>
				<td>
					@user.Nome
				</td>
				<td>
					@user.Codice
				</td>
				<td>
					@user.Stato
				</td>
				<td>
					<a asp-action="ToggleActive" asp-route-id="@user.Id">Toggle Active</a> |
					<a asp-action="ManageRoles" asp-route-id="@user.Id">Manage Roles</a> |
					<a asp-action="Delete" asp-route-id="@user.Id">Delete</a> |
					<a asp-action="EditCodice" asp-route-id="@user.Id">Edit Codice</a>
				</td>
			</tr>
		}
	</tbody>
</table>
```

Crea una vista ManageRoles.cshtml in Views/Admin

```html
@model ManageRolesViewModel
@{
	ViewData["Title"] = "Manage Roles";
}

<h1>Manage Roles</h1>

<h2>@Model.User.Email</h2>

<form method="post">
	@foreach (var role in Model.Roles)
	{
		<div>
			<input type="checkbox" name="roles" value="@role.Name" @(Model.UserRoles.Contains(role.Name) ? "checked" : "") />
			<label>@role.Name</label>
		</div>
	}
	<button type="submit">Save</button> <button type="submit" asp-action="Index">Annulla</button>
</form>
```

Crea una vista Delete.cshtml in Views/Admin

```html
@model AppUser
@{
	ViewData["Title"] = "Delete";
}

<h1>Delete</h1>

<h2>@Model.Email</h2>

<form method="post">
	<button type="submit" name="confirm" value="true">Delete</button> <button type="submit" asp-action="Index">Annulla</button>
</form>
```

Crea una vista EditCodice.cshtml in Views/Admin

```html
@model AppUser
@{
	ViewData["Title"] = "Edit Codice";
}

<h1>Edit Codice</h1>

<h2>@Model.Email</h2>

<form method="post">
	<div>
		<label>Codice</label>
		<input type="text" name="Codice" value="@Model.Codice" />
	</div>
	<button type="submit">Save</button> <button type="submit" asp-action="Index">Annulla</button>
</form>
```




cambiare il nome della colonna codicefornitore in codice ed stato attivo in stato

in ApplicationDbContext.cs

```csharp
protected override void OnModelCreating(ModelBuilder builder)
{
	base.OnModelCreating(builder);

	builder.Entity<AppUser>(entity =>
	{
		entity.Property(e => e.CodiceFornitore)
			.HasColumnName("Codice");
		entity.Property(e => e.StatoAttivo)
			.HasColumnName("Stato");
	});
}
```
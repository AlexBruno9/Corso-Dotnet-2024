using Microsoft.AspNetCore.Identity;

public class SeedData
{
	public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		// Creazione dei ruoli se non esistono
		string[] roleNames = { "Admin", "User" };
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
				UserName = "alex@admin.com",
				Email = "alex@admin.com",
				Nome = "AlexAdmin",
				Codice = "00000001", // Genera un codice univoco per ogni fornitore
				EmailConfirmed = true // Accettazione in automatico
			};
			await userManager.CreateAsync(adminUser, "Alex1!");
			await userManager.AddToRoleAsync(adminUser, "Admin");
		}
		else
		{
			var adminUser = await userManager.FindByEmailAsync("fdfdf@∂fdf.com");
			await userManager.AddToRoleAsync(adminUser!, "Admin");
		}





	}
}
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MvcAppunt.Models;
using MvcAppunt.Data;
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
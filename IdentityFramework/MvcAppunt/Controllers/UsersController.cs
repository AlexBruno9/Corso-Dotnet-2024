using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MvcAppunt.Models;
using MvcAppunt.Data;
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
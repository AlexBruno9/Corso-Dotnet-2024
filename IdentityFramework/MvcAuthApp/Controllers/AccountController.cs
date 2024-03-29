
//CREO QUESTO CS PER GESTIRE I RUOLI

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    //  GET:  /Account/AddToRole
    public async Task<IActionResult> AddToRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.AddToRoleAsync(user!, "Admin");
        return RedirectToAction("Index", "Home");
    }
}


//  ADESSO E' TUTTO PRONTO MA MANCA L'INPUT IN _LAYOUT
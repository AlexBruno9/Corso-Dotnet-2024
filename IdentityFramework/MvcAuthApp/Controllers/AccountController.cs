using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly SignInManager<IdentityUser> _signInManager;

public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: /Account/AddToRole
    public async Task<IActionResult> AddToRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.AddToRoleAsync(user, "Admin");
        return RedirectToAction("Index", "Home");
    }

    // GET: /Account/GetRole
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var roles = await _userManager.GetRolesAsync(user);
        return Content(string.Join(", ", roles));
    }

    // GET: /Account/RemoveFromRole
    public async Task<IActionResult> RemoveFromRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.RemoveFromRoleAsync(user, "Admin");
        return RedirectToAction("Index", "Home");
    }

    // GET: /Account/AddToRoleUser
    public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.AddToRoleAsync(user, "User");
        return RedirectToAction("Index", "Home");
    }

    // GET: /Account/RemoveFromRoleUser
    public async Task<IActionResult> RemoveFromRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.RemoveFromRoleAsync(user, "User");
        return RedirectToAction("Index", "Home");
    }

}
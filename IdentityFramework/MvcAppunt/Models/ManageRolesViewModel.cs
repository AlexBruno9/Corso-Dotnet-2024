using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class ManageRolesViewModel
{
	public AppUser User { get; set; }
	public IEnumerable<IdentityRole> Roles { get; set; }
	public IEnumerable<string> UserRoles { get; set; }
}
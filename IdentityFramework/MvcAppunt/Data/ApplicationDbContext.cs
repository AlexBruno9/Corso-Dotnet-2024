using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<AppUser>(entity =>
		{
			entity.Property(e => e.Codice)
				.HasColumnName("Codice");
			entity.Property(e => e.Stato)
				.HasColumnName("Stato");
		});
	}
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}



	// Se necessario, puoi aggiungere DbSet per altri modelli qui
}
using Microsoft.AspNetCore.Identity;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        context.Database.EnsureCreated();
    }
}

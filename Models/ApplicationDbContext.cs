using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Inquiry> Inquiries { get; set; }
}

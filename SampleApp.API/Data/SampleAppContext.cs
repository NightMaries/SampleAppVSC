namespace  SampleApp.API.Data;


using Microsoft.EntityFrameworkCore;
using SampleApp.API.Entities;

public class SampleAppContext: DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<Role> Roles {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;DataBase=SampleAppCourse;Username=localUser;Password=1234;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(typeof(SampleAppContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken){

            foreach(var entry in ChangeTracker.Entries<Base>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

}
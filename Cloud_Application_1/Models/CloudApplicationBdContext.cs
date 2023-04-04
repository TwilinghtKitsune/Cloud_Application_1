using Microsoft.EntityFrameworkCore;

namespace Cloud_Application_1.Models;

public partial class CloudApplicationBdContext : DbContext
{
    public CloudApplicationBdContext()
    {
    }
        
    public CloudApplicationBdContext(DbContextOptions<CloudApplicationBdContext> options)
        : base(options)
    {
         Database.EnsureCreated();
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Master> Masters { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Character_pkey");

            entity.HasIndex(e => e.Master, "fki_Character_fkey_Master");

            entity.HasIndex(e => e.Master, "fki_m");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.MasterNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.Master)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Character_fkey_Master");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Master_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using Microsoft.EntityFrameworkCore;

using To_Do_List_API.Entities;


namespace To_Do_List_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.Property(t => t.CreatedAt)
                .HasDefaultValueSql("NOW()");

                entity.Property(t => t.UpdatedAt)
                .HasDefaultValueSql("NOW()");

                entity.HasIndex(t => t.UserId);
            });

            
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is TaskItem && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries) 
            {
             var entity = (TaskItem)entry.Entity;
                if(entry.State == EntityState.Added)
                    entity.CreatedAt = DateTime.UtcNow;

                entity.UpdatedAt = DateTime.UtcNow;
            
            }

            return base.SaveChangesAsync(cancellationToken);
            
        }
    }
}
  

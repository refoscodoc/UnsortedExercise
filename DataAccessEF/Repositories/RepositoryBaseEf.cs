using Microsoft.EntityFrameworkCore;
using NewWebAPIdotnet6.Models;

namespace DataAccessEF.Repositories;

public class RepositoryBaseEf : DbContext
{
    public RepositoryBaseEf(DbContextOptions<RepositoryBaseEf> options) : base(options)
    {
    }
    
    public DbSet<Film> Film { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Film>(entity =>
        {
            entity.ToTable("film");
            entity.Property(p => p.FilmId).HasColumnName("film_id");
            entity.Property(p => p.Title).HasColumnName("title");
            entity.Property(p => p.Description).HasColumnName("description");
            entity.Property(p => p.ReleaseYear).HasColumnName("release_year");
        });
        
        builder.Entity<Film>().HasKey(m => m.FilmId);
        
        base.OnModelCreating(builder);
    }
}
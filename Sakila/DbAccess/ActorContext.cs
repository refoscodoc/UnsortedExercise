using Microsoft.EntityFrameworkCore;
using Sakila.Models;

namespace Sakila.DbAccess;

public class ActorContext : DbContext
{
    public ActorContext(DbContextOptions<Actor> options) : base(options)
    {
        
    }
    
    public DbSet<Actor> Actor { get; set; }
}
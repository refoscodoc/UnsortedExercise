using Microsoft.EntityFrameworkCore;

namespace Sakila.Models;

public class Actor : DbContext
{
    public int ActorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime LastUpdate { get; set; }
}
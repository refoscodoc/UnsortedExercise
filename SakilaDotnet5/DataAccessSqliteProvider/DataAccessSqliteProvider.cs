using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SakilaDotnet5.Services;
using SakilaDotnet5.Models;

namespace SakilaDotnet5.DataAccessSqliteProvider
{
    public class DataAccessSqliteProvider : IDataAccessProvider
    {
        private readonly DomainModelSqliteContext _context;
        private readonly ILogger _logger;

        public DataAccessSqliteProvider(DomainModelSqliteContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessSqliteProvider");
        }

        public Task<Actor> AddActor(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public Task<Actor> DeleteActor(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public Task<Actor> EditActor(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Actor> GetActor(int actorId)
        {
            return await _context.actor.FirstAsync(t => t.actor_id == actorId);
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            // return await _context.Actor.OrderBy(x => x.Id)
            //     .ToListAsync();
            return await _context.actor.ToListAsync();
        }
    }
}
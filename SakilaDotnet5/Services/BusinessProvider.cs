using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SakilaDotnet5.Models;

namespace SakilaDotnet5.Services
{
    public class BusinessProvider
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public BusinessProvider(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        
        public async Task<IEnumerable<Actor>> GetActors()
        {
            var data = await _dataAccessProvider.GetActors();
        
            var result = data.Select(actor => new Actor
            {
                actor_id = actor.actor_id,
                first_name = actor.first_name,
                last_name = actor.last_name,
                last_update = actor.last_update
            });
            
            return result;
        }
        
        public async Task<Actor> GetActor(int actorId)
        {
            return await _dataAccessProvider.GetActor(actorId);
        }
    }
}
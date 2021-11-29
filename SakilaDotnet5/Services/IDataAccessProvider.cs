using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SakilaDotnet5;
using SakilaDotnet5.Models;

namespace SakilaDotnet5.Services
{
    public interface IDataAccessProvider
    {
        Task<Actor> AddActor(Actor actor);

        Task<Actor> DeleteActor(Actor actor);

        Task<Actor> EditActor(Actor actor);

        Task<Actor> GetActor(int actorId);

        Task<IEnumerable<Actor>> GetActors();
    }
}
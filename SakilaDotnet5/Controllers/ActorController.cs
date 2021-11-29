using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SakilaDotnet5.Models;
using SakilaDotnet5.Services;

namespace SakilaDotnet5.Controllers;

[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly BusinessProvider _businessProvider;
    
    public ActorController(BusinessProvider businessProvider)
    {
        _businessProvider = businessProvider;
    }
    
    [HttpGet("{actorId}")]
    [ProducesResponseType(typeof(IEnumerable<Actor>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> Get(int actorId)
    {
        if (actorId == 0 || actorId == null)
        {
            return Ok(await _businessProvider.GetActors());
        }

        return Ok(await _businessProvider.GetActor(actorId));
    }
}
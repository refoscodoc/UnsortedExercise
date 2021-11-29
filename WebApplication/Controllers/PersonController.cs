using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        
        [HttpGet("{id?}")]
        public IActionResult Get(int? id)
        {
            return Ok(_personService.GetPerson(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] Person person)
        {
            var id = _personService.AddPerson(person, out var errors);
            if (errors.Any())
            {
                return ValidationProblem(string.Join(", ", errors));
            }
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            return Ok(_personService.Delete(id));
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Person person)
        {
            return Ok(_personService.EditPerson(person));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Personas.Services;
using WebApplicationAPICore.DTOs;
using WebApplicationAPICore.Models;

namespace WebApplicationAPICore.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasApiController : ControllerBase
    {
        PersonasRepository _personasRepository;

        public PersonasApiController(PersonasRepository personasRepository)
        {
            _personasRepository = personasRepository;
        }


        // GET: api/<PersonasController>
        [HttpGet]
        public ActionResult<PersonaDTO> Get()
        {
            var lista = from p in _personasRepository.List()
                        select new PersonaDTO
                        {
                            Id = p.Id,
                            DNI = p.DNI,
                            Nombre = p.Nombre
                        };
            return Ok(lista);
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

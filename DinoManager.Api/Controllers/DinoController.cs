using DinoManager.Api.Models.Dtos;
using DinoManager.Bll.Entities;
using DinoManager.Bll.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DinoManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinoController : ControllerBase
    {
        private readonly IDinoRepository _dinoRepository;

        public DinoController(IDinoRepository dinoRepository)
        {
            _dinoRepository = dinoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dinoRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Dino? dino = _dinoRepository.Get(id);

            if(dino is null)
            {
                return NotFound();
            }

            return Ok(dino);
        }

        // POST api/<DinoController>
        [HttpPost]
        public IActionResult Post([FromBody] AjoutDinoDto dto)
        {
            if(!_dinoRepository.Create(new Dino(dto.Espece, dto.Poids, dto.Taille)))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateDinoDto dto)
        {
            if (!_dinoRepository.Update(id, new Dino(dto.Espece, dto.Poids, dto.Taille)))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_dinoRepository.Delete(id))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}

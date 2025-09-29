using DinoManager.Api.Models.Dtos;
using DinoManager.Domain.Commands;
using DinoManager.Domain.Entities;
using DinoManager.Domain.Queries;
using DinoManager.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Tools.Cqs.Results;

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
        public async Task<IActionResult> Get()
        {
            ICqsResult<IEnumerable<Dino>> result = await _dinoRepository.ExecuteAsync(new GetAllDinosaureQuery());

            if (result.IsFailure) return BadRequest(result);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ICqsResult<Dino> result = _dinoRepository.Execute(new GetDinoByIdQuery(id));

            if (result.IsFailure)
            {
                return NotFound(result);
            }

            return Ok(result.Data);
        }

        //// POST api/<DinoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AjoutDinoDto dto)
        {
            ICqsResult result = await _dinoRepository.ExecuteAsync(new CreateDinoCommand(dto.Espece, dto.Poids, dto.Taille));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateDinoDto dto)
        {
            ICqsResult result = _dinoRepository.Execute(new UpdateDinoCommand(id, dto.Espece, dto.Poids, dto.Taille));

                if (result.IsFailure)
                    return BadRequest(result);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ICqsResult result = _dinoRepository.Execute(new DeleteDinoCommand(id));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }        
    }
}

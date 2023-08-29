using AutoMapper;
using GymApp.Models.ExerciseModels;
using GymApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _repository;

        public ExerciseController(IExerciseRepository repository)
        {
            
            _repository = repository;
           
        }

        [HttpPost("{sessionID}")]
        public async Task<IActionResult> CreateExercise([FromRoute] int sessionID,[FromBody] CreateExerciseDTO exerciseDTO)
        {

            Exercise exercise = new ()
            {
                Name = exerciseDTO.Name,
                GymSessionID = sessionID
            };
            
            await _repository.AddExercise(exercise);
            
            CreateExerciseDTO returnDTO = new ()
            {
                Name = exercise.Name,
                GymSessionID = exercise.GymSessionID
            };
            
            return Ok(returnDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllExercises([FromRoute] int id)
        {
            IEnumerable<Exercise> returnList = await _repository.ListExercises();
            return Ok(returnList);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateExercise([FromRoute] int id, [FromBody]UpdateExerciseDTO exercise)
        {
            Exercise UpdatingExercise = await _repository.GetExercise(id);

            if(UpdatingExercise == null)
        {
            return NotFound();
        }

            UpdatingExercise.Name = exercise.Name;
            UpdatingExercise.GymSessionID = exercise.GymSessionID;
            
            await _repository.UpdateExercise(UpdatingExercise);
            return Ok(UpdatingExercise);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            return Ok(await _repository.GetExercise(id));
        }

        [HttpDelete("{id}")]
        public async Task DeleteExercise([FromRoute] int id)
        {
            await _repository.DeleteExercise(id);
        }

        
    }
}
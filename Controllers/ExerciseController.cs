using AutoMapper;
using GymApp.Models.ExerciseModels;
using GymApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _repository;
        


        public ExerciseController(IExerciseRepository repository)
        {
            
            _repository = repository;
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseDTO exerciseDTO)
        {

            Exercise exercise = new ()
            {
                Name = exerciseDTO.Name,
                GymSessionID = exerciseDTO.GymSessionID
            };
            
            await _repository.AddExercise(exercise);
            
            CreateExerciseDTO returnDTO = new ()
            {
                Name = exercise.Name,
                GymSessionID = exercise.GymSessionID
            };
            
            return Ok(returnDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
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
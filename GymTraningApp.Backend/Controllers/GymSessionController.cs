using AutoMapper;
using GymApp.Models;
using GymApp.Models.ExerciseModels;
using GymApp.Models.GymSession;
using GymApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class GymSessionController : ControllerBase
{
    private readonly IGymSessionRepository _repository;
    private readonly IMapper _mapper;

    public GymSessionController(IGymSessionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSesionById([FromRoute] int id)
    {
        GymSession? session = await _repository.GetSession(id);

        if (session == null)
        {
            return NotFound();
        }

        GetDetailGymSessionDTO sessionDTO = _mapper.Map<GetDetailGymSessionDTO>(session);
        return Ok(sessionDTO);
    }

    [HttpGet]
    public async Task<IActionResult> ListSessions()
    {
        IEnumerable<GymSession> sessions = await _repository.ListSessions();
        IEnumerable<GetGymSessionDTO> sessionDTO = _mapper.Map<List<GetGymSessionDTO>>(sessions);
        return Ok(sessionDTO);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession([FromBody] CreateGymSessionDTO sessionDTO)
    {
        GymSession session = _mapper.Map<GymSession>(sessionDTO);
        GymSession created = await _repository.AddSession(session);
        GetGymSessionDTO getGymSessionDTO = _mapper.Map<GetGymSessionDTO>(created);

        // return CreatedAtAction(nameof(GetSesionById), new { created.Id }, created);
        return Ok(getGymSessionDTO);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSession([FromRoute] int id, [FromBody] GymSession session)
    {
        GymSession existing = await _repository.GetSession(id);

        if(existing == null)
        {
            return NotFound();
        }

        existing.Title = session.Title;
        existing.Exercises = session.Exercises;
        
        await _repository.UpdateSession(existing);
        return Ok(existing);
    }
}
using FootballAPI.Exceptions;
using FootballAPI.Models;
using FootballAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FootballAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        
        private ITeamsService _teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        // api/teams
        [HttpGet]
        public ActionResult<IEnumerable<TeamModel>> GetTeams(string orderBy = "Id")
        {
            try
            {
                var teams = _teamsService.GetTeams(orderBy);
                return Ok(teams);
            }
            catch(InvalidOperationItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        // api/teams/2
        [HttpGet("{teamId:long}")]
        public ActionResult<TeamWithPlayerModel> GetTeam(long teamId)
        {
            try
            {
                var team = _teamsService.GetTeam(teamId);
                return Ok(team);
            }
            catch(NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        // api/teams
        [HttpPost]
        public ActionResult<TeamModel> CreateTeam([FromBody] TeamModel newTeam)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var team = _teamsService.CreateTeam(newTeam);
                return Created($"/api/teams/{team.Id}", team);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpDelete("{teamId:long}")]
        public ActionResult<bool> DeleteTeam(long teamId)
        {
            try
            {
                var result = _teamsService.DeleteTeam(teamId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpPut("{teamId:long}")]
        public ActionResult<TeamModel> UpdateTeam(long teamId, [FromBody] TeamModel updatedTeam)
        {
            try
            {
                /*if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(updatedTeam.City) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }*/
                
                var team = _teamsService.UpdateTeam(teamId, updatedTeam);
                return Ok(team);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}

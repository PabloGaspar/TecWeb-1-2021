using FootballAPI.Exceptions;
using FootballAPI.Models;
using FootballAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Controllers
{
    [Route("api/teams/{teamId:long}/[controller]")]
    public class PlayersController : Controller
    {

        private IPlayersService _playerService;

        public PlayersController(IPlayersService playerService)
        {
            _playerService = playerService;
        }

        //localhost:3030/api/teams/{teamId:long}/players
        [HttpGet]
        public ActionResult<IEnumerable<PlayerModel>> GetPlayers(long teamId)
        {
            try
            {
                var players = _playerService.GetPlayers(teamId);
                return Ok(players);
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

        [HttpGet("{playerId:long}")]
        public IActionResult GetPlayer(long teamId, long playerId)
        {
            try
            {
                var player = _playerService.GetPlayer(teamId, playerId);
                return Ok(player);
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

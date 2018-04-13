using GameScore.Infra;
using GameScore.Interfaces;
using GameScore.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class leaderboardController : Controller
    {
        private readonly IScoreRepository _scoreRepository;

        public leaderboardController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<Score>> Get()
        {
            return await _scoreRepository.GetAllScores();
        }

    }
}

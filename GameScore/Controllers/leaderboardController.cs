using GameScore.Data;
using GameScore.Infra;

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
        private readonly ScoreRepository _scoreRepository;

        public leaderboardController(ScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<Score>> Get()
        {
            return await _scoreRepository.GetAllScores();
        }

        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
               // _scoreRepository.RemoveAllNotes();
                _scoreRepository.AddScore(new Score()
                {
                    GameId = 1,
                    PlayerId = 1,
                    TimeSpan = DateTime.Now,
                    Win = 200
                });
                _scoreRepository.AddScore(new Score()
                {
                    GameId = 1,
                    PlayerId=1,
                    TimeSpan = DateTime.Now,
                    Win = 20               

                });
                _scoreRepository.AddScore(new Score()
                {
                    GameId = 1,
                    PlayerId = 2,
                    TimeSpan = DateTime.Now,
                    Win = 200
                });
                _scoreRepository.AddScore(new Score()
                {
                    GameId = 1,
                    PlayerId = 1,
                    TimeSpan = DateTime.Now,
                    Win = 50
                });

                return "Done";
            }

            return "Unknown";
        }


    }
}

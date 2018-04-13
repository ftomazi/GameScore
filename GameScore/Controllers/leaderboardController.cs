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
    public class LeaderBoardController : Controller
    {
        private readonly ScoreRepository _scoreRepository;

        public LeaderBoardController(ScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            //  return await _scoreRepository.GetAllScores();
            return await _scoreRepository.GetScores();
        }
             
        [HttpPost]
        public async void Post([FromBody] ScoreParam newScore)
        {
            _scoreRepository.AddScore(new Score
            {
                GameId = newScore.GameId,
                Win = newScore.Win,
                TimeSpan = newScore.TimeSpan,
                PlayerId = newScore.PlayerId
            });
        }
        
        // Call an initialization - api/system/init
        [HttpPost("{setting}")]
        public string Post(string setting)
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

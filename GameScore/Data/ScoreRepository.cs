using GameScore.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameScore.Data
{
    public class ScoreRepository 
    {
        private readonly ScoreContext _context = null;

        public ScoreRepository(IOptions<Settings> settings)
        {
            _context = new ScoreContext(settings);
        }

        public async Task AddScore(Score item)
        {
                await _context.Scores.InsertOneAsync(item);
        }

        public async Task<IEnumerable<Score>> GetAllScores()
        {
                return await _context.Scores.Find(_ => true).ToListAsync();
        }

        public async Task<bool> UpdateScoreDocument(int id, Score item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Scores
                                                .ReplaceOneAsync(n => n.PlayerId.Equals(id)
                                                                , item
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}

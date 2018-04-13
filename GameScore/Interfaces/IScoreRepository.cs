using GameScore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScore.Interfaces
{
    public interface IScoreRepository
    {

        Task<IEnumerable<Score>> GetAllScores();

        // add new note document
        Task AddScore(Score item);

        // demo interface - full document update
        Task<bool> UpdateScoreDocument(int id, Score item);
    }
}

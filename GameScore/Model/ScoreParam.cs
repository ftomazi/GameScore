using System;

namespace GameScore.Model
{
    public class ScoreParam
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Win { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}

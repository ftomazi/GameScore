using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GameScore.Model
{
    public class Score
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Win { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}

using System.Collections.Generic;

namespace CPMobile.Models
{
   
    public class ReputationType
    {
        public string name { get; set; }
        public int points { get; set; }
        public string level { get; set; }
        public string designation { get; set; }
    }

    public class AuthorReputation
    {
        public int totalPoints { get; set; }
        public List<ReputationType> reputationTypes { get; set; }
        public string graphUrl { get; set; }
    }
}

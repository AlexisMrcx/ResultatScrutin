using System;
using System.Collections.Generic;

namespace ResultatScrutin
{
    public class Scrutin
    {
        private List<string> votes;
        public bool IsClosed { get; set; }

        public Scrutin()
        {
            votes = new List<string>();
            IsClosed = false;
        }

        public void AddVote(string v)
        {
            votes.Add(v);
        }

        public void FinVote()
        {
            IsClosed = true;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ResultatScrutin
{
    public class Scrutin
    {
        private List<string> votes;
        private List<Candidat> candidats;
        public bool IsClosed { get; set; }
        public Candidat Vainqueur { get; set; }

        public Scrutin()
        {
            votes = new List<string>();
            candidats = new List<Candidat>();
            IsClosed = false;
        }

        public void AddVote(string v)
        {
            votes.Add(v);
        }

        public void AddCandidate(string v)
        {
            candidats.Add(new Candidat(v));
        }


        public void FinVote()
        {
            IsClosed = true;
        }

        public void DepouilleVotes()
        {
            foreach (string vote in votes)
            {
                Candidat candidat;

                candidat = candidats.Find(x => x.Nom == vote);
                if (candidat != null) { candidat.NbVoie += 1; }
            }

            foreach(Candidat c in candidats)
            {
                if (c.NbVoie > (votes.Count / 2)) { Vainqueur = c; }
            }
        }
    }
}

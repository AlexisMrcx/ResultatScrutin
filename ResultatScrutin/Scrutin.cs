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
        public bool IsSecondRound { get; set; }

        public Scrutin()
        {
            votes = new List<string>();
            candidats = new List<Candidat>();
            IsClosed = false;
            IsSecondRound = false;
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

            foreach (Candidat c in candidats)
            {
                c.Percent = ((float)c.NbVoie / (float)NbTotalVoie) * 100;
                if (c.NbVoie > (votes.Count / 2)) { Vainqueur = c; }
            }
        }

        public string ShowResult()
        {
            string result = "";

            foreach (Candidat c in candidats)
            {
                result += (c.Nom + ": " + c.NbVoie + ";" + c.Percent + "%, ");
            }

            return result.TrimEnd(',', ' ');
        }

        public void CreateSecondRound(string c1, string c2)
        {
            Candidat candidat1, candidat2;

            candidat1 = candidats.Find(x => x.Nom == c1);
            candidat2 = candidats.Find(x => x.Nom == c2);

            candidat1.RazVoie();
            candidat2.RazVoie();

            candidats = new List<Candidat>();
            candidats.Add(candidat1);
            candidats.Add(candidat2);

            IsSecondRound = true;
        }


        public int NbTotalVoie
        {
            get
            {
                return votes.Count;
            }
        }

        
    }
}

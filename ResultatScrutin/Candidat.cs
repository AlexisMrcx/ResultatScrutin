using System;
using System.Collections.Generic;
using System.Text;

namespace ResultatScrutin
{
    public class Candidat
    {
        public string Nom { get; set; }
        public int NbVoie { get; set; }
        public float Percent { get; set; }

        public Candidat(string nom)
        {
            Nom = nom;
            NbVoie = 0;
        }

        public void RazVoie()
        {
            NbVoie = 0;
            Percent = 0;
        }
    }
}

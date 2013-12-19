using System;
using System.Collections.Generic;
using System.Linq;
namespace FaireCarte
{
    public class Noeud
    {
        private static Int32 idcourant = 0;
        public Int32 id = 0;
        public Position p;
        public List<String> ssids;
        public double cote;

        public Noeud(int x, int y, List<String> s)
        {
            this.id = idcourant++;
            p = new Position(x, y);
            ssids = s;
            cote = 1.0d;
        }

        public void calculerCote(List<string> currentScan)
        {
            var numerateur = (double)(currentScan.Where(x => ssids.Contains(x)).Count());
            var denominateur = (double)(ssids.Count);
            cote *= numerateur / denominateur;
        }
    }
}
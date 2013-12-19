using System;
using System.Collections.Generic;

namespace FaireCarte
{
    public class Noeud
    {
        private static Int32 idcourant = 0;
        public Int32 id = 0;
        public Position p;
        public List<String> ssid;

        public Noeud(int x, int y, List<String> s)
        {
            this.id = idcourant++;
            p = new Position(x, y);
            ssid = s;
        }
    }
}
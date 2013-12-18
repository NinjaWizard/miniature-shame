using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaireCarte
{
    class Noeud
    {
        public Position p;
        public List<String> ssid;
        public Noeud(int x, int y , List<String> s)
        {
            p = new Position(x, y);
            ssid = s;
        }
    }
}

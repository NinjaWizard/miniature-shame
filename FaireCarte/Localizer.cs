using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaireCarte
{
    public class Localizer
    {
        public List<Noeud> findBestMatch(List<string> currentScan, List<Noeud> pings)
        {
            double sommeCotes = 0.0d;

            foreach (var ping in pings)
            {
                ping.calculerCote(currentScan);
                
                // Si la cote tombe à 0 on ne veut pas l'annuler définitivement.
                if(ping.cote == 0.0d)
                    ping.cote = 0.0001d;

                sommeCotes += ping.cote;
            }

            //Normalisation
            foreach (var ping in pings)
            {
                ping.cote = ping.cote / sommeCotes;
            }

            return pings;
        }
    }
}

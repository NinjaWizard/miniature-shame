using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace FaireCarte
{
    class FileGetter
    {
        const String path = "C:\\Users\\NInjaWizard\\Documents\\Visual Studio 2012\\Projects\\FaireCarte\\FaireCarte\\robot1.txt";
        enum d { north = 0, east = 1, south = 2, west = 3 };

        public FileGetter()
        {
        }
        public void read()
        {
            string temp;
            ArrayList array = new ArrayList();
            d direction = d.north;
            Position curPos = new Position(0,0);

            using (StreamReader sr = new StreamReader(path))
            {
                temp = sr.ReadToEnd();
                String[] tab = temp.Split('\n');
                Noeud n;
                Noeud old = null;
                foreach (String occ in tab)
                {
                    String[] line = occ.Split('/');
                    if (line.Length == 1)//Si c'est un tournant
                    {
                        if (line[0] == "<")
                        {
                            int t = ((int)d.north - 1) % 4;
                            direction = (d)t;
                        }
                        else if (line[0] == ">")
                        {
                            int t = ((int)d.north + 1) % 4;
                            direction = (d)t;
                        }
                    }
                    else //si c'est un ping
                    {
                        curPos = miseAjour(curPos,direction);
                       String[] str = line[1].Split(';');
                       array.Add(new Noeud(curPos.x,curPos.y,new List<String>(str)));
                    }
                
                }
                array.Add(tab);
            }


        }
        private Position miseAjour(Position p, d dir)
        {
            switch (dir)
            {
                case d.north:
                    p.y += 10;
                    break;
                case d.east:
                    p.x += 10;
                    break;
                case d.south:
                    p.y -= 10;
                    break;
                case d.west:
                    p.x -= 10;
                    break;
            }
            return p;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FaireCarte
{
    internal class FileGetter
    {
        private const String path =
            "C:\\Users\\NInjaWizard\\Documents\\Visual Studio 2012\\Projects\\FaireCarte\\FaireCarte\\robot1.txt";

        public void Read()
        {
            var pings = new ArrayList();
            var direction = Direction.North;
            var currentPosition = new Position(0, 0);

            using (var sr = new StreamReader(path))
            {
                String[] tab = sr.ReadToEnd().Split('\n');
                foreach (String occ in tab)
                {
                    String[] line = occ.Split('/');
                    if (line.Length == 1) //Si c'est un tournant
                    {
                        if (line[0] == "<")
                        {
                            direction = (Direction) (((int) Direction.North - 1)%4);
                        }
                        else if (line[0] == ">")
                        {
                            direction = (Direction) (((int) Direction.North + 1)%4);
                        }
                    }
                    else //si c'est un ping
                    {
                        currentPosition = miseAjour(currentPosition, direction);
                        String[] str = line[1].Split(';');
                        pings.Add(new Noeud(currentPosition.x, currentPosition.y, new List<String>(str)));
                    }
                }
                pings.Add(tab);
            }
        }

        private Position miseAjour(Position p, Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    p.y += 10;
                    break;
                case Direction.East:
                    p.x += 10;
                    break;
                case Direction.South:
                    p.y -= 10;
                    break;
                case Direction.West:
                    p.x -= 10;
                    break;
            }
            return p;
        }

        private enum Direction
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        };
    }
}
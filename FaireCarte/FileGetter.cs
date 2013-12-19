using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using FaireCarte.Properties;

namespace FaireCarte
{
    public class FileGetter
    {
        private const String path = "robot1.txt";
        private readonly List<Noeud> _pings;

        public FileGetter()
        {
            _pings = new List<Noeud>();
        }

        public void Read()
        {
            var direction = Direction.North;
            var currentPosition = new Position(0, 0);

            using (var sr = new StreamReader(path))
            {
                string[] tab = sr.ReadToEnd().Split(new[] {"\r\n", "\n"}, StringSplitOptions.None);
                foreach (String occ in tab)
                {
                    String[] line = occ.Split('/');
                    if (line.Length == 1) //Si c'est un tournant
                    {
                        if (line[0] == "<")
                        {
                            switch (direction)
                            {
                                case Direction.North:
                                    direction = Direction.West;
                                    break;
                                case Direction.East:
                                    direction = Direction.North;
                                    break;
                                case Direction.South:
                                    direction = Direction.East;
                                    break;
                                case Direction.West:
                                    direction = Direction.South;
                                    break;
                            }
                        }
                        else if (line[0] == ">")
                        {
                            switch (direction)
                            {
                                case Direction.North:
                                    direction = Direction.East;
                                    break;
                                case Direction.East:
                                    direction = Direction.South;
                                    break;
                                case Direction.South:
                                    direction = Direction.West;
                                    break;
                                case Direction.West:
                                    direction = Direction.North;
                                    break;
                            }
                        }
                    }
                    else //si c'est un ping
                    {
                        currentPosition = miseAjour(currentPosition, direction);
                        String[] str = line[1].Split(';');
                        _pings.Add(new Noeud(currentPosition.x, currentPosition.y, new List<String>(str)));
                    }
                }
                //_pings.Add(tab);
            }
        }

        private Position miseAjour(Position p, Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    p.y += 3;
                    break;
                case Direction.East:
                    p.x += 3;
                    break;
                case Direction.South:
                    p.y -= 3;
                    break;
                case Direction.West:
                    p.x -= 3;
                    break;
            }
            return p;
        }

        public Noeud[,] PingsToMatrix()
        {
            //var map = new Noeud[_pings.Count,_pings.Count];
            var map = new Noeud[Resources.mapSizeX,Resources.mapSizeY];

            foreach (Noeud ping in _pings)
            {
                if (map[Resources.mapSizeX / 2 + ping.p.x, Resources.mapSizeY / 2 + ping.p.y] == null)
                    map[Resources.mapSizeX / 2 + ping.p.x, Resources.mapSizeY / 2 + ping.p.y] = ping;
                else
                {
                    map[Resources.mapSizeX / 2 + ping.p.x, Resources.mapSizeY / 2 + ping.p.y].ssid =
                        map[Resources.mapSizeX / 2 + ping.p.x, Resources.mapSizeY / 2 + ping.p.y]
                        .ssid
                        .Where(ssid => ping.ssid.Contains(ssid))
                        .ToList();
                }
            }

            return map;
        }

        private enum Direction
        {
            East = 0,
            South = 1,
            West = 2,
            North = 3
        };
    }
}
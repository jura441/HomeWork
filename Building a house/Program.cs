using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_a_house
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Teams> teams = new List<Teams>
                { new Teams("Рабочий 1"),
                new Teams("Рабочий 2"),
                new Teams("Рабочий 3"),
                new Teams("Рабочий 4") };
            House house = new House();
            Team teamleader = new Team("Бригадир", teams);
            //докладная бригадира по строительству дома
            Console.WriteLine(teamleader.Name);

            Random rand = new Random();

            for (int i = 0; i < 6; i++)
            {
                teamleader.Teams[rand.Next(0, 3)].Build(house, teamleader.T);
            }

            foreach (var j in teamleader.T.report)
            {
                Console.WriteLine(j);
            }

            teamleader.T.Report();
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                teamleader.Teams[rand.Next(0, 3)].Build(house, teamleader.T);
            }

            foreach (var i in teamleader.T.report)
            {
                Console.WriteLine(i);
            }
            teamleader.T.Report();

            house.Build(teamleader.T);
        }
    }
    interface IWorker
    {
        string Name { get; }
    }
    interface IPart
    {
        void Build(House house);
    }

    class Basement : IPart
    {
        public void Build(House house)
        {
            house.basement = new Basement();
        }
    }

    class Walls : IPart
    {
        public void Build(House house)
        {
            house.walls.Add(new Walls());
        }
    }

    class Door : IPart
    {
        public void Build(House house)
        {
            house.door = new Door();
        }
    }

    class Window : IPart
    {
        public void Build(House house)
        {
            house.window.Add(new Window());
        }
    }

    class Roof : IPart
    {
        public void Build(House house)
        {
            house.roof = new Roof();
        }
    }

    class House
    {
        public Basement basement;
        public List<Walls> walls;
        public List<Window> window;
        public Door door;
        public Roof roof;
        public void Build(TeamLeader t)
        {
            Console.WriteLine("\n___________$$$\r\n_________$$___$$\r\n_____$$$_______$$$\r\n__$$$_____________$$$\r\n__-------------------\r\n__$$$$$$$$$$$$$$$$$$$\r\n__$_________________$\r\n__$____$$$$$$$$$____$\r\n__$____$        $___$\r\n__$____$        $___$\r\n__$____$$$$$$$$$____$\r\n__$_________________$\r\n__$$$$$$$$$$$$$$$$$$$\r\n__-------------------\r\n");

        }
    }
    class Team : IWorker
    {
        public TeamLeader T;
        public List<Teams> Teams;
        public string Name { get; set; }

        public Team(string name, List<Teams> workers)
        {
            T = new TeamLeader(name);
            Teams = workers;
        }
    }

    class Teams : IWorker
    {
        string Name { get; set; }

        string IWorker.Name => Name;

        public Teams(string name)
        { Name = name; }

        public void Build(House house, TeamLeader T)
        {
            if (house.basement == null)
            {
                Basement basement = new Basement();
                basement.Build(house);
                T.report.Add($"{Name} залил фундамент");
            }
            else if (house.walls == null || house.walls.Count < 4)
            {
                if (house.walls == null) house.walls = new List<Walls>();
                Walls wall = new Walls();
                wall.Build(house);
                T.report.Add($"{Name} построил стену {house.walls.Count}");
            }
            else if (house.roof == null)
            {
                Roof roof = new Roof();
                roof.Build(house);
                T.report.Add($"{Name} построил крышу");
            }
            else if (house.door == null)
            {
                Door door = new Door();
                door.Build(house);
                T.report.Add($"{Name} поставил дверь на запасной выход с обратной стoроны дома");
            }
            else if (house.window == null || house.window.Count < 4)
            {
                if (house.window == null) house.window = new List<Window>();
                Window window = new Window();
                window.Build(house);
                T.report.Add($"{Name} установил окно {house.window.Count}");
            }
        }
    }
    class TeamLeader : IWorker
    {
        string Name { get; set; }
        public List<string> report = new List<string>();
        string IWorker.Name => Name;
        public TeamLeader(string name)
        { Name = name; }
        public void Report()
        {

            Console.WriteLine($"{Name} сделал отчёт, что строительство закончено");
        }
    }
}

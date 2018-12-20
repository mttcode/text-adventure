using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TextGame.Rooms;
using TextGame.Items;
using TextGame.Core;
using TextGame.Commands;
using Stalker.Commands;
using Stalker.Items;


namespace Stalker
{
    class Room : IRoom
    {
        public string nazov;                
        public string opis;
        IRoom sever, zapad, vychod, juh;
        List<AItem> predmety = new List<AItem>();
        ArrayList smery = new ArrayList();


        public Room(string opis)
        {
            this.opis = opis;
        }

        public Room(string nazov, string opis)
        {
            this.nazov = nazov;
            this.opis = opis;
        }

        public void SetExits(IRoom north, IRoom south, IRoom east, IRoom west)
        {
            this.sever = north;
            this.juh = south;
            this.vychod = east;
            this.zapad = west;

            if (North != null)
                smery.Add("Sever");

            if (South != null)
                smery.Add("Juh");

            if (East != null)
                smery.Add("Vychod");

            if (West != null)
                smery.Add("Zapad");
        }


        public void Show()
        {
            int sirkaObr = Console.WindowWidth;

            Console.WriteLine();

            for (int i = 0; i < sirkaObr; i++)
                Console.Write("-");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>{0}", Name);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">>{0}", Description);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVidis:");
            Console.ResetColor();

            if (predmety.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Nevidim nic zlvastneho.");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < predmety.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", predmety[i].Name);
                    Console.ResetColor();
                }
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Mozes ist na:");
            Console.ResetColor();

            for (int i = 0; i < smery.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}", smery[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        public string Name
        {
            get { return nazov; }
        }

        public string Description
        {
            get { return opis; }
        }

        public IRoom East
        {
            get { return vychod; }
        }

        public IRoom South
        {
            get { return juh; }
        }

        public IRoom West
        {
            get { return zapad; }
        }

        public IRoom North
        {
            get { return sever; }
        }

        public void AddItem(AItem item)
        {
            this.predmety.Add(item);
        }

        public void RemoveItem(AItem item)
        {
            this.predmety.Remove(item);
        }

        public AItem GetItem(string name)
        {
            for (int i = 0; i < predmety.Count; i++)
            {
                if (predmety[i].Name == name)
                {
                    return predmety[i];
                }
            }
            return null;
        }

        public List<AItem> ResetItem
        {
            get { return this.predmety; }
        }
    }
}

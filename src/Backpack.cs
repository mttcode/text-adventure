using System;
using System.Collections.Generic;
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
    class Backpack : IBackpack
    {
        int objemBatoha;
        
        List<AItem> batoh = new List<AItem>();

        public void ShowBackpack()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nObsah batoha:\n");
            Console.ResetColor();

            if (Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Batoh je prazdny.\n");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", batoh[i].Name);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }


        public bool Add(AItem item)
        {
            if (Count < Capacity)
            {
                batoh.Add(item);
                return true;
            }
            else
                Console.WriteLine("Batoh je plny.");
            return false;
        }


        public AItem Remove(string name)
        {
            AItem polozka;

            if (GetItem(name) == null)
                return null;
            else
            {
                polozka = GetItem(name);
                batoh.Remove(GetItem(name));

            }
            return polozka;
        }
        

        public AItem GetItem(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                if (batoh[i].Name == name)
                {
                    return batoh[i];
                }
            }
            return null;
        }

        public List<AItem> ResetBackPack
        {
            get { return this.batoh; }
        }


        public Backpack(int objem)
        {
            this.objemBatoha = objem;
        }


        public int Capacity
        {
            get { return objemBatoha; }
        }


        public int Count
        {
            get { return batoh.Count; }
        }
    }
}

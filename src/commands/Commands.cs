using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextGame.Rooms;
using TextGame.Items;
using TextGame.Core;
using TextGame.Commands;
using Stalker.Items;

namespace Stalker.Commands
{
    class Commands : ACommand, ICommand
    {
        public Commands() : base("PRIKAZY", "Zobrazi vsetky prikazy pouzitelne v hre.") { }
        
        public GameState Execute(IGame game)
        {
            int i = 0;
            Parser parsovac = new Parser();
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));

            Console.WriteLine();

            foreach (string colorName in colorNames)
            {
                i++;

                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                if (color == ConsoleColor.Black) continue;

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = color;

                if (i == 14) break;

                Console.WriteLine("{0} - {1}", parsovac.Prikazy[i].Name, parsovac.Prikazy[i].Description);

                Console.ResetColor();
            }

            Console.ResetColor();
            Console.WriteLine();

            return GameState.PLAYING;
        }
    }
}

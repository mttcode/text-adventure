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

namespace Stalker.Items
{
    class Card : AItem, IMoveable, IUseable
    {
        public Card() : base("PREUKAZ", "Osobny preukaz totoznosti.") { }

        public GameState Use(IGame game)
        {
            if (game.CurrentRoom.Name == "Recepcia")
            {
                Game gameRoom = (Game)game;

                game.CurrentRoom = gameRoom.Ef6;
                game.CurrentRoom.Show();
                game.Backpack.Remove("PREUKAZ");
            }
            return GameState.PLAYING;
        }
    }
}

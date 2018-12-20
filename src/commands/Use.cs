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

namespace Stalker.Commands
{
    class Use : ACommand, ICommand
    {
        public Use() : base("POUZI", "Pokusi sa pouzit zadany predmet.") { }

        public GameState Execute(IGame game)
        {
            string parametrik;
            Game referencia;
            IUseable referencia_use;

            referencia = (Game)game;
            parametrik = referencia.Parameter.Params;

            AItem RoomGet = game.CurrentRoom.GetItem(parametrik);
            AItem PackGet = game.Backpack.GetItem(parametrik);


            if (RoomGet == null && PackGet == null)
            {
                Console.WriteLine("Taky predmet tu nikde nevidim.");
            }
            else
            {
                if (RoomGet != null && PackGet == null)
                {
                    if (RoomGet is IUseable)
                    {
                        GameState stav1;

                        referencia_use = (IUseable)RoomGet;
                        stav1 = referencia_use.Use(game);

                        if (stav1 == GameState.SOLVED)
                        {
                            return GameState.SOLVED;
                        }
                        else return GameState.PLAYING;
                    }
                    else Console.WriteLine("Tento predmet sa neda pouzit.");
                }

                if (PackGet != null && RoomGet == null)
                {
                    if (PackGet is IUseable)
                    {
                        GameState stav2;

                        referencia_use = (IUseable)PackGet;
                        stav2 = referencia_use.Use(game);

                        if (stav2 == GameState.SOLVED)
                        {
                            return GameState.SOLVED;
                        }
                        else return GameState.PLAYING;
                    }
                    else Console.WriteLine("Tento predmet sa neda pouzit.");
                }

                if (PackGet != null && RoomGet != null)
                {
                    if (PackGet is IUseable)
                    {
                        GameState stav3;

                        referencia_use = (IUseable)PackGet;
                        stav3 = referencia_use.Use(game);

                        if (stav3 == GameState.SOLVED)
                        {
                            return GameState.SOLVED;
                        }
                        else return GameState.PLAYING;
                    }
                    else Console.WriteLine("Tento predmet sa neda pouzit.");
                }
            }
            return GameState.PLAYING;
        }
    }
}

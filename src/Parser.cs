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
    class Parser
    {
        List<ACommand> prikazy = new List<ACommand>();

        public Parser()
        {
            North sever = new North();
            South juh = new South();
            West zapad = new West();
            East vychod = new East();

            Use pouzi = new Use();
            Get vezmi = new Get();
            Put poloz = new Put();
            LookRound rozhliadniSa = new LookRound();
            Explore preskumaj = new Explore();

            Commands.Commands prikazy = new Commands.Commands();
            Inventary inventar = new Inventary();
            Help pomoc = new Help();

            Load nahraj = new Load();
            Save uloz = new Save();
            Commands.Version verzia = new Commands.Version();
            Quit koniec = new Quit();

            this.prikazy.Add(sever);
            this.prikazy.Add(juh);
            this.prikazy.Add(zapad);
            this.prikazy.Add(vychod);
            this.prikazy.Add(pouzi);
            this.prikazy.Add(inventar);
            this.prikazy.Add(prikazy);
            this.prikazy.Add(koniec);
            this.prikazy.Add(poloz);
            this.prikazy.Add(vezmi);
            this.prikazy.Add(verzia);
            this.prikazy.Add(rozhliadniSa);
            this.prikazy.Add(preskumaj);
            this.Prikazy.Add(pomoc);
            this.prikazy.Add(uloz);
            this.prikazy.Add(nahraj);
        }


        public ACommand GetCommand(string prikaz)
        {
            string akcia, parameter;

            string[] stringSeparators = new string[] { " " };
            string[] result;

            result = prikaz.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (result.Length == 3)
            {
                if ((result[0] == "VEZMI" && result[1] == "CIPOVA" && result[2] == "KARTA")||
                    (result[0] == "POLOZ" && result[1] == "CIPOVA" && result[2] == "KARTA")||
                    (result[0] == "POUZI" && result[1] == "CIPOVA" && result[2] == "KARTA")||
                    (result[0] == "PRESKUMAJ" && result[1] == "CIPOVA" && result[2] == "KARTA")||
                    (result[0] == "VEZMI" && result[1] == "PRIPOJOVACI" && result[2] == "KABEL")||
                    (result[0] == "POLOZ" && result[1] == "PRIPOJOVACI" && result[2] == "KABEL")||
                    (result[0] == "POUZI" && result[1] == "PRIPOJOVACI" && result[2] == "KABEL")||
                    (result[0] == "PRESKUMAJ" && result[1] == "PRIPOJOVACI" && result[2] == "KABEL"))
                {
                    string a = result[0];
                    string b = result[1];
                    string c = result[2];

                    akcia = a;
                    parameter = b + " " + c;
                }
                else
                {
                    akcia = "null";
                    parameter = "null";
                }
            }
            else if (result.Length == 2)
            {
                if (result[0] == "ROZHLIADNI" && result[1] == "SA")
                {
                    string a = result[0];
                    string b = result[1];

                    akcia = a + " " + b;
                    parameter = "null";
                }
                else
                {
                    akcia = result[0];
                    parameter = result[1];
                }
            }
            else if (result.Length == 1)
            {
                akcia = result[0];
                parameter = "null";
            }
            else
            {
                akcia = "null";
                parameter = "null";
            }

            for (int i = 0; i < prikazy.Count; i++)
            {
                if (prikazy[i].Name == akcia)
                {
                    prikazy[i].Params = parameter;
                    return prikazy[i];
                }
            }
            return null;
        }

        public List<ACommand> Prikazy
        {
            get { return prikazy; }
        }
    }
}

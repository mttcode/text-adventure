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
    class Game : IGame
    {
        IRoom aktual;
        Backpack ruksak;
        ACommand ParamOut;
        IRoom B4openT;
        IRoom F6openT;
        GameState stav = GameState.PLAYING;


        public void CreateRooms()
        {
            #region Miestnosti
            Room A1 = new Room("Tvoj byt", "Si vo svojom byte. Prave si obdrzal telefonicky rozhovor od sefa, v ktorom ta poziadal o pomoc pri rieseni pripadu. V byte mas bordel, same flasky a cigaretove ohorky, kreditka, na podlahe preukaz a cipova karta.");
            Room A4 = new Room("Policajna stanica", "Si na policajnej stanici, na recepcii. Sekretarka ta ocakavala, polozila na stol dokumenty.");
            Room A6 = new Room("Bankomat", "Stojis pred bankomatom, nastastie u neho nikto nebol.");
            Room B1 = new Room("Krizovatka", "Stojis pred svojim bytom. Vonku je pekne pocastie, svieti slnko, je krasne leto. Nedaleko je telefonna budka a cukraren. Kusok dalej pred tebou je Expertizny dom.");
            Room B2 = new Room("Ulica", "Fadna ulica lemovana kolajnicami. Na vychod od teba strieka krasna fontana a dalej pred tebou je OD Tesco.");
            Room B3 = new Room("Fontana", "Velka krasna fontana. Vietor pofukujuci na striekajuci prud rozprskava navokol jemne kvapocky vodicky. Skoda, ze si tu nie je kde sadnut. Za fontanou je krizovatka a Urad.");
            Room B4 = new Room("Straz", "Pred vchodom na policajnu stanicu stoja dvaja straznici, ktori nevyzeraju velmi priatelsky. Nepustia ta dnu bez cipovej karty. Na vychode je benzinova pumpa.");
            Room B4open = new Room("Straz", "Pred vchodom na policajnu stanicu stoja dvaja straznici, ktori nevyzeraju velmi priatelsky. Nepustia ta dnu bez cipovej karty. Na vychode je benzinova pumpa.");
            Room B5 = new Room("Benzinova pumpa", "Auta prichadzaju a odchadzaju, tankuju, pumpuju, nadavaju..je to tu zive.");
            Room B6 = new Room("Ulica", "Je tu takmer ludoprazdno. Domy naokolo su zastarale, zrele na opravu. Na severe je bankomat.");
            Room C1 = new Room("Expertizny dom", "Si na expertize. Je tu dost rusno, clovek by nepovedal, kolko ludi tu moze byt. Pred tebou su prepazky s konkretnymi vybavovacimi transakciami. Vyuzil si svoju pravomoc, a tak si nemusel stat v rade.");
            Room C2 = new Room("OD Tesco", "Strasne rusna ulica s vela ludmi vchadzajucimi a vychadzajucimi z obchodneho centra. Zopar bezdomovcov sa potuluje vokol.");
            Room C3 = new Room("Krizovatka", "Stojis na prechode pre chodcov. Velmi husta premavka, pravdepodobne preto, lebo nedaleko je OD Tesco. Pred tebou je Urad a na vychode je tel.budka a trocha dalej vidiet aj el.zastavku.");
            Room C4 = new Room("Ulica", "Napriec ulicou prechadzaju elektricky, nedaleko je tel.budka. Pred tebou je parkovisko na severe je policajna straz a na vychode dalsia krizovatka.");
            Room C5 = new Room("Krizovatka", "Obycajna krizovatka. Na vychode vidiet profesorov byt, ku ktoremu mas pristup. Pred tebou je niekolko metrov budova Kartoteky. Na zapade nic noveho.");
            Room C6 = new Room("Ulica", "Blizko teba stoji panelak s profesorovym bytom. Ulica na ktorej si je ludoprazdna, ale dalej na juhu sa nachadza kniznica.");
            Room C7 = new Room("Profesorov byt", "Nachadzas sa v profesorovom byte. Tu ho zavrazdili rovno na sedadle gulkou priamo do hlavy, nestacil sa ani poriadne obzriet. Boli to profesionali. Cela miestnost je poprelepovana roznymi paskami a oznackovana cislami identifikovanymi dokazne materialy. V rohu obyvacky sa nachadza podla vsetkeho funkcny pocitac. Urcite v nom budu ulozene dokumenty, ktore by ta mohli zaujimat.");
            Room D2 = new Room("Park", "Nadherny park, rozkvitnuty, plno zelene okolo a na pohlad kludnych ludi sediacich po okrajoch cesticky.");
            Room D3 = new Room("Urad", "Si na urade. Je to tu pokojne, ticho. Uctovnicka za priehradkou sa nevie dockat na papiere...");
            Room D4 = new Room("Parkovisko", "Dost prazdne parkovisko. Zopar osobnych aut a dva dodavky.");
            Room D5 = new Room("Kartoteka", "\"Urad pre spracovanie kartotetiek\". Takyto napis visi rovno pri vstupe do miestnosti. Vyzera to tu ako na beznom urade. Je tu dost vydychany vzduch a dve zvednute kvetinace. Na vychode cez okno vidiet kniznicu.");
            Room D6 = new Room("Kniznica", "Stojis na razcesti vedla kniznice. Budova je v dezolatnom stave, keby nebolo napisane na dverach, tazko usudit, ze sa jedna o kniznicu.");
            Room D7 = new Room("OD Lidl", "Na zapade je kniznica. Stojis par metrov od OD Lidl, pravdepodobne maju asi inventuru. Na druhej strane ulice je tel.budka a severnejsie sa tyci panelak.");
            Room E2 = new Room("Park", "Velmi pekny park, cerstvy vzduch, pocut spievat vtaciky a obdalec sa prechadzaju mamicky s kocikmi. Na pravo v dialke vidiet OC Carrefour.");
            Room E3 = new Room("Ulica", "Pekna slnecna ulica lemovana kolajnicami. Z urciteho miesta a pohladu to vyzera ako malebna ulica z minuleho storocia. Zapadne sa vynima nadherny park.");
            Room E4 = new Room("OC Carrefour", "Vela ludi, malo penazi, preto je tu taky prievan. Trocha dalej vidiet ciganov a este dalej bezdomovcov. Za tebou pocut zvlastne zvuky.");
            Room E5 = new Room("Krizovatka", "Nic zvlastne sa tu nenachadza. Zopar odstavenych aut na chodnikoch a potulujuce sa psy okolo kontajnerov.");
            Room E6 = new Room("Krizovatka", "Dalsia z krizovatiek, akurat tato ej zo zlomenou znackou stopky. Na juhu je recepcia, na severe polorozbita budova kniznice.");
            Room E7 = new Room("Ulica", "Odpadky roztrusene po zemi, preplnene kontajnery, mierny zapach a zopar potulujucich maciek.");
            Room F2 = new Room("Park", "Paradny park. Je tu malo ludi, navyse tu nieco zapacha. Tiahne sa to od juhu.");
            Room F3 = new Room("Ulica", "Obycajna ulica. Ani zivej duse tu niet, ani budovy. Akasi prejazdna ulica.");
            Room F4 = new Room("Psychiatricky ustav", "Si na psychiatrii. Okolo teba je zopar zvedanych ludi. Nastastie nedaleko teba je sestra. Ludia okolo teba su dost vynaliezavy, ked si jeden z nich dokazal omotat okolo krku, ak ma zrak neklame, pripojovaci kabel od pocitaca. Byt tebou urobim s tym nieco.");
            Room F5 = new Room("Nadvorie", "Uzky otvoreny park, stojis uprostred cesty veducej na psychiatricke oddelenie. Okolo cesty su lavicky, na ktorych sedia postarsi ludia.");
            Room F6 = new Room("Recepcia", "Si na recepcii. Tiche prostredie, kde v rohoch miestnosti sa tycia velke kvetinace a uprostred sedi sympaticka usmievava slecna. Dostal si sa na psychiatricke oddelenie. Teta ta pusti dnu po preukazani totoznosti alebo po preukazani nesvojpravnosti...");
            Room F6open = new Room("Recepcia", "Si na recepcii. Tiche prostredie, kde v rohoch miestnosti sa tycia velke kvetinace a uprostred sedi sympaticka usmievava slecna. Dostal si sa na psychiatricke oddelenie. Teta ta pusti dnu po preukazani totoznosti alebo po preukazani nesvojpravnosti...");
            Room G1 = new Room("Smetisko", "Si na velmi smradlavom a spinavom smetisku. Vsade okolo vecsie, mensie kopy odpadu, casti nabytkov, pneumatiky a aj znacne mnozstvo rozbitych pocitacov a pocitacovych komponentov.");
            Room G2 = new Room("Ulica", "Znacne zdevastovana a spinava ulica na ktorej sa, ale nedaleko nachadza tel.budka. Uplne rozbita. O funkcnosti niet pochyb. Ako obvykle v tychto stvrtiach. Na zapade citit znacny zapach.");
            Room G3 = new Room("Ulica", "Zatuchnuta temna ulica. Kontajnery a zopar krabic okolo.");
            Room G4 = new Room("Luka", "Asi 1 ar krasnej zelenej luky. Naco tu asi bude...");
            Room G5 = new Room("Luka", "Pekna luka ustiaca do ulicky smerom do lesa. Kiez by si tam mohol ist...");
            #endregion

            this.B4openT = B4open;
            this.F6openT = F6open;

            #region Miestnosti - vychodiska
            A1.SetExits(null, B1, null, null);     //S,J,V,Z
            B1.SetExits(A1, C1, B2, null);
            C1.SetExits(B1, null, C2, null);
            G1.SetExits(null, null, G2, null);
            B2.SetExits(null, C2, B3, B1);
            C2.SetExits(B2, D2, C3, C1);
            D2.SetExits(C2, E2, D3, null);
            E2.SetExits(D2, F2, E3, null);
            F2.SetExits(E2, G2, F3, null);
            G2.SetExits(F2, null, G3, G1);
            B3.SetExits(null, C3, B4, B2);
            C3.SetExits(B3, D3, C4, C2);
            D3.SetExits(C3, E3, D4, D2);
            E3.SetExits(D3, F3, E4, E2);
            F3.SetExits(E3, G3, null, F2);
            G3.SetExits(F3, null, null, G2);
            A4.SetExits(null, B4, null, null);
            B4.SetExits(null, C4, B5, B3);
            B4open.SetExits(A4, C4, B5, B3);        //dvere
            C4.SetExits(B4, D4, C5, C3);
            D4.SetExits(C4, E4, D5, D3);
            E4.SetExits(D4, null, E5, E3);
            F4.SetExits(null, G4, F5, null);
            G4.SetExits(F4, null, G5, null);
            B5.SetExits(null, C5, B6, B4);
            C5.SetExits(B5, D5, C6, C4);
            D5.SetExits(C5, E5, D6, D4);
            E5.SetExits(D5, null, E6, E4);
            F5.SetExits(null, G5, F6, F4);
            G5.SetExits(F5, null, null, G4);
            A6.SetExits(null, B6, null, null);
            B6.SetExits(A6, C6, null, B5);
            C6.SetExits(B6, D6, C7, C5);
            D6.SetExits(C6, E6, D7, D5);
            E6.SetExits(D6, F6, E7, E5);
            F6.SetExits(E6, null, null, null);
            F6open.SetExits(E6, null, null, F5);
            C7.SetExits(null, D7, null, C6);
            D7.SetExits(C7, E7, null, D6);
            E7.SetExits(D7, null, null, E6);
            #endregion

            Card preukaz = new Card();
            CardFile kartoteka = new CardFile();
            Cash peniaze = new Cash();
            Code kod = new Code();
            ConnectingCable pripKabel = new ConnectingCable();
            CreditCard kreditka = new CreditCard();
            Diskette disketa = new Diskette();
            Documents dokumenty = new Documents();
            ChipCard cipKarta = new ChipCard();
            Password heslo = new Password();
            Patient pacient = new Patient();

            A1.AddItem(preukaz);
            A1.AddItem(cipKarta);
            A1.AddItem(kreditka);
            A4.AddItem(dokumenty);
            G1.AddItem(disketa);
            F4.AddItem(pacient);
            F4.AddItem(pripKabel);

            CurrentRoom = A1;
        }

        public void Intro()
        {
            int sirkaObr = Console.WindowWidth;

            Console.Title = "Stalker";

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < sirkaObr; i++)
                Console.Write("=");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--->> S T A L K E R            <--->             M A N D R A G O R A <<---");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < sirkaObr; i++)
                Console.Write("=");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\nDetektivom, policajtom a dokonca ani psom sa nepodarilo po dlhom case vyriesit vrazdu velmi nadaneho vedca, prof.Trosku. Za velkym stolom sa po dokladnom prestudovani materialov vrchny velitel armadnych ozbrojenych sil rozhodol, ze na tento specialny pripad poveria prave teba ako nadaneho agenta pre objasnenie celeho pripadu. Nech ti teda pan Boh pomaha.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nVysvetlivky:\n");
            Console.ResetColor();

            Parser parsovac = new Parser();
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));

            int pocet = 0;

            foreach (string colorName in colorNames)
            {
                pocet++;

                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                if (color == ConsoleColor.Black) continue;

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = color;

                if (pocet == 14) break;

                Console.WriteLine("{0} - {1}", parsovac.Prikazy[pocet].Name, parsovac.Prikazy[pocet].Description);
                Console.ResetColor();
            }

            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LOADING.........................................");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done.\n");
            Console.ResetColor();
            Console.WriteLine("Stlacenim lubovolnej klavesy spustite hru...");

            Console.ReadKey(true);
            Console.Clear();
        }


        public void PushItem(string name)
        {
            AItem ExplRoom = CurrentRoom.GetItem(name);

            if (ExplRoom == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTaky predmet sa v miestnosti nenachadza.\n");
                Console.ResetColor();
            }
            else
            {
                if (ExplRoom is IMoveable)
                {
                    bool kapacita;

                    kapacita = Backpack.Add(ExplRoom);

                    if (kapacita)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nDo batoha si vlozil predmet: {0}.\n", ExplRoom.Name);
                        Console.ResetColor();

                        CurrentRoom.RemoveItem(ExplRoom);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nBatoh je plny.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDany predmet sa neda zobrat do batoha.\n");
                    Console.ResetColor();
                }
            }
        }

        public void PopItem(string name)
        {
            AItem ExplPack = Backpack.GetItem(name);

            if (ExplPack == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDany predmet sa nenachadza v batohu.\n");
                Console.ResetColor();
            }
            else
            {
                AItem predmet;
                predmet = Backpack.Remove(name);
                CurrentRoom.AddItem(predmet);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPredmet {0} je v miestnosti.\n", CurrentRoom.GetItem(name).Name);
                Console.ResetColor();
            }
        }

        public void ExploreItem(string name)
        {
            AItem RoomGet = CurrentRoom.GetItem(name);
            AItem PackGet = Backpack.GetItem(name);

            if (RoomGet == null && PackGet == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nZvoleny predmet nevidim.\n");
                Console.ResetColor();
            }
            else
            {
                if (RoomGet != null && PackGet == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", RoomGet.Description);
                    Console.ResetColor();
                }

                if (PackGet != null && RoomGet == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", PackGet.Description);
                    Console.ResetColor();
                }

                if (PackGet != null && RoomGet != null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", PackGet.Description);
                    Console.ResetColor();
                }
            }
        }


        public void Reset()
        {
            GC.Collect();
            
            Room roomReset = (Room)CurrentRoom;
            roomReset.ResetItem.Clear();

            Backpack backpackReset = (Backpack)Backpack;
            backpackReset.ResetBackPack.Clear();

            ruksak = new Backpack(10);
            CreateRooms();

            CurrentRoom.Show();
        }


        public void Play()
        {
            Intro();
            CreateRooms();
            CurrentRoom.Show();

            ruksak = new Backpack(10);
            Parser parser = new Parser();
            GameState stav = GameState.PLAYING;
            string vstup;
            string paramSave;

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

            History historia = History.GetInstance();
            historia.Clear();
            

            while (GameState.PLAYING == stav)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Zadaj prikaz>");
                Console.ResetColor();

                vstup = Console.ReadLine();

                ACommand cmd = parser.GetCommand(vstup);
                ParamOut = cmd;

                if (cmd == null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTaky prikaz nepoznam.\n");
                    Console.ResetColor();

                    stav = GameState.PLAYING;
                }
                else
                {
                    if (cmd.Name == "SEVER")
                    {
                        historia.Add("SEVER");
                        stav = sever.Execute(this);
                    }
                    if (cmd.Name == "ZAPAD")
                    {
                        historia.Add("ZAPAD");
                        stav = zapad.Execute(this);
                    }
                    if (cmd.Name == "VYCHOD")
                    {
                        historia.Add("VYCHOD");
                        stav = vychod.Execute(this);
                    }
                    if (cmd.Name == "JUH")
                    {
                        historia.Add("JUH");
                        stav = juh.Execute(this);
                    }
                    if (cmd.Name == "POUZI")
                    {
                        paramSave = "POUZI " + ParamOut.Params;
                        historia.Add(paramSave);
                        stav = pouzi.Execute(this);
                    }
                    if (cmd.Name == "VEZMI")
                    {
                        paramSave = "VEZMI " + ParamOut.Params;
                        historia.Add(paramSave);
                        stav = vezmi.Execute(this);
                    }
                    if (cmd.Name == "POLOZ")
                    {
                        paramSave = "POLOZ " + ParamOut.Params;
                        historia.Add(paramSave);
                        stav = poloz.Execute(this);
                    }
                    if (cmd.Name == "INVENTAR")
                    {
                        historia.Add("INVENTAR");
                        stav = inventar.Execute(this);
                    }
                    if (cmd.Name == "PRIKAZY")
                    {
                        historia.Add("PRIKAZY");
                        stav = prikazy.Execute(this);
                    }
                    if (cmd.Name == "ROZHLIADNI SA")
                    {
                        historia.Add("ROZHLIADNI SA");
                        stav = rozhliadniSa.Execute(this);
                    }
                    if (cmd.Name == "VERZIA")
                    {
                        historia.Add("VERZIA");
                        stav = verzia.Execute(this);
                    }
                    if (cmd.Name == "PRESKUMAJ")
                    {
                        paramSave = "PRESKUMAJ " + ParamOut.Params;
                        historia.Add(paramSave);
                        stav = preskumaj.Execute(this);
                    }
                    if (cmd.Name == "POMOC")
                    {
                        historia.Add("POMOC");
                        stav = pomoc.Execute(this);
                    }
                    if (cmd.Name == "LOAD")
                    {
                        stav = nahraj.Execute(this);
                    }
                    if (cmd.Name == "SAVE")
                    {
                        stav = uloz.Execute(this);
                    }

                    if (cmd.Name == "KONIEC")
                    {
                        stav = koniec.Execute(this);
                    }
                }
            }
        }


        public GameState ProcessCommand(string command)
        {
            Parser parser = new Parser();

            North sever = new North();
            South juh = new South();
            West zapad = new West();
            East vychod = new East();

            Use pouzi = new Use();
            Get vezmi = new Get();
            Put poloz = new Put();

            Commands.Commands prikazy = new Commands.Commands();
            Inventary inventar = new Inventary();

            ACommand cmd = parser.GetCommand(command);
            ParamOut = cmd;


            if (cmd.Name == "SEVER")
            {
                stav = sever.Execute(this);
                return stav;
            }
            if (cmd.Name == "ZAPAD")
            {
                stav = zapad.Execute(this);
                return stav;
            }
            if (cmd.Name == "VYCHOD")
            {
                stav = vychod.Execute(this);
                return stav;
            }
            if (cmd.Name == "JUH")
            {
                stav = juh.Execute(this);
                return stav;
            }
            if (cmd.Name == "POUZI")
            {
                stav = pouzi.Execute(this);
                return stav;
            }
            if (cmd.Name == "VEZMI")
            {
                stav = vezmi.Execute(this);
                return stav;
            }
            if (cmd.Name == "POLOZ")
            {
                stav = poloz.Execute(this);
                return stav;
            }
            if (cmd.Name == "INVENTAR")
            {
                stav = inventar.Execute(this);
                return stav;
            }
            if (cmd.Name == "PRIKAZY")
            {
                stav = prikazy.Execute(this);
                return stav;
            }
            return GameState.PLAYING;
        }

        public void ShowBackpack()
        {
            ruksak.ShowBackpack();
        }

        public IBackpack Backpack
        {
            get { return ruksak; }
        }

        public IRoom CurrentRoom
        {
            set
            {
                this.aktual = value;
            }

            get
            {
                return aktual;
            }
        }

        public ACommand Parameter
        {
            set
            {
                this.ParamOut = value;
            }
            get
            {
                return ParamOut;
            }
        }

        public IRoom Be4
        {
            get { return B4openT; }

        }

        public IRoom Ef6
        {
            get { return F6openT; }

        }
    }
}

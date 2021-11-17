using System;
using System.Collections.Generic;

namespace bitva
{
    class Program
    {
        static double dmgc;
        static Random r = new Random();
        static List<SuperHrdina> osemfinale = new List<SuperHrdina>();
        static List<SuperHrdina> stvrtfinale = new List<SuperHrdina>();
        static List<SuperHrdina> semifinale = new List<SuperHrdina>();
        static List<SuperHrdina> finale = new List<SuperHrdina>();
        static List<SuperHrdina> zadUdaje = new List<SuperHrdina>();
        static void Main(string[] args)
        {
            int pocetS;
            Console.Write("Zadajte pocet superhrdinov [2,4,8,16]:");
            while (true)
            {
                int.TryParse(Console.ReadLine(), out pocetS);
                if (pocetS == 2 || pocetS == 4 || pocetS == 8 || pocetS == 16)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Prosim int 2,4,8 alebo 16:");
                }
            }                                                   //vstup o pocte hracov                                                     
            int ratac;
            switch (pocetS)                                                     //switch podla poctu hrdinov
            {
                case 2:
                    {
                        ratac = 0;
                        VstupUdajov(finale, pocetS);
                        Tabulka(finale);
                        Pavuk(finale);
                        Boje(finale, ratac);
                        Console.WriteLine("Koniec finale.");
                        EfektneCarky();
                        break;
                    }
                case 4:
                    {
                        ratac = 0;
                        VstupUdajov(semifinale, pocetS);
                        Tabulka(semifinale);
                        Pavuk(semifinale);
                        Boje(semifinale, ratac);
                        Console.WriteLine("Koniec semifinale.");
                        EfektneCarky();
                        Pavuk(finale);
                        ratac = 0;
                        Boje(finale, ratac);
                        Console.WriteLine("Koniec finale.");
                        EfektneCarky();
                        break;
                    }
                case 8:
                    {
                        ratac = 0;
                        VstupUdajov(stvrtfinale, pocetS);
                        Tabulka(stvrtfinale);
                        Pavuk(stvrtfinale);
                        Boje(stvrtfinale, ratac);
                        Console.WriteLine("Koniec stvrtfinale.");
                        EfektneCarky();
                        Pavuk(semifinale);
                        ratac = 0;
                        Boje(semifinale, ratac);
                        Console.WriteLine("Koniec semifinale.");
                        EfektneCarky();
                        Pavuk(finale);
                        ratac = 0;
                        Boje(finale, ratac); 
                        Console.WriteLine("Koniec finale.");
                        EfektneCarky();
                        break;
                    }
                case 16:
                    {
                        ratac = 0;
                        VstupUdajov(osemfinale, pocetS);
                        Tabulka(osemfinale);
                        Pavuk(osemfinale);
                        Boje(osemfinale, ratac);
                        Console.WriteLine("Koniec osemfinale.");
                        EfektneCarky();
                        Pavuk(stvrtfinale);
                        ratac = 0;
                        Boje(stvrtfinale, ratac);
                        Console.WriteLine("koniec stvrtfinale.");
                        EfektneCarky();
                        Pavuk(semifinale);
                        ratac = 0;
                        Boje(semifinale, ratac);
                        Console.WriteLine("Koniec semifinale.");
                        EfektneCarky();
                        Pavuk(finale);
                        Boje(finale, ratac);
                        Console.WriteLine("Koniec finale.");
                        EfektneCarky();
                        break;
                    }
            }
        }
        static void Boje(List<SuperHrdina> list, int ratac)
        {
            for (int i = 0; i < list.Count; i++)
            {
                zadUdaje.Add(new SuperHrdina(list[i].meno, list[i].hp, list[i].dmg, list[i].def));
            }
            Console.Write("Stlacte klavesu pre pokracovanie.");
            Console.ReadKey();
            Console.Clear();
            for (int i = 0; i < (list.Count/2); i++)
            {
                ratac++;
                EfektneCarky();
                Console.WriteLine(ratac + ". suboj");
                EfektneCarky();
                Suboj(i, list, zadUdaje);
            }
            zadUdaje.Clear();
        }
        static void Suboj(int i, List<SuperHrdina> ListA, List<SuperHrdina> ListB)//metoda na suboje - mozno skratit ?
        {
            while (true)
            {
                int poradie = r.Next(2);
                if (poradie == 0)
                {
                    if (NaplnacListov(i, ListA, ListB, 1, 0))
                        break;
                    if (NaplnacListov(i, ListA, ListB, 0, 1))
                        break;
                }
                else
                {
                    if (NaplnacListov(i, ListA, ListB, 0, 1))
                        break;
                    if (NaplnacListov(i, ListA, ListB, 1, 0))
                        break;
                }
            }
        }
        static double Utokobrana(double dmg, double def, double hp)//metoda na vypocet udeleneho poskodenia
        {
            dmg = dmg * (100+r.Next(-25, 26))/100;
            def = def * (100+r.Next(-25, 26))/100;
            def = (def * 0.875) / 100;
            dmgc = dmg - dmg * def;
            dmgc = Math.Round(dmgc, 3);
            if (dmgc < 0)
                dmgc = 0;
            return hp - dmgc;
        }
        static void Udaje(int i, List<SuperHrdina> List)//metoda na zber udajov o jednotlivych superhrdinov
        {
            Console.WriteLine("Zadajte meno " + i + ". superhrdinu: ");
            string meno = Console.ReadLine();
            Console.Clear();
            int hp;
            double dmg;
            double def;
            Console.WriteLine("Zadajte hp " + i + ". superhrdinu[1 - 1000]: ");
            while (true)
            {
                int.TryParse(Console.ReadLine(), out hp);
                if (hp >= 1 && hp <= 1000)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Prosim int od 1 po 1000 vratane:");
                }
            }
            Console.WriteLine("Zadajte dmg " + i + ". superhrdinu[0,01 - 100,00]: ");
            while (true)
            {
                bool b = double.TryParse(Console.ReadLine(), out dmg);
                if ((dmg >= 0.01 && dmg <= 100.00) && b == true)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Prosim double od 0,01 po 100,00 vratane:");
                }
            }
            Console.WriteLine("Zadajte def " + i + ". superhrdinu[0,01 - 100,00]: ");
            while (true)
            {
                bool b = double.TryParse(Console.ReadLine(), out def);
                if ((def >= 0.01 && def <= 100.00) && b == true)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Prosim double od 0,01 po 100,00 vratane:");
                }
            }
            List.Add(new SuperHrdina(meno, hp, dmg, def));
        }
        static void Fixudaje(int i, List<SuperHrdina> List, double fix)//metoda pre rychle vyplnenie udajov
        {
            Console.WriteLine("Zadajte meno " + i + ". superhrdinu: ");
            string meno = Console.ReadLine();
            Console.Clear();
            List.Add(new SuperHrdina(meno, fix * 10, fix, fix));
        }
        static void Tabulka(List<SuperHrdina> List)//metoda na vytvorenie uvodnej tabulky a pavuka + zamiesanie (shuffle) uvodneho listu
        {
            Console.WriteLine("Tabulka");
            foreach (var SuperHrdina in List)
            {
                Console.Write("| meno: " + SuperHrdina.meno);
                Console.Write("| HP: " + SuperHrdina.hp);
                Console.Write("| DMG: " + SuperHrdina.dmg);
                Console.Write("| DEF: " + SuperHrdina.def);
                Console.WriteLine("|");
            }
            List.Shuffle();
        }
        static void VstupUdajov(List<SuperHrdina> list, int pocetS)//metoda na ziadanie rychleho/manualneho zadavania udajov
        {
            while (true)
            {
                Console.WriteLine("Chcete puzit rychle alebo manualne vyplnenie udajov?[r - rychle / m - manualne]");
                string volba1 = Console.ReadLine();
                Console.Clear();
                if (volba1 == "r")
                {
                    for (int a = 1; a <= pocetS; a++)
                    {

                        while (true)
                        {
                            Console.WriteLine("Zadajte cislo fix udajov[10,20,30,40,50,60,70,80,90,100]");
                            double.TryParse(Console.ReadLine(), out double volba2);
                            Console.Clear();
                            if ((volba2 >=10) && (volba2<=100) && (volba2 % 10 == 0))
                            {
                                Fixudaje(a, list, volba2);
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    break;
                }
                else if (volba1 == "m")
                {
                    for (int a = 1; a <= pocetS; a++)
                    {
                        Udaje(a, list);
                        Console.Clear();
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Prosim zadaj charakter 'r' alebo 'm'.");
                }
            }
        }
        static void Pavuk(List<SuperHrdina> list)//metoda na vygenerovania pavuka
        {
            Console.WriteLine("Pavuk:");
            int ratac = 1;
            Console.WriteLine("__________");
            Console.WriteLine("          ");
            foreach (var SuperHrdina in list)
            {
                ratac++;
                Console.WriteLine("| " + SuperHrdina.meno + " |");
                if (ratac == 2)
                {
                    Console.WriteLine("----vs----");
                    ratac = 0;
                }
                else
                {
                    Console.WriteLine("__________");
                    Console.WriteLine("          ");
                }
            }
        }
        static void EfektneCarky()
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("                       ");
        }
        static bool NaplnacListov(int i, List<SuperHrdina> ListA, List<SuperHrdina> ListB, int ciselko1, int ciselko2)
        {
            ListA[(i * 2) + ciselko1].hp = Utokobrana(ListA[i * 2 + ciselko2].dmg, ListA[(i * 2) + ciselko1].def, ListA[(i * 2) + ciselko1].hp);
            Console.WriteLine("Prvy udiera " + ListA[i * 2 + ciselko2].meno + " a ubera " + ListA[(i * 2) + ciselko1].meno + " " + dmgc + " dmg");
            Console.WriteLine(ListA[(i * 2) + ciselko1].meno + " ostava " + Math.Round(ListA[(i * 2) + ciselko1].hp, 3) + " hp");
            if (ListA[(i * 2) + 1].hp <= 0)
            {
                EfektneCarky();
                Console.WriteLine("Vyhrava " + ListA[i * 2 + ciselko2].meno);
                EfektneCarky();
                if (ListA == osemfinale)
                    stvrtfinale.Add(new SuperHrdina(ListB[i * 2 + ciselko2].meno, ListB[i * 2 + ciselko2].hp, ListB[i * 2 + ciselko2].dmg, ListB[i * 2 + ciselko2].def));
                if (ListA == stvrtfinale)
                    semifinale.Add(new SuperHrdina(ListB[i * 2 + ciselko2].meno, ListB[i * 2 + ciselko2].hp, ListB[i * 2 + ciselko2].dmg, ListB[i * 2 + ciselko2].def));
                if (ListA == semifinale)
                    finale.Add(new SuperHrdina(ListB[i * 2 + ciselko2].meno, ListB[i * 2 + ciselko2].hp, ListB[i * 2 + ciselko2].dmg, ListB[i * 2 + ciselko2].def));
                if (ListA == finale)
                    Console.WriteLine("Celkovym vitazom sa stava: " + ListA[i * 2 + ciselko2].meno);
                return true;
            }
            return false;
        }
    }
}
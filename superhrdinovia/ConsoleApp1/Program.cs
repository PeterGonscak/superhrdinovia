﻿using System;
using System.Collections.Generic;

namespace bitva
{
    class Program
    {
        static double dmgc;
        static Random r = new Random();
        static List<SuperHrdina> osemfinale = new List<SuperHrdina>();
        static List<SuperHrdina> stvrtfinale = new List<SuperHrdina>();
        static List<SuperHrdina> semifinale = new List<SuperHrdina>();              //staticke premenne a listy
        static List<SuperHrdina> finale = new List<SuperHrdina>();
        static List<SuperHrdina> zadUdaje = new List<SuperHrdina>();
        static void Main(string[] args)
        {
            int pocetS = 0;
            Console.Write("Zadajte pocet superhrdinov [2,4,8,16]:");
            while (true)
            {
                bool b = int.TryParse(Console.ReadLine(), out pocetS);
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
                        vstupUdajov(finale, pocetS);
                        tabulka(finale);
                        pavuk(finale);
                        boje(finale, ratac);
                        Console.WriteLine("Koniec finale.");
                        efektneCarky();
                        break;
                    }
                case 4:
                    {
                        ratac = 0;
                        vstupUdajov(semifinale, pocetS);
                        tabulka(semifinale);
                        pavuk(semifinale);
                        boje(semifinale, ratac);
                        Console.WriteLine("Koniec semifinale.");
                        efektneCarky();
                        pavuk(finale);
                        ratac = 0;
                        boje(finale, ratac);
                        Console.WriteLine("Koniec finale.");
                        efektneCarky();
                        break;
                    }
                case 8:
                    {
                        ratac = 0;
                        vstupUdajov(stvrtfinale, pocetS);
                        tabulka(stvrtfinale);
                        pavuk(stvrtfinale);
                        boje(stvrtfinale, ratac);
                        Console.WriteLine("Koniec stvrtfinale.");
                        efektneCarky();
                        pavuk(semifinale);
                        ratac = 0;
                        boje(semifinale, ratac);
                        Console.WriteLine("Koniec semifinale.");
                        efektneCarky();
                        pavuk(finale);
                        ratac = 0;
                        boje(finale, ratac); 
                        Console.WriteLine("Koniec finale.");
                        efektneCarky();
                        break;
                    }
                case 16:
                    {
                        ratac = 0;
                        vstupUdajov(osemfinale, pocetS);
                        tabulka(osemfinale);
                        pavuk(osemfinale);
                        boje(osemfinale, ratac);
                        Console.WriteLine("Koniec osemfinale.");
                        efektneCarky();
                        pavuk(stvrtfinale);
                        ratac = 0;
                        boje(stvrtfinale, ratac);
                        Console.WriteLine("koniec stvrtfinale.");
                        efektneCarky();
                        pavuk(semifinale);
                        ratac = 0;
                        boje(semifinale, ratac);
                        Console.WriteLine("Koniec semifinale.");
                        efektneCarky();
                        pavuk(finale);
                        boje(finale, ratac);
                        Console.WriteLine("Koniec finale.");
                        efektneCarky();
                        break;
                    }
            }
        }
        static void boje(List<SuperHrdina> list, int ratac)
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
                efektneCarky();
                Console.WriteLine(ratac + ". suboj");
                efektneCarky();
                suboj(i, list, zadUdaje);
            }
            zadUdaje.Clear();
        }
        static void suboj(int i, List<SuperHrdina> ListA, List<SuperHrdina> ListB)//metoda na suboje - mozno skratit ?
        {
            while (true)
            {
                int poradie = r.Next(2);
                if (poradie == 0)
                {
                    ListA[(i * 2) + 1].hp = utokobrana(ListA[i * 2].dmg, ListA[(i * 2) + 1].def, ListA[(i * 2) + 1].hp);
                    Console.WriteLine("Prvy udiera " + ListA[i * 2].meno + " a ubera " + ListA[(i * 2) + 1].meno + " " + dmgc + " dmg");
                    Console.WriteLine(ListA[(i * 2) + 1].meno + " ostava " + Math.Round(ListA[(i * 2) + 1].hp, 3) + " hp");
                    if (ListA[(i * 2) + 1].hp <= 0)
                    {
                        efektneCarky();
                        Console.WriteLine("Vyhrava " + ListA[(i * 2)].meno);
                        efektneCarky();
                        if (ListA == osemfinale)
                            stvrtfinale.Add(new SuperHrdina(ListB[(i * 2)].meno, ListB[(i * 2)].hp, ListB[(i * 2)].dmg, ListB[(i * 2)].def));
                        if (ListA == stvrtfinale)
                            semifinale.Add(new SuperHrdina(ListB[(i * 2)].meno, ListB[(i * 2)].hp, ListB[(i * 2)].dmg, ListB[(i * 2)].def));
                        if (ListA == semifinale)
                            finale.Add(new SuperHrdina(ListB[(i * 2)].meno, ListB[(i * 2)].hp, ListB[(i * 2)].dmg, ListB[(i * 2)].def));
                        if (ListA == finale)
                            Console.WriteLine("Celkovym vitazom sa stava: " + ListA[(i * 2)].meno);
                        break;
                    }
                    ListA[i * 2].hp = utokobrana(ListA[(i * 2) + 1].dmg, ListA[i * 2].def, ListA[i * 2].hp);
                    Console.WriteLine("Spet udiera " + ListA[(i * 2) + 1].meno + " a ubera " + ListA[i * 2].meno + " " + dmgc + " dmg");
                    Console.WriteLine(ListA[i * 2].meno + " ostava " + Math.Round(ListA[i * 2].hp, 3) + " hp");
                    if (ListA[i * 2].hp <= 0)
                    {
                        efektneCarky();
                        Console.WriteLine("Vyhrava " + ListA[(i * 2) + 1].meno);
                        efektneCarky();
                        if (ListA == osemfinale)
                            stvrtfinale.Add(new SuperHrdina(ListB[(i * 2) + 1].meno, ListB[(i * 2) + 1].hp, ListB[(i * 2) + 1].dmg, ListB[(i * 2) + 1].def));
                        if (ListA == stvrtfinale)
                            semifinale.Add(new SuperHrdina(ListB[(i * 2) + 1].meno, ListB[(i * 2) + 1].hp, ListB[(i * 2) + 1].dmg, ListB[(i * 2) + 1].def));
                        if (ListA == semifinale)
                            finale.Add(new SuperHrdina(ListB[(i * 2) + 1].meno, ListB[(i * 2) + 1].hp, ListB[(i * 2) + 1].dmg, ListB[(i * 2) + 1].def));
                        if (ListA == finale)
                            Console.WriteLine("Celkovym vitazom sa stava: " + ListA[(i * 2) + 1].meno);
                        break;
                    }
                }
                else
                {
                    ListA[i * 2].hp = utokobrana(ListA[(i * 2) + 1].dmg, ListA[i * 2].def, ListA[i * 2].hp);
                    Console.WriteLine("Prvy udiera " + ListA[(i * 2) + 1].meno + " a ubera " + ListA[i * 2].meno + " " + dmgc + " dmg");
                    Console.WriteLine(ListA[i * 2].meno + " ostava " + Math.Round(ListA[i * 2].hp, 3) + " hp");
                    if (ListA[i * 2].hp <= 0)
                    {
                        efektneCarky();
                        Console.WriteLine("Vyhrava " + ListA[(i * 2) + 1].meno);
                        efektneCarky();
                        if (ListA == osemfinale)
                            stvrtfinale.Add(new SuperHrdina(ListB[(i * 2) + 1].meno, ListB[(i * 2) + 1].hp, ListB[(i * 2) + 1].dmg, ListB[(i * 2) + 1].def));
                        if (ListA == stvrtfinale)
                            semifinale.Add(new SuperHrdina(ListB[(i * 2) + 1].meno, ListB[(i * 2) + 1].hp, ListB[(i * 2) + 1].dmg, ListB[(i * 2) + 1].def));
                        if (ListA == semifinale)
                            finale.Add(new SuperHrdina(ListB[(i * 2) + 1].meno, ListB[(i * 2) + 1].hp, ListB[(i * 2) + 1].dmg, ListB[(i * 2) + 1].def));
                        if (ListA == finale)
                            Console.WriteLine("Celkovym vitazom sa stava: " + ListA[(i * 2) + 1].meno);
                        break;
                    }
                    ListA[(i * 2) + 1].hp = utokobrana(ListA[i * 2].dmg, ListA[(i * 2) + 1].def, ListA[(i * 2) + 1].hp);
                    Console.WriteLine("Spet udiera " + ListA[i * 2].meno + " a ubera " + ListA[(i * 2) + 1].meno + " " + dmgc + " dmg");
                    Console.WriteLine(ListA[(i * 2) + 1].meno + " ostava " + Math.Round(ListA[(i * 2) + 1].hp, 3) + " hp");
                    if (ListA[(i * 2) + 1].hp <= 0)
                    {
                        efektneCarky();
                        Console.WriteLine("Vyhrava " + ListA[(i * 2)].meno);
                        efektneCarky();
                        if (ListA == osemfinale)
                            stvrtfinale.Add(new SuperHrdina(ListB[(i * 2)].meno, ListB[(i * 2)].hp, ListB[(i * 2)].dmg, ListB[(i * 2)].def));
                        if (ListA == stvrtfinale)
                            semifinale.Add(new SuperHrdina(ListB[(i * 2)].meno, ListB[(i * 2)].hp, ListB[(i * 2)].dmg, ListB[(i * 2)].def));
                        if (ListA == semifinale)
                            finale.Add(new SuperHrdina(ListB[(i * 2)].meno, ListB[(i * 2)].hp, ListB[(i * 2)].dmg, ListB[(i * 2)].def));
                        if (ListA == finale)
                            Console.WriteLine("Celkovym vitazom sa stava: " + ListA[(i * 2)].meno);
                        break;
                    }
                }
            }
        }
        static double utokobrana(double dmg, double def, double hp)//metoda na vypocet udeleneho poskodenia
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
        static void udaje(int i, List<SuperHrdina> List)//metoda na zber udajov o jednotlivych superhrdinov
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
                bool b = int.TryParse(Console.ReadLine(), out hp);
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
        static void fixudaje(int i, List<SuperHrdina> List, double fix)//metoda pre rychle vyplnenie udajov
        {
            Console.WriteLine("Zadajte meno " + i + ". superhrdinu: ");
            string meno = Console.ReadLine();
            Console.Clear();
            List.Add(new SuperHrdina(meno, fix * 10, fix, fix));
        }
        static void tabulka(List<SuperHrdina> List)//metoda na vytvorenie uvodnej tabulky a pavuka + zamiesanie (shuffle) uvodneho listu
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
        static void vstupUdajov(List<SuperHrdina> list, int pocetS)//metoda na ziadanie rychleho/manualneho zadavania udajov
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
                            string volba2 = Console.ReadLine();
                            Console.Clear();
                            if (volba2 == "10" || volba2 == "20" || volba2 == "30" || volba2 == "40" || volba2 == "50" || volba2 == "60" || volba2 == "70" || volba2 == "80" || volba2 == "90" || volba2 == "100")
                            {
                                fixudaje(a, list, double.Parse(volba2));
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
                        udaje(a, list);
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
        static void pavuk(List<SuperHrdina> list)//metoda na vygenerovania pavuka
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
        static void efektneCarky()
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("                       ");
        }
    }
}
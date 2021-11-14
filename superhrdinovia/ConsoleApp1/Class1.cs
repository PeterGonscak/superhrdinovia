using System;
using System.Collections.Generic;
using System.Threading;

namespace bitva
{
    class SuperHrdina
    {
        public string meno;
        public double hp;
        public double dmg;
        public double def;

        public SuperHrdina(string meno1, double hp1, double dmg1,double def1)
        {
            meno = meno1;
            hp = hp1;
            dmg = dmg1;
            def = def1;
        }
        public string Meno
        {
            get { return meno; }
            set { meno = value; }
        }
        public double Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public double Dmg
        {
            get { return dmg; }
            set { dmg = value; }
        }
        public double Def
        {
            get { return def; }
            set { def = value; }
        }
    }
    public static class ThreadSafeRandom                //skopirovane z netu pravdebodobne bezbecnejsie = nie cisto na baze aktualneho casu
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list) //metoda na zamiesanie listu obj.
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}


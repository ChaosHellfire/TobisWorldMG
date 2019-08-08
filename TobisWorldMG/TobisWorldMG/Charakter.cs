using System;
using System.Collections.Generic;
using System.Text;

namespace TobisWorldMG
{
    public class Charakter
    {
        private static Charakter c;
        public static Charakter instance { get { if (c == null) { c = new Charakter(); } return c; } }

        public string Name { get => name; set => name = value; }
        public int Body { get => body; set => body = value; }
        public int Mind { get => mind; set => mind = value; }
        public int Feeling { get => feeling; set => feeling = value; }
        public int Health { get => health; set => health = value; }
        public int MentalHealth { get => mentalHealth; set => mentalHealth = value; }
        public int ManaStorage { get => manaStorage; set => manaStorage = value; }
        public int ManaOutput { get => manaOutput; set => manaOutput = value; }


        public Charakter() { }

        private string name;

        private int body = 44;
        private int mind = 55;
        private int feeling = 20;

        private int health = 80;
        private int mentalHealth = 60;

        private int manaStorage = 100;
        private int manaOutput = 100;

        public override string ToString()
        {
            return String.Format($"body:{Body} mind:{Mind} feeling:{Feeling} health:{Health} mentalHealth:{MentalHealth} ");
        }

    }
}

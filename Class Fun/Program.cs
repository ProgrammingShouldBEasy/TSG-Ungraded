using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Fun
{
    class Goblin
    {
        public int damage;
        private int health
        {get; set ;}
        private void startHealth()
        { health = 10; }
        public void onHit()
        { health -= damage; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRustlers
{
    class Program
    {
        static void Main(string[] args)
        {
            int spaceships = 10;
            int aliens = 25;
            int cows = 100;

            if (aliens >= spaceships)
            {
                Console.WriteLine("Vroom, vroom! Let's get going!");
            }

            else
            {
                Console.WriteLine("There aren't enough green guys to drive these ships!");
            }

            if (cows == spaceships)
            {
                Console.WriteLine("Wow, way to plan ahead! JUST enough room for all these walking hamburgers!");
            }

            else if (cows > spaceships)
            {
                Console.WriteLine("Dangit! I don't know how we're going to fit all these cows in here!");
            }

            else
            {
                Console.WriteLine("Too many ships! Not enough cows.");
            }

            if (aliens > cows)
            {
                Console.WriteLine("Hurrah, we've got the grub! Hamburger party on AlphaCentauri!");
            }
            else if (aliens < cows)
            {
                Console.WriteLine("Oh no! The herds got restless and took over! Looks like _we're_ hamburger now!!");
            }

            else
            {
                Console.WriteLine("We have just enough for a small hamburger gathering!");
            }

            if (aliens > cows)
            {
                Console.WriteLine("Hurrah, we've got the grub! Hamburger party on Alpha Centauri!");
            }

            else
            {
                Console.WriteLine("Oh no! The herds got restless and took over! Looks like we're hamburger now!!");
            }

            Console.ReadLine();
            // else if continues the if check, if begins a new check. They function much the same except else if requires an initial if to fail.
            // remove else from else if just starts a new loop
        }
    }
}

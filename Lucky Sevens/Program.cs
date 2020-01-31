using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky_Sevens
{
    class Program
    {
        public static int LuckyRoll()
        {
            int change;
            Random roll = new Random();
            if ((roll.Next(1, 6) + roll.Next(1, 6)) == 7)
            {
                change = 4;
            }
            else
            {
                change = -1;
            }
            return change;
        }

        //public static void ReturnMax(int roll, int rollPrevMax, int money, int moneyAfter, out int moneyMax, out int rollsAtMax)
        //{
        //    if (moneyAfter > money)
        //    {
        //        moneyMax = moneyAfter;
        //        rollsAtMax = roll;
        //    }
        //    else
        //    {
        //        moneyMax = money;
        //        rollsAtMax = rollPrevMax;
        //    }
        //}

        public static void LuckySevensGame(int money, out decimal moneyMaximum, out int rollMaximum, out int rollsAtMaximum)
        {
            int roll = 0;
            int moneyMax = money;
            int rollsAtMax = 0;
            //Play the game if the player has money left.
            do
            {
                roll++;
                money += LuckyRoll();
                if (money > moneyMax)
                {
                    moneyMax = money;
                    rollsAtMax = roll;
                }
                //ReturnMax(roll, rollPrevMax, money, moneyAfter, out moneyMax, out rollsAtMax);
                //if (rollsAtMax > rollPrevMax)
                //{
                //    rollPrevMax = rollsAtMax;
                //}
                //maxRolls = roll;
            }
            while (money > 0);
            //rollsTotal = moneyMax;
            moneyMaximum = moneyMax;
            rollMaximum = roll;
            rollsAtMaximum = rollsAtMax;
        }

        static void Main(string[] args)
        {
            int money;
            int rollsAtMax;
            int rollsMax;
            decimal moneyMax;
            bool isTrue = false;
            do
            {
                Console.WriteLine("How many dollars do you have to bet?");
                if (Int32.TryParse(Console.ReadLine(), out money))
                {
                    isTrue = true;
                }

            } while (!isTrue);

            LuckySevensGame(money, out moneyMax, out rollsMax, out rollsAtMax);
            int answer1 = rollsMax;
            int answer2 = rollsAtMax;
            decimal answer3 = moneyMax;
            Console.WriteLine("You are broke after " + answer1 + " rolls.");
            Console.WriteLine("You should have quit after " + answer2 + " rolls when you had " + "$" + answer3);

            Console.ReadLine();
        }
    }
}

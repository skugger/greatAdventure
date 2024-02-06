using System;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref magic, ref health, r);
            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health);
                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before it's completion");

        }

        private static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win)
        {
            round++;
            Console.WriteLine();
            Console.WriteLine($"At the end of round {round}, ");
            Console.WriteLine($"you have {lives} lives, {magic} magic, and {health} health.");
            if (round >= 25)
                win = true;
            return;
        }

        private static void actions(int num, ref int lives, ref int magic, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You met three bears who were not happy that their porridge was gone.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of magic");
                    health -= 1;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You were abducted by flying monkeys and had to be rescued by a young girl and a dog");
                    Console.WriteLine("You lost 2 units of health and magic and 1 life");
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You flew in a Boeing 737-Max and the door came off.  And you had the lasagna.");
                    Console.WriteLine("You lose one health, one magic and one life.  And your lunch.");
                    health -= 1;
                    magic -= 1;
                    lives -= 1;
                    break;
                case 3:
                    Console.WriteLine("You entered a grocery story where everyone had Covid and nobody was wearing masks.");
                    Console.WriteLine("You lose one health, one magic and one life.");
                    health -= 1;
                    magic -= 1;
                    lives -= 1;
                    break;
                case 4:
                    Console.WriteLine("You got on the wrong plane, landed in Scotland, and had the time of your life.");
                    Console.WriteLine("You gain 2 health and one magic.");
                    health += 2;
                    magic += 2;
                    break;
                case 5:
                    Console.WriteLine("You saved a fellow traveler from a headless horseman.");
                    Console.WriteLine("The traveler granted you 2 units of health, magic and lives");
                    health += 2;
                    magic += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You babysat for a woman who lived in a house that resembled a shoe (she had a lot of kids).");
                    Console.WriteLine("You gain 3 units of health and magic");
                    health += 3;
                    magic += 3;
                    break;
                case 7:
                    Console.WriteLine("While you were napping, your dog filled out your tax forms, and found three new deductions.");
                    Console.WriteLine("You gain 2 health and 2 magic.");
                    health += 2;
                    magic += 2;
                    break;
                case 8:
                    Console.WriteLine("You launched your last photon torpedo and destroyed the Death Star.");
                    Console.WriteLine("You lose one magic but gain two lives");
                    health += 3;
                    magic -= 1;
                    lives += 2;
                    break;
                case 9:
                    Console.WriteLine("You go back to school and learn cool new stuff like C# and Javascript.");
                    Console.WriteLine("You gain 2 health and 3 magic.");
                    health += 2;
                    magic += 3;
                    break;
                default:
                    Console.WriteLine("You saved a unicorn from a mean wizard.");
                    Console.WriteLine("You gain 2 lives and 2 units of magic");
                    magic += 2;
                    lives += 2;
                    break;
            }
        }

        private static int chooseDirection()
        {
            Console.WriteLine("You have come to a crossroad, enter 1 to go left and 2 to go right");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }

        private static void initValues(ref int lives, ref int magic, ref int health, Random r)
        {
            lives = r.Next(10) + 1; 
            magic = r.Next(10) + 5; 
            health = r.Next(10) + 5;
            return;
        }
    }
}
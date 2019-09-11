using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            int guess = 0; //The computers guess
            int guesses = 0; //The number of times the computer guessed
            int minNum = 1; //Smallest number the computer can guess
            int maxNum = 1000; //Biggest number the computer can guess
            bool guessing = true; //Checks if computer is still guessing
            bool cheated = false; //Checks if the player cheated
            bool valid = false; //Checks to see if input is valid

            Console.WriteLine("Choose a number between " + minNum + " - " + maxNum + ". Press a button when you have chosen a number.");
            Console.ReadKey();

            while(guessing)
            {
                valid = false;
                guess = random.Next(minNum, (maxNum + 1)); //Randomizes computers guess between min and max
                guesses++;

                while(!valid)
                {
                    Console.WriteLine("The computer guesses that your number is " + guess + ".");
                    Console.WriteLine("1) That is my number.\n2) My number is lower than that number.\n3) My number is higher than that number"); //Player says if it is their number or not
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        guessing = false;
                        valid = true;
                    }


                    else if (choice == "2")
                    {
                        maxNum = guess - 1;
                        if (minNum >= maxNum)
                        {
                            guessing = false;
                            cheated = true;
                        }
                        valid = true;
                    }

                    else if (choice == "3")
                    {
                        minNum = guess + 1;
                        if (minNum >= maxNum)
                        {
                            guessing = false;
                            cheated = true;
                        }
                        valid = true;
                    }
                }
            }

            if(!cheated)
            {
                Console.WriteLine("You got bested by a computer. It guessed your number in " + guesses + " guesses.");
            }

            else if(cheated)
            {
                Console.WriteLine("You tried to best the computer by cheating. The computer figured out you were cheating in " + guesses + " guesses.");
            }
            Console.ReadKey();
        }
    }
}

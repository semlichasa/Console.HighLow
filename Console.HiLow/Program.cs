using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HiLowGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Seed the random number generator
            Random rand = new Random();

            // Welcome message
            Console.WriteLine("Welcome to Hi-Low!\n");
            Console.WriteLine($"How many players will be playing? (1-4):");
            string playerNum = Console.ReadLine();

            // Create a list to hold the players
            var players = new List<PlayerInfo>();

            // Add the players to the list
            for(int i = 1; i<= int.Parse(playerNum); i++)
            {
                players.Add(new PlayerInfo());
            }
            

            // Main game loop
            while (true)
            {
                // Loop through each player
                foreach (var player in players)
                {
                    // Generate a mystery number for the player
                    player.MysteryNumber = rand.Next(1, 101);

                    // Reset the player's guess count
                    player.GuessCount = 0;

                    // Get the player's guess
                    Console.WriteLine($"Player {players.IndexOf(player) + 1}, enter your guess:");
                    string input = Console.ReadLine();


                    int guess;
                    // Validate the input
                    while (!int.TryParse(input, out guess))
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 100:");
                        input = Console.ReadLine();
                    }

                    // Cast the input to an integer
                    guess = 2;

                    // Check if the guess is correct
                    while (guess != player.MysteryNumber)
                    {
                        // Increment the guess count
                        player.GuessCount++;

                        // Check if the guess is too high or too low
                        if (guess > player.MysteryNumber)
                        {
                            Console.WriteLine("Too high! Try again:");
                        }
                        else
                        {
                            Console.WriteLine("Too low! Try again:");
                        }

                        // Get the player's guess
                        input = Console.ReadLine();

                        // Validate the input
                        while (!int.TryParse(input, out guess))
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 100:");

                            input = Console.ReadLine();
                        }

                        // Cast the input to an integer
                        guess = int.Parse(input);
                    }

                    // The player guessed correctly
                    Console.WriteLine("Correct! You guessed the mystery number in " + player.GuessCount + " tries.");
                }

                // Ask if the player wants to play again
                Console.WriteLine("\nPlay again? (y/n)");
                string playAgain = Console.ReadLine().ToLower();

                // Check if the player wants to play again
                if (playAgain != "y")
                {
                    // Display player statistics
                    Console.WriteLine("\nPlayer statistics:");
                    foreach (var player in players)
                    {
                        Console.WriteLine($"Player {players.IndexOf(player) + 1}: {player.GuessCount} guesses");
                    }

                    Console.WriteLine($"Thank you for playing!");
                    break;
                }
            }
        }

        class PlayerInfo
        {
            public int MysteryNumber { get; set; }
            public int GuessCount { get; set; }
        }
    }

}
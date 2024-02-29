using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame_Vs_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            

            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine("Welcome to my game wench, It's Hangman not complicated!");
                PlayHangman();
                keepPlaying = AskToPlayAgain();
            }


        }



        static void PlayHangman()
        {
            List<string> words = new List<string>
            {
                "wagon", "gojosaturo", "pokemon", "democracy", "amonotron", "defend", "the", "creek", "dogs",
                "mysterious", "elephant", "dolphin", "kangaroo", "computer","amonotron","loser",
                "programming", "science", "hangman", "keyboard", "chocolate", "butterfly", "pasta", "fluff",
                "code","hangman"
            };

            var validWords = words.Where(word => word.Length >= 5 && word.Length <= 12).ToList();
            Random random = new Random();
            string secretWord = validWords[random.Next(validWords.Count)];

            List<char> guessedLetters = new List<char>();
            int lives = 5; // Number of allowed mistakes

            while (lives > 0)
            {
                Console.WriteLine(DisplayWord(secretWord, guessedLetters));
                Console.WriteLine("Guess a letter or the entire word:");
                string input = Console.ReadLine().ToLower();
                if (input.Length == 1)
                {
                    char guessedLetter = input[0];
                    if (secretWord.Contains(guessedLetter))
                    {
                        Console.WriteLine("Correct!");
                        guessedLetters.Add(guessedLetter);

                        if (IsWordGuessed(secretWord, guessedLetters))
                        {
                            Console.WriteLine($"Congratulations! You've guessed the word: {secretWord}!");
                            return; // Ends the game after a correct guess
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong guess.");
                        lives--;
                    }
                }
                else if (input.Equals(secretWord, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Congratulations! You've correctly guessed the word: {secretWord}!");
                    return; // Ends the game after a correct guess
                }
                else
                {
                    Console.WriteLine("Incorrect guess.");
                    lives--;
                }

                Console.WriteLine($"Lives remaining: {lives}");
            }

            if (lives == 0)
            {
                Console.WriteLine($"Game Over. The word was: {secretWord}");
            }
        }

        static string DisplayWord(string word, List<char> guessedLetters)
        {
            string displayedWord = "";
            foreach (char letter in word)
            {
                if (guessedLetters.Contains(letter))
                    displayedWord += letter + " ";
                else
                    displayedWord += "_ ";
            }
            return displayedWord.Trim();
        }

        static bool IsWordGuessed(string word, List<char> guessedLetters)
        {
            foreach (char letter in word)
            {
                if (!guessedLetters.Contains(letter))
                    return false;
            }
            return true;

        }

        

        static bool AskToPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (yes/no)");
            string answer = Console.ReadLine().Trim().ToLower();
            return answer.StartsWith("y");
        }

    }
}

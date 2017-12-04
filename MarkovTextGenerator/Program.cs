using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovTextGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain = new Chain();

            Console.WriteLine("Welcome to Marky Markov's Random Text Generator!");

            /*
            Console.WriteLine("Enter some text I can learn from (enter single ! to finish): ");

            while (true)
            {

                Console.Write("> ");

                String line = Console.ReadLine();
                if (line == "!")
                    break;

                chain.AddString(line);  // Let the chain process this string
            }*/
            string[] lines = File.ReadAllLines(@"Text\Minecraft.txt");
            foreach (String line in lines)
            {
                String line2 = new string(line.Where(c => !char.IsPunctuation(c)).ToArray());
                chain.AddString(line2.ToLower());
            }

            // Now let's update all the probabilities with the new data
            chain.UpdateProbabilities();

            // Okay now for the fun part
            Console.WriteLine("Done learning!  Now give me a word and I'll tell you what comes next.");
            Console.Write("> ");

            String nextWord = Console.ReadLine();
            

            while (true)
            {
                nextWord = chain.GetNextWord(nextWord);

                if (nextWord == "")
                    break;

                Console.Write(nextWord + " ");

            }

        }
    }
}
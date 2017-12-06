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
            Random rand = new Random(System.Environment.TickCount);
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
            //Console.WriteLine("Done learning!  Now type in 10 words seperated by spaces, and I'll generate a minecraft parody.");
            //Console.Write("> ");

            //string[] startWords = Console.ReadLine().Split(' ');
            //Console.WriteLine();
            /*for (int i = 0; i < startWords.Length; i++)
            {
                string nextWord = startWords[i];
                string New = nextWord;
                New = New.Substring(0, 1).ToUpper() + New.Substring(1);
                Console.Write(New + " ");
                while (true)
                {
                    nextWord = chain.GetNextWord(nextWord);

                    if (nextWord == "")
                        break;

                    Console.Write(nextWord + " ");

                }
                Console.WriteLine();
            }
*/

            Dictionary<String, List<String>> lyrics = new Dictionary<string, List<string>>();

            for (int i = 0; i < 1000; i++)
            {
                string line = "";
                string nextWord = chain.GetRandomStartingWord();
                string New = nextWord;
                string lastWord = "";
                New = New.Substring(0, 1).ToUpper() + New.Substring(1);
                line = New + " ";
                while (true)
                {
                    lastWord = nextWord;
                    nextWord = chain.GetNextWord(nextWord);

                    if (nextWord == "")
                        break;

                    line += nextWord + " ";

                }

                List<String> list;

                if (lyrics.ContainsKey(lastWord))
                {
                    list = lyrics[lastWord];
                    list.Add(line);
                }
                else
                {
                    list = new List<string>();
                    list.Add(line);
                    lyrics.Add(lastWord, list);

                }
            }

            List<String> song = new List<String>();
            int step = 0;

            for (int i = 0; i < 20; i++)
            {
                String key = lyrics.Keys.ElementAt(rand.Next() % lyrics.Keys.Count);

                if (lyrics[key].Count == 1)
                {
                    i--;
                    continue;
                }

                int first = rand.Next(lyrics[key].Count);
                int second = first;

                while (first == second)
                {
                    second = rand.Next(lyrics[key].Count);
                }

                if (step == 1)
                    song.Insert(song.Count - 1, lyrics[key][first]);
                else
                    song.Add(lyrics[key][first]);

                song.Add(lyrics[key][second]);
                step++;

                if (step == 2)
                    step = 0;

            }

            foreach (String s in song)
            {
                Console.WriteLine(s);
            }

        }
    }
}
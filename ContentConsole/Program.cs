using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    public static class Program
    {
      

        public static void Main(string[] args)
        {
            Console.WriteLine("What is your username: ");
            var role = AutheticationHelper.Login(Console.ReadLine());

            switch (role)
            {
                case Role.User:
                    StoryOne();
                    break;
                case Role.Administrator:

                    StoryTwo();
                    break;
                case Role.Reader:
                    StoryThree();
                    break;
                case Role.ContentCurator:
                    StoryFour();
                    break;
                default:
                    break;
            }

        }

        public static int StoryOne()
        {
            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            int badWords = 0;
            if (content.Contains(bannedWord1))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord2))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord3))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord4))
            {
                badWords = badWords + 1;
            }

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();

            return badWords;
        }

        public static void StoryTwo()
        {
            SentenceConfiguration config = new SentenceConfiguration();

            Console.WriteLine("Write your sentence please:");
            var sentence = Console.ReadLine();

            config.Sentence = sentence;
            config.Word = new List<string>();

            var word = string.Empty;

            do
            {
                Console.WriteLine("Select the words you don't want to(Write EXIT to finish):");
                word = Console.ReadLine();

                if (!config.Word.Contains(word))
                {
                    config.Word.Add(word);
                }
                else
                {
                    Console.WriteLine("This word is already on the list.");
                }
              

            } while (!word.ToUpper().Equals("EXIT"));


            var createdJson = JSONHelper.CreateJson(config) != null;

            if (createdJson)
            {
                Console.WriteLine("The Configuration was created with success.");
                Console.WriteLine("Sentence:");
                Console.WriteLine(config.Sentence);

                Console.WriteLine("Words:");

                foreach (var item in config.Word)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Press ANY key to exit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something is wrong with your configuration file.");
                Console.WriteLine("Press ANY key to exit.");
                Console.ReadKey();
            }



        }

        public static void StoryThree()
        {
            var config = JSONHelper.ReadJson();

            if (config != null)
            {
                foreach (var item in config.Word)
                {
                    if (config.Sentence.ToUpper().Contains(item.ToUpper()))
                    {
                        var newWord = string.Empty;

                        for (int i = 0; i < item.Length; i++)
                        {


                            if (i != 0 && i != item.Count() - 1)
                            {
                                newWord = newWord + "#";
                            }
                            else
                            {
                                newWord = newWord + item[i];
                            }
                        }

                        config.Sentence = config.Sentence.Replace(item, newWord);
                    }
                }

                Console.WriteLine("Sentence: ");
                Console.WriteLine(config.Sentence);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something is wrong with your configuration file.");
                Console.ReadKey();
            }
        }

        public static void StoryFour()
        {
            var config = JSONHelper.ReadJson();

            if (config != null)
            {
                var count = 0;
                foreach (var item in config.Word)
                {
                    if (config.Sentence.ToUpper().Contains(item.ToUpper()))
                    {
                        count++;
                    }
                }

                Console.WriteLine("Sentence: ");
                Console.WriteLine(config.Sentence);
                Console.WriteLine("Number of Words: ");
                Console.WriteLine(count);
                Console.WriteLine("Press ANY key to exit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something is wrong with your configuration file.");
                Console.WriteLine("Press ANY key to exit.");
                Console.ReadKey();
            }
        }
    
    }

}

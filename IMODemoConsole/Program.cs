using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace IMODemoConsole
{
    class Program
    {

        private static String[] lyrics;
        private static String[] artists;
        private static String[] songs;

        static void Main(string[] args)
        {
            //Concept 1: Arrays
            songs = new String[3]{ "hello.txt", "another_one_bites_the_dust.txt", "night_moves.txt" };
            artists = new String[3] { "Lionel Richie", "Queen", "Bob Seger" };
            lyrics = new String[songs.Length];

            //Concept 2: Methods
            loadLyrics(songs);

            readInputs();
        }

        private static void loadLyrics(String[] songs)
        {
            //Concept 3: For Loops
            for(int i=0; i<songs.Length; i++)
            {
                //Concept 4: Declaring Variables
                String fileName = songs[i];
                StreamReader file = new StreamReader(fileName);
                loadLyrics(file, i);
                file.Close();
            }
        }

        //Concept 5: Overloaded Methods
        private static void loadLyrics(StreamReader reader, int index)
        {
            string line = "";
            string songLyrics = "";

            //Concept 7: While loops
            while(line != null)
            {
                //Concept 8: Working with Files
                line = reader.ReadLine();
                if(line != null)
                {
                    songLyrics += line + "\n";
                }
            }

            lyrics[index] = songLyrics;
        }

        private static void readInputs()
        {
            Console.WriteLine("Please Choose A Number Between 1 and 3 (Select 99 to quit):");
            String choice = Console.ReadLine();

            int convertedChoice;
            if(Int32.TryParse(choice, out convertedChoice))
            {
                displayChoice(convertedChoice);
            } else
            {
                Console.WriteLine("Please enter a number!");
                readInputs();
            }
        }

        private static void displayChoice(int choice)
        {
            String output = "";
            
            
            if(choice == 99)
            {
                return;
            } else if(choice < 0 || choice > songs.Length)
            {
                Console.WriteLine("Invalid Choice!");
                readInputs();
                return;
            }

            String songName = parseSongFile(choice);
            output = String.Format("{0} by {1} \n {2}\n", songName, artists[choice - 1], lyrics[choice - 1]);
            Console.WriteLine(output);
            readInputs();
        }

        private static String parseSongFile(int choice)
        {
            //More String manipulation
            String fileName = songs[choice - 1];
            fileName = fileName.Replace("_", " ");
            fileName = fileName.Replace(".txt", "");

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            fileName = textInfo.ToTitleCase(fileName);

            return fileName;
        }
    }
}

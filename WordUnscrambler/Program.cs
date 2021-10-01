using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();



        static void Main(string[] args)
        {
            try
            {
                string option2;
                do
                {

                    Console.WriteLine(Constants.input);
    
                    String option1 = Console.ReadLine() ?? throw new Exception(Constants.error);

                    while (option1 != Constants.char1 && option1 != Constants.char2 && option1 != Constants.char3 && option1 != Constants.char4)
                    {
                        Console.WriteLine(Constants.input);
                        option1 = Console.ReadLine();
                    }
                    switch (option1.ToUpper())
                    {
                        case Constants.char1:
                        case Constants.char2:
                            Console.WriteLine(Constants.inputfile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.char3:
                        case Constants.char4:
                            Console.WriteLine(Constants.inputmanual);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;  
                        default:
                            Console.WriteLine(Constants.inputfalse);
                            break;
                    }
                    Console.WriteLine(Constants.continue1);

                        option2 = Console.ReadLine();
                    while (option2 != Constants.char5 && option2 != Constants.char6 && option2 != Constants.char7 && option2 != Constants.char8 && option2 != Constants.char9 && option2 
                        != Constants.char10 && option2 != Constants.char11 && option2 != Constants.char12)
                            {


                        Console.WriteLine(Constants.continue1);
                        option2 = Console.ReadLine();
                    }
                } while (option2 == Constants.char5 || option2 == Constants.char6 || option2 == Constants.char7 || option2 == Constants.char8);

                    

            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.terminate + ex.Message);
                Console.ReadLine();
            }
        }


        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine();
            string[] scrambledWords = _fileReader.Read(filename);

            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            string manualInput = Console.ReadLine();
            char[] separators = { Constants.comma, Constants.space };

            string[] scrambledWords = manualInput.Split(separators);
            DisplayMatchedUnscrambledWords(scrambledWords);

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read(Constants.wordlist);

            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);


            if (matchedWords.Any())
            {
                foreach (var matchedword in matchedWords)
                {

                    Console.WriteLine(Constants.match,matchedword.Word, matchedword.ScrambledWord);

            }

        }
        else
        {
            Console.WriteLine(Constants.nomatch);
        }
             Console.ReadLine();
            

        }
    }
}

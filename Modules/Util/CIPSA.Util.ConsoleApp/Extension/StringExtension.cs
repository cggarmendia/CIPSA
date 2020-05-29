using System;
using System.Linq;

namespace CIPSA.Util.ConsoleApp.Extension
{
    public static class StringExtension
    {
        public static string ReplaceWord(this string str, string oldWord, string newWord)
        {
            return str.Replace(oldWord, newWord);
        }

        public static string ReplaceAll(this string str, string oldWords, string newWord)
        {
            oldWords.Split('|').ToList().ForEach(oldWord => str = str.Replace(oldWord, newWord));
            return str;
        }

        public static int CountVowels(this string str)
        {
            return (str.Length - str.ReplaceAll("a|e|i|o|u|A|E|I|O|U", "").Length);
        }
    }
}

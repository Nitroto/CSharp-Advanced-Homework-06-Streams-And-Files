using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

/// Write a program that reads a list of words from the file words.txt and finds how many 
/// times each of the words is contained in another file text.txt. Matching should be case-insensitive.
/// Write the results in file results.txt.Sort the words by frequency in descending order. 
/// Use StreamReader in combination with StreamWriter.

class WordCount
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        List<string> words = new List<string>();
        Dictionary<string, int> result = new Dictionary<string, int>();
        using (StreamReader reader = new StreamReader(@"..\..\word.txt"))
        {
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                words.Add(line);
            }
        }
        foreach (string word in words)
        {
            using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
            {
                string text = reader.ReadToEnd();
                result.Add(word, CountWords(text, word));
            }
        }
        result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        using (StreamWriter writer = new StreamWriter(@"..\..\result.txt"))
        {
            foreach (KeyValuePair<string, int> word in result)
            {
                string output = "" + word.Key + " - " + word.Value;
                writer.WriteLine(output);
            }
        }

    }
    public static int CountWords(string text, string pattern)
    {
        MatchCollection collection = Regex.Matches(text, @"\b" + pattern + @"\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return collection.Count;
    }
}

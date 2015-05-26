using System.Globalization;
using System.IO;
using System.Threading;

/// Write a program that reads a text file and inserts line numbers in front of each of its lines. The result 
/// should be written to another text file. Use StreamReader in combination with StreamWriter.

class LineNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        using (StreamReader reader = new StreamReader(@"..\..\LoremIpsum.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\newFile.txt"))
            {
                int count = 1;
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    string output = "" + count + " " + line;
                    writer.WriteLine(output);
                    count++;
                }
            }
        }
    }
}

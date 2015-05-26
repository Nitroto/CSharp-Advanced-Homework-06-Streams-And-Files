using System;
using System.Globalization;
using System.IO;
using System.Threading;

///  Write a program that reads a text file and prints on the console its odd lines. Line numbers starts from 0. Use StreamReader.

class OddLines
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        using (StreamReader reader = new StreamReader(@"..\..\LoremIpsum.txt"))
        {
            string line = string.Empty;
            int count = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if ((count & 1) == 1)
                {
                    Console.WriteLine(line);
                }
                count++;
            }
        }
    }
}

using System;
using System.Globalization;
using System.Threading;

class Disk
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int center = (n / 2);
        int row = n - 1;
        int col = 0;
        while (row >= 0)
        {
            while (col < n)
            {
                if (Math.Sqrt((col - center) * (col - center) + (row - center) * (row - center)) <= r)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
                col++;
            }
            Console.WriteLine();
            col = 0;
            row--;
        }
    }
}

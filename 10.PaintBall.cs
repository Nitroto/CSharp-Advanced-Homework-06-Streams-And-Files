using System;
using System.Globalization;
using System.Linq;
using System.Threading;

class PaintBall
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] target = new int[] { 1023, 1023, 1023, 1023, 1023, 1023, 1023, 1023, 1023, 1023 };
        string shot = Console.ReadLine();
        int shotCounter = 1;
        while (shot != "End")
        {
            string[] shotParameters = shot.Split(' ');
            int row = int.Parse(shotParameters[0]);
            int column = int.Parse(shotParameters[1]);
            int radius = int.Parse(shotParameters[2]);
            int startRow = Math.Max((row - radius), 0);
            int finalRow = Math.Min((row + radius), 9);
            int startColumn = Math.Max((column - radius), 0);
            int finalColumn = Math.Min((column + radius), 9);
            for (int i = startRow; i <= finalRow; i++)
            {
                if ((shotCounter & 1) == 1)
                {
                    target[i] &= ~maskGenerator((finalColumn - startColumn + 1), startColumn);
                }
                else
                {
                    target[i] |= maskGenerator((finalColumn - startColumn + 1), startColumn);
                }
            }
            shotCounter++;
            shot = Console.ReadLine();
        }
        Console.WriteLine(target.Sum());
    }
    private static int maskGenerator(int num, int column)
    {
        int mask = 0;
        for (int i = 0; i < num; i++)
        {
            mask = mask << 1 | 1;
        }
        mask <<= column;
        return mask;
    }
}

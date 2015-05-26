using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// Traverse a given directory for all files with the given extension. Search through the first level of the directory only and 
/// write information about each found file in report.txt.
/// The files should be grouped by their extension.Extensions should be ordered by the count of their files (from most to least). 
/// If two extensions have equal number of files, order them by name.
/// Files under an extension should be ordered by their size.
/// report.txt should be saved on the Desktop.Ensure the desktop path is always valid, regardless of the user.

class DirectoryTraversal
{
    static void Main()
    {
        string path = Console.ReadLine();
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string[] files = Directory.GetFiles(path);
        Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
        foreach (string file in files)
        {
            FileInfo info = new FileInfo(file);
            if (results.ContainsKey(info.Extension))
            {
                string fileInfo = string.Format("--{0}{1} - {2:F2}kb", info.Name, info.Extension, info.Length / 1024.0);
                results[info.Extension].Add(fileInfo);
            }
            else
            {
                results.Add(info.Extension, new List<string>());
                string fileInfo = string.Format("--{0}{1} - {2:F2}kb",info.Name,info.Extension,info.Length/1024.0);
                results[info.Extension].Add(fileInfo);
            }
        }

        desktopPath += "\\results.txt";
        results = results.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        using (StreamWriter resultStream = new StreamWriter(desktopPath))
        {
            foreach (KeyValuePair<string,List<string>> result in results)
            {
                resultStream.WriteLine(result.Key);
                result.Value.Sort();
                foreach (string fileInfo in result.Value)
                {
                    resultStream.WriteLine(fileInfo);
                }
            }

        }
            Console.WriteLine();
    }

}


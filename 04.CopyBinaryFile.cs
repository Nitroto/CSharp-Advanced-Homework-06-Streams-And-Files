using System.IO;

/// Write a program that copies the contents of a binary file (e.g. image, video, etc.) to another using FileStream. 
/// You are not allowed to use the File class or similar helper classes.

class CopyBinaryFile
{
    static void Main()
    {
        FileStream input = new FileStream(@"..\..\file.txt", FileMode.Open);
        FileStream output = new FileStream(@"..\..\copedFile.txt", FileMode.Create);
        using (input)
        {
            using (output)
            {
                byte[] buffer = new byte[4096];
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, read);
                }
            }
        }
    }
}

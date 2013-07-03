namespace FinAllExeFilesInWindows
{
    using System;
    using System.IO;
    using System.Text;

    public class FindAllExeFilesInWindows
    {
        public static void Main()
        {
            string result;
            string pattern = "*.exe";
            string startPoint = "C:\\Windows";
            Console.WriteLine("Please, wait! Working...");
            result = FindExeFiles(startPoint, pattern);
            Console.BufferHeight = short.MaxValue - 1;
            Console.WriteLine(result);
        }

        private static string FindExeFiles(string folder, string pattern)
        {
            StringBuilder result = new StringBuilder();
            string[] filesInFolder = Directory.GetFiles(folder, pattern);
            foreach (var file in filesInFolder)
            {
                result.AppendLine(file);
            }

            string[] subfoldersInFolder = Directory.GetDirectories(folder);
            foreach (var subfolder in subfoldersInFolder)
            {
                // Because of locked system folders in some windows versions!
                try
                {
                    string tempOutput = FindExeFiles(subfolder, pattern);
                    if (tempOutput != string.Empty)
                    {
                        result.AppendLine(tempOutput);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            return result.ToString();
        }
    }
}
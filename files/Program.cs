using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path for new file");
            string pathForFile = Console.ReadLine();
            Console.WriteLine("Enter directory path");
            string directoryPath = Console.ReadLine();

            try
            {
                StreamWriter sw = File.CreateText(pathForFile + @"\output.txt");
                sw.Close();

                string[] filePaths = Directory.GetFiles(@directoryPath);

                foreach (var file in filePaths)
                {
                    Console.WriteLine(file);

                    List<string> lines = File.ReadAllLines(file).ToList();

                    var tw = new StreamWriter(pathForFile + @"\output.txt", true);
                    tw.WriteLine(file + Environment.NewLine);

                    foreach (string line in lines)
                    {
                        tw.WriteLine(line);
                        Console.WriteLine(line);
                    }

                    tw.WriteLine(Environment.NewLine);
                    tw.Close();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}

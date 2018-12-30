using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Xceed.Words.NET;

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

                var doc = DocX.Create(pathForFile + @"\output.docx");

                Formatting titleFormat = new Formatting();
                titleFormat.FontFamily = new Font("Calibri");
                titleFormat.Size = 18D;
                titleFormat.Position = 40;
                titleFormat.Italic = true;

                string[] filePaths = Directory.GetFiles(@directoryPath, "*.html");

                foreach (var file in filePaths)
                {
                    Console.WriteLine(file);

                    List<string> lines = File.ReadAllLines(file).ToList();

                    Paragraph paragraphTitle = doc.InsertParagraph(file, false, titleFormat);
                    paragraphTitle.Alignment = Alignment.center;

                    foreach (string line in lines)
                    {
                        doc.InsertParagraph(line);

                        Console.WriteLine(line);
                    }

                    doc.InsertParagraph(Environment.NewLine);

                }
                doc.Save();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Process.Start("WINWORD.EXE", pathForFile + @"\output.docx");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Xceed.Words.NET;


namespace FileMerger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string outputPath = textBox1.Text;
            string inputPath = textBox2.Text;
            int filesDone = 0;
            
            var doc = DocX.Create(outputPath + @"\output.docx");

            Formatting titleFormat = new Formatting();
            titleFormat.FontFamily = new Xceed.Words.NET.Font("Calibri");
            titleFormat.Size = 18D;
            titleFormat.Position = 40;
            titleFormat.Italic = true;

            string[] filePaths = Directory.GetFiles(inputPath, "*.html");

            foreach (var file in filePaths)
            {

                List<string> lines = File.ReadAllLines(file).ToList();

                Paragraph paragraphTitle = doc.InsertParagraph(file, false, titleFormat);
                paragraphTitle.Alignment = Alignment.center;

                foreach (string line in lines)
                {
                    doc.InsertParagraph(line);
                }

                filesDone++;
                doc.InsertParagraph(Environment.NewLine);

            }

            doc.Save();
            textBox3.Text = $"Merged {filesDone} .html files into .docx";
            textBox3.Visible = true;

            Process.Start("WINWORD.EXE", outputPath + @"\output.docx");
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;
using FaireCarte.Properties;

namespace FaireCarte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = new FileGetter();
            temp.Read();
            Noeud[,] map = temp.PingsToMatrix();

            for (int i = 0; i < Resources.mapSizeX; i++)
            {
                for (int j = 0; j < Resources.mapSizeY; j++)
                {
                    if (map[i, j] == null)
                        textBox1.Text += " ";
                    else
                        textBox1.Text += "#"; // map[i,j].id ;
                }
                textBox1.Text += Environment.NewLine;
            }

            //string[] lines = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            //textBox1.Clear();

            //foreach (string line in lines.Where(line => !String.IsNullOrWhiteSpace(line)))
            //{
            //    textBox1.Text += line + Environment.NewLine;
            //}
        }
    }
}
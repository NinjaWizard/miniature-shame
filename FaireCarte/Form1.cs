using System;
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

            for (int i = 0; i < Resources.mapSize; i++)
            {
                for (int j = 0; i < Resources.mapSize; j++)
                {
                    if (map[i, j] == null)
                        textBox1.Text += ".";
                    else
                        textBox1.Text += "#";
                }
                textBox1.Text += Environment.NewLine;
            }
        }
    }
}
using System;
using System.Linq;
using System.Windows.Forms;
using FaireCarte.Properties;
using System.Drawing;

namespace FaireCarte
{
    public partial class Form1 : Form
    {
        private static Localizer _localizer = new Localizer();
        private FileGetter _fileGetter = new FileGetter(_localizer);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fileGetter.Read();
            Noeud[,] map = _fileGetter.PingsToMatrix();
            
            textBox1.Clear();

            ImprimerCarte(map);

            //string[] lines = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            //textBox1.Clear();

            //foreach (string line in lines.Where(line => !String.IsNullOrWhiteSpace(line)))
            //{
            //    textBox1.Text += line + Environment.NewLine;
            //}
        }

        private void ImprimerCarte(Noeud[,] map)
        {
            for (int i = 0; i < Resources.mapSizeX; i++)
            {
                for (int j = 0; j < Resources.mapSizeY; j++)
                {
                    if (map[i, j] == null)
                        textBox1.Text += " ";
                    else
                    {
                        if (map[i, j].cote <= 0.05d)
                            textBox1.Text += "0";
                        else if (map[i, j].cote <= 0.10d)
                            textBox1.Text += "1";
                        else if (map[i, j].cote <= 0.20d)
                            textBox1.Text += "2";
                        else if (map[i, j].cote <= 0.40d)
                            textBox1.Text += "3";
                        else if (map[i, j].cote > 0.60d)
                            textBox1.Text += "4";

                        //textBox1.Text += map[i, j].cote.ToString();
                    }
                }
                textBox1.Text += Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            _fileGetter.Read();

            // Données de simulations
            _localizer.findBestMatch(TestLocalisation.creerBonsSSIDs(), _fileGetter._pings);
            //_localizer.findBestMatch(TestLocalisation.creerSSIDsDeDeuxFeatures(), _fileGetter._pings);
            //_localizer.findBestMatch(TestLocalisation.creerBonsSSIDs2(), _fileGetter._pings);
            ImprimerCarte(_fileGetter.PingsToMatrix());
        }
    }
}
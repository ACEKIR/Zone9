using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Выполнить подсчет
            if (radioButton1.Checked) CalculateXY(); else CalculateBL();

        }


        private void CalculateXY()
        {
            double B = 0;
            double L = 0;
            double x = 0;
            double y = 0;

            clear();

            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                if ((textBox1.Lines[i] != "") && (textBox2.Lines[i] != ""))
                {
                    B = double.Parse(textBox1.Lines[i]);
                    L = double.Parse(textBox2.Lines[i]);
                    x = getX(B, L);
                    y = getY(B, L);
                    textBox3.AppendText(x + "\r\n");
                    textBox4.AppendText(y + "\r\n");
                }
            }
        }

        private void CalculateBL()
        {
            double B = 0;
            double L = 0;
            double x = 0;
            double y = 0;

            clear();

            for (int i = 0; i < textBox3.Lines.Length; i++)
            {
                if ((textBox3.Lines[i] != "") && (textBox4.Lines[i] != ""))
                {
                    x = double.Parse(textBox3.Lines[i]);
                    y = double.Parse(textBox4.Lines[i]);
                    B = getB(x, y);
                    L = getL(x, y);
                    textBox1.AppendText(B + "\r\n");
                    textBox2.AppendText(L + "\r\n");
                }
            }
        }

    
        private double getX(double B, double L)
        {

            double x = 0;
            double l = 0;
            int n = 0;

            B = B * Math.PI / 180;

            n = (int)(6 + L) / 6;
            l = (L - (3 + 6 * (n - 1))) / 57.29577951;
            x = 6367558.4968 * B - Math.Sin(2 * B) * (16002.89 + 66.9607 * Math.Pow(Math.Sin(B), 2) + 0.3515 * Math.Pow(Math.Sin(B), 4) -
                Math.Pow(l, 2) * (1594561.25 + 5336.535 * Math.Pow(Math.Sin(B), 2) + 26.790 * Math.Pow(Math.Sin(B), 4) + 0.149 * Math.Pow(Math.Sin(B), 6) +
                Math.Pow(l, 2) * (672483.4 - 811219.9 * Math.Pow(Math.Sin(B), 2) + 5420 * Math.Pow(Math.Sin(B), 4) - 10.6 * Math.Pow(Math.Sin(B), 6) +
                Math.Pow(l, 2) * (278194 - 830174 * Math.Pow(Math.Sin(B), 2) + 572434 * Math.Pow(Math.Sin(B), 4) - 16010 * Math.Pow(Math.Sin(B), 6) +
                Math.Pow(l, 2) * (109500 - 574700 * Math.Pow(Math.Sin(B), 2)) + 863700 * Math.Pow(Math.Sin(B), 4) - 398600 * Math.Pow(Math.Sin(B), 6)))));

            return x;
        }

        private double getY(double B, double L)
        {
        
            double y = 0;
            double l = 0;
            int n = 0;

            B = B * Math.PI / 180;

            n = (int)(6 + L) / 6;
            l = (L - (3 + 6 * (n - 1))) / 57.29577951;
            y = (5 + 10 * n) * Math.Pow(10, 5) + l * Math.Cos(B) * (6378245 + 21346.1415 * Math.Pow(Math.Sin(B), 2) + 107.1549 * Math.Pow(Math.Sin(B), 4) +
                0.5977 * Math.Pow(Math.Sin(B), 6) + Math.Pow(l, 2) * (1070204.16 - 2136826.66 * Math.Pow(Math.Sin(B), 2) + 17.98 * Math.Pow(Math.Sin(B), 4) - 11.99 * Math.Pow(Math.Sin(B), 6) +
                Math.Pow(l, 2) * (270806 - 1523417 * Math.Pow(Math.Sin(B), 2) + 1327645 * Math.Pow(Math.Sin(B), 4) - 21701 * Math.Pow(Math.Sin(B), 6) +
                Math.Pow(l, 2) * (79690 - 866190 * Math.Pow(Math.Sin(B), 2) + 1730360 * Math.Pow(Math.Sin(B), 4) - 945460 * Math.Pow(Math.Sin(B), 6)))));

            return y;
        }

        private double getB(double x, double y)
        {
            double B = 0;
            double B0 = 0;
            double dB = 0;
            double betta = 0;
            double z0 = 0;
            int n = 0;

            n = (int)(y * Math.Pow(10, -6));
            betta = (x / 6367558.4968);
            B0 = betta + Math.Sin(2 * betta) * (0.00252588685 - 0.00001491860 * Math.Pow(Math.Sin(betta), 2) + 0.00000011904 * Math.Pow(Math.Sin(betta), 4));
            z0 = (y - (10 * n + 5) * Math.Pow(10, 5)) / (6378245 * Math.Cos(B0));


            dB = -(Math.Pow(z0, 2)) * Math.Sin(2 * B0) * (0.251684631 - 0.003369263 * Math.Pow(Math.Sin(B0), 2) + 0.000011276 * Math.Pow(Math.Sin(B0), 4) -
                 (Math.Pow(z0, 2)) * (0.10500614 - 0.04559916 * Math.Pow(Math.Sin(B0), 2) + 0.00228901 * Math.Pow(Math.Sin(B0), 4) -
                 0.00002987 * Math.Pow(Math.Sin(B0), 6) - Math.Pow(z0, 2) * (0.042858 - 0.025318 * Math.Pow(Math.Sin(B0), 2) + 0.014346 * Math.Pow(Math.Sin(B0), 4) -
                 0.001264 * Math.Pow(Math.Sin(B0), 6) - Math.Pow(z0, 2) * (0.01672 - 0.00630 * Math.Pow(Math.Sin(B0), 2) + 0.01188 * Math.Pow(Math.Sin(B0), 4) -
                 0.00328 * Math.Pow(Math.Sin(B0), 6)))));

            B = B0 + dB;
            return B * 180 / Math.PI;
        }

        private double getL(double x, double y)
        {
            double l = 0;
            double L = 0;
            double z0 = 0;
            double B0 = 0;
            double betta = 0;
            int n = 0;

            n = (int)(y * Math.Pow(10, -6));
            betta = (x / 6367558.4968);
            B0 = betta + Math.Sin(2 * betta) * (0.00252588685 - 0.00001491860 * Math.Pow(Math.Sin(betta), 2) + 0.00000011904 * Math.Pow(Math.Sin(betta), 4));
            z0 = (y - (10 * n + 5) * Math.Pow(10, 5)) / (6378245 * Math.Cos(B0));

            l = z0 * (1 - 0.0033467108 * Math.Pow(Math.Sin(B0), 2) - 0.0000056002 * Math.Pow(Math.Sin(B0), 4) - 0.0000000187 * Math.Pow(Math.Sin(B0), 6) -
                Math.Pow(z0, 2) * (0.16778975 + 0.16273586 * Math.Pow(Math.Sin(B0), 2) - 0.00052490 * Math.Pow(Math.Sin(B0), 4) - 0.00000846 * Math.Pow(Math.Sin(B0), 6) -
                Math.Pow(z0, 2) * (0.0420025 + 0.1487407 * Math.Pow(Math.Sin(B0), 2) + 0.0059420 * Math.Pow(Math.Sin(B0), 4) - 0.0000150 * Math.Pow(Math.Sin(B0), 6) -
                Math.Pow(z0, 2) * (0.01225 + 0.09477 * Math.Pow(Math.Sin(B0), 2) + 0.03282 * Math.Pow(Math.Sin(B0), 4) - 0.00034 * Math.Pow(Math.Sin(B0), 6) -
                Math.Pow(z0, 2) * (0.0038 + 0.0524 * Math.Pow(Math.Sin(B0), 2) + 0.0482 * Math.Pow(Math.Sin(B0), 4) + 0.0032 * Math.Pow(Math.Sin(B0), 6))))));

            L = 6 * (n - 0.5) / 57.29577951 + l;
            return L * 180 / Math.PI;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Очистить поля
            clear();
        }

        private void clear()
        {
            if (radioButton1.Checked)
            {
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }


    }
}

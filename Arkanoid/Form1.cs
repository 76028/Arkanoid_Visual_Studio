using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Arkanoid
{
    public partial class Form1 : Form
    {
        private Panel[,] bloczki;

        private int kierunekX = 2;
        private int kierunekY = 2;
        private int paletkaX = 3;
        private int rows = 8;
        private int cols = 8;
        private int wynik = 0;
        private int zycia = 3;
        private Random r;
        private Color[] colors;

        public Form1()
        {
            colors = new Color[4] { Color.BurlyWood, Color.CadetBlue, Color.CornflowerBlue, Color.Goldenrod };
            r = new Random();
            generujBloczki();
            InitializeComponent();
        }

        private void generujBloczki()
        {
            int blockHeight = 30;
            int blockWidth = 100;

            bloczki = new Panel[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bloczki[i, j] = new Panel();

                    bloczki[i, j].Width = blockWidth;
                    bloczki[i, j].Height = blockHeight;
                    bloczki[i, j].Top = blockHeight * i + 75;
                    bloczki[i, j].Left = blockWidth * j;
                    bloczki[i, j].BackColor = colors[r.Next(0, colors.Length)];
                    bloczki[i, j].BorderStyle = BorderStyle.Fixed3D;

                    this.Controls.Add(bloczki[i, j]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pilka.Left += kierunekX;
            pilka.Top += kierunekY;
            label2.Text =  wynik.ToString();
            label4.Text = zycia.ToString();

            if (pilka.Top + pilka.Height >= ClientSize.Height)
            {
                if (zycia > 0)
                {
                    zycia--;
                    pilka.Left = 369;
                    pilka.Top = 566;
                    paletka.Left = 333;
                    label5.Text = "skucha !";
                    label6.Text = "zostało jeszcze " + zycia + " żyć";
                }
                else
                {
                    label5.Text = "Game Over !";
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                }
            }

            if (pilka.Left <= 0 || pilka.Left + pilka.Width >= ClientSize.Width)
                kierunekX = -kierunekX;
            if (pilka.Top <= 0)
                kierunekY = -kierunekY;

            //uderza w srodek
            if (pilka.Top + pilka.Height >= paletka.Top &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 > paletka.Left + paletka.Width - 60 &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 <= paletka.Left + paletka.Width - 50 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height)
            {
                kierunekX = 0;
                kierunekY = -3;
            }

            //jesli pilka leci prosto

            if (pilka.Top + pilka.Height >= paletka.Top &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2) + 5 >= paletka.Left &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2) - 5 <= paletka.Left + paletka.Width - 100 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX <= 0 && kierunekX == 0)
            {
                kierunekX = -3;
                kierunekY = -2;
            }

            else if (pilka.Top + pilka.Height >= paletka.Top &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 > paletka.Left + paletka.Width - 100 &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 <= paletka.Left + paletka.Width - 60 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX == 0)
            {
                kierunekX = -3;
                kierunekY = -2;
            }


            else if (pilka.Top + pilka.Height >= paletka.Top &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 > paletka.Left + paletka.Width - 50 &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 <= paletka.Left + paletka.Width - 10 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX == 0)
            {
                kierunekX = 3;
                kierunekY = -2;
            }
            else if (pilka.Top + pilka.Height >= paletka.Top &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2) + 10 > paletka.Left + paletka.Width - 10 &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2) - 10 <= paletka.Left + paletka.Width &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX == 0)
            {
                kierunekX = 3;
                kierunekY = -2;
            }




            //pilka leci od lewej do prawej


            if (pilka.Top + pilka.Height >= paletka.Top &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)+50 >= paletka.Left &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)-5 <= paletka.Left + paletka.Width - 100 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX<=0 && kierunekX>0)
            {
                kierunekX = 3;
                kierunekY = -2;
            }

            else if (pilka.Top + pilka.Height >= paletka.Top &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 > paletka.Left + paletka.Width - 100 &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 <= paletka.Left + paletka.Width - 60 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX > 0)
            {
                kierunekX = 3;
                kierunekY = -2;
            }


            else if (pilka.Top + pilka.Height >= paletka.Top &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 > paletka.Left + paletka.Width - 50 &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 <= paletka.Left + paletka.Width - 10 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX > 0)
            {
                kierunekX = 3;
                kierunekY = -2;
            }
            else if (pilka.Top + pilka.Height >= paletka.Top &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)+5 > paletka.Left + paletka.Width - 10 &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)-5 <= paletka.Left + paletka.Width &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX > 0)
            {
                kierunekX = 4;
                kierunekY = -1;
            }


            


            // pilka leci od prawej do lewej

            if (pilka.Top + pilka.Height >= paletka.Top &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)+5 >= paletka.Left &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)-5 <= paletka.Left + paletka.Width - 85 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX <= 0 && kierunekX < 0)
            {
                kierunekX = -4;
                kierunekY = -1;  
            }

            else if (pilka.Top + pilka.Height >= paletka.Top &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 > paletka.Left + paletka.Width - 85 &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 <= paletka.Left + paletka.Width - 60 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX < 0)
            {
                kierunekX = -3;
                kierunekY = -2;
                
            }
            else if (pilka.Top + pilka.Height >= paletka.Top &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 > paletka.Left + paletka.Width - 50 &&
                (pilka.Left + pilka.Width + pilka.Left) / 2 <= paletka.Left + paletka.Width - 25 &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX < 0)
            {
                kierunekX = -3;
                kierunekY = -2;
            }
            else if (pilka.Top + pilka.Height >= paletka.Top &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)+5 > paletka.Left + paletka.Width - 25 &&
                ((pilka.Left + pilka.Width + pilka.Left) / 2)-5 <= paletka.Left + paletka.Width &&
                pilka.Top + pilka.Height <= paletka.Top + paletka.Height && kierunekX < 0)
            {
                kierunekX = -3;
                kierunekY = -2;
            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (bloczki[i, j].Visible == true)
                        if (pilka.Left <= bloczki[i, j].Left + bloczki[i, j].Width && pilka.Left+pilka.Width >= bloczki[i, j].Left &&
                            pilka.Top + 14 <= bloczki[i, j].Top + bloczki[i, j].Height && pilka.Top + pilka.Height - 14 >= bloczki[i, j].Top)
                        {
                            Console.WriteLine("bokiem");
                            bloczki[i, j].Visible = false;
                            kierunekX = -kierunekX;
                            wynik++;
                            label5.Text = "";
                            label6.Text = "";
                        }

                        else if ((pilka.Left + pilka.Width + pilka.Left) / 2 >= bloczki[i, j].Left &&
                            (pilka.Left + pilka.Width + pilka.Left) / 2 <= bloczki[i, j].Left + bloczki[i, j].Width && pilka.Top <= bloczki[i, j].Top + bloczki[i, j].Height &&
                            pilka.Top + pilka.Height >= bloczki[i, j].Top)
                        {
                            bloczki[i, j].Visible = false;
                            kierunekY = -kierunekY;
                            wynik++;
                            label5.Text = "";
                            label6.Text = "";
                        }
                       
                        
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            paletka.Left += paletkaX;
            if (paletka.Left <= 0 || paletka.Left + paletka.Width >= ClientSize.Width)
                paletkaX = -paletkaX;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                paletkaX = -paletkaX;
        }



    }
}

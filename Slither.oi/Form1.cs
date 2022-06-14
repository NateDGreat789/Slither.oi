using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slither.oi
{
    public partial class Form1 : Form
    {
        List<Rectangle> links1 = new List<Rectangle>();
        List<Rectangle> links2 = new List<Rectangle>();
        List<Rectangle> dots = new List<Rectangle>();
        List<String> dotsColour = new List<String>();

        bool leftDown = false;
        bool rightDown = false;
        bool aDown = false;
        bool dDown = false;
        bool p1dead = false;
        bool p2dead = false;

        int dotsc;
        int dotsCounter;
        int x1 = 1;
        int y1 = 1;
        int x2 = 1;
        int y2 = 1;
        int p1score = 0;
        int p2score = 0;
        int angle1 = 0;
        int angle2 = 0;
        int xspeed = 3;
        int yspeed = -3;

        float p1xSpeed;
        float p1ySpeed;
        float p2xSpeed;
        float p2ySpeed;
        float temp;
        float temp2;
        float temp3;
        float temp4;
        
        float thetaAngle;

        SolidBrush yellowBrush = new SolidBrush(Color.Goldenrod);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush turquoiseBrush = new SolidBrush(Color.Turquoise);

        Pen yellowPen = new Pen(Color.DarkGoldenrod, 2);
        Pen bluePen = new Pen(Color.DarkBlue, 2);


        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            links2.Add(new Rectangle(180, 580, 30, 30));
            links1.Add(new Rectangle(780, 580, 30, 30));

            for (int i = 0; i < 50; i++)
            {
                dots.Add(new Rectangle(rnd.Next(5, 995), rnd.Next(5, 695), 7, 7));
                dotsc = rnd.Next(0, 8);
                if (dotsc == 0)
                {
                    dotsColour.Add("yellow");
                }
                else if (dotsc == 1)
                {
                    dotsColour.Add("white");
                }
                else if (dotsc == 2)
                {
                    dotsColour.Add("blue");
                }
                else if (dotsc == 3)
                {
                    dotsColour.Add("green");
                }
                else if (dotsc == 4)
                {
                    dotsColour.Add("red");
                }
                else if (dotsc == 5)
                {
                    dotsColour.Add("orange");
                }
                else if (dotsc == 6)
                {
                    dotsColour.Add("purple");
                }
                else if (dotsc == 7)
                {
                    dotsColour.Add("turquoise");
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
            }
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            //move links
            if (links1.Count > 1)
            {
                for (int i = links1.Count - 1; i > 0; i--)
                {
                    links1[i] = new Rectangle(links1[i - 1].X, links1[i - 1].Y, 30, 30);
                }
            }
            
            if (links2.Count > 1)
            {
                for (int i = links2.Count - 1; i > 0; i--)
                {
                    links2[i] = new Rectangle(links2[i - 1].X, links2[i - 1].Y, 30, 30);
                }
            }

            //eat dots if intersected
            for (int i = 1; i < dots.Count; i++)
            {
                if (links1.Count > 0)
                { 
                    if (links1[0].IntersectsWith(dots[i]))
                    {
                        p1score++;
                        links1.Add(new Rectangle(links1[0].X, links1[0].Y, 30, 30));
                        links1.Add(new Rectangle(links1[0].X, links1[0].Y, 30, 30));
                        dots.RemoveAt(i);
                        dotsColour.RemoveAt(i);
                    }
                }
                if (links2.Count > 0)
                {
                    if (links2[0].IntersectsWith(dots[i]))
                    {
                        p2score++;
                        links2.Add(new Rectangle(links2[0].X, links2[0].Y, 30, 30));
                        links2.Add(new Rectangle(links2[0].X, links2[0].Y, 30, 30));
                        dots.RemoveAt(i);
                        dotsColour.RemoveAt(i);
                    }
                }
            }

            //move players
            if (leftDown == true)
            {
                angle1--;
            }
            if (rightDown == true)
            {
                angle1++;
            }

            if (aDown == true)
            {
                angle2--;
            }
            if (dDown == true)
            {
                angle2++;
            }

            if (angle1 < 0)
            {
                angle1 = 359;
            }
            if (angle1 > 359)
            {
                angle1 = 0;
            }

            if (angle2 < 0)
            {
                angle2 = 359;
            }
            if (angle2 > 359)
            {
                angle2 = 0;
            }

            thetaAngle = (90 - angle1);

            p1xSpeed = (float)Math.Cos(thetaAngle * xspeed);
            p1ySpeed = (float)Math.Sin(thetaAngle * yspeed * -1);
            p2xSpeed = (float)Math.Cos(thetaAngle * xspeed);
            p2ySpeed = (float)Math.Sin(thetaAngle * yspeed * -1);

            temp = links1[0].X + p1xSpeed;
            links1[0] = new Rectangle((int)temp, links1[0].Y, 30, 30);
            temp = links1[0].Y + p1ySpeed;
            links1[0] = new Rectangle(links1[0].X, (int)temp, 30, 30);

            temp = links2[0].X + p2xSpeed;
            links2[0] = new Rectangle((int)temp, links2[0].Y, 30, 30);
            temp = links2[0].Y + p2ySpeed;
            links2[0] = new Rectangle(links2[0].X, (int)temp, 30, 30);

            //check if players intersect
            for (int i = 0; i < links2.Count; i++)
            {
                if (links1.Count > 0)
                {
                    if (links1[0].IntersectsWith(links2[i]))
                    {
                        for (int j = 0; j < links1.Count; j += 2)
                        {
                            dots.Add(new Rectangle(rnd.Next(links1[j].X, links1[j].X + links1[j].Width), rnd.Next(links1[j].Y, links1[j].Y + links1[j].Height), 7, 7));
                            dotsc = rnd.Next(0, 8);
                            if (dotsc == 0)
                            {
                                dotsColour.Add("yellow");
                            }
                            else if (dotsc == 1)
                            {
                                dotsColour.Add("white");
                            }
                            else if (dotsc == 2)
                            {
                                dotsColour.Add("blue");
                            }
                            else if (dotsc == 3)
                            {
                                dotsColour.Add("green");
                            }
                            else if (dotsc == 4)
                            {
                                dotsColour.Add("red");
                            }
                            else if (dotsc == 5)
                            {
                                dotsColour.Add("orange");
                            }
                            else if (dotsc == 6)
                            {
                                dotsColour.Add("purple");
                            }
                            else if (dotsc == 7)
                            {
                                dotsColour.Add("turquoise");
                            }
                            links1.RemoveAt(0);
                        links1.Clear();
                        p1score = 0;
                        p1dead = true;
                        }
                        break;
                    }
                }
            }

            for (int i = 0; i < links1.Count; i++)
            {
                if (links2.Count > 0)
                {
                    if (links2[0].IntersectsWith(links1[i]))
                    {
                        for (int j = 0; j < links2.Count; j += 2)
                        {
                            dots.Add(new Rectangle(rnd.Next(links2[j].X, links2[j].X + links2[j].Width), rnd.Next(links2[j].Y, links2[j].Y + links2[j].Height), 7, 7));
                            dotsc = rnd.Next(0, 8);
                            if (dotsc == 0)
                            {
                                dotsColour.Add("yellow");
                            }
                            else if (dotsc == 1)
                            {
                                dotsColour.Add("white");
                            }
                            else if (dotsc == 2)
                            {
                                dotsColour.Add("blue");
                            }
                            else if (dotsc == 3)
                            {
                                dotsColour.Add("green");
                            }
                            else if (dotsc == 4)
                            {
                                dotsColour.Add("red");
                            }
                            else if (dotsc == 5)
                            {
                                dotsColour.Add("orange");
                            }
                            else if (dotsc == 6)
                            {
                                dotsColour.Add("purple");
                            }
                            else if (dotsc == 7)
                            {
                                dotsColour.Add("turquoise");
                            }
                            links2.RemoveAt(0);
                            links2.Clear();
                            p2score = 0;
                            p2dead = true;
                        }
                        break;
                    }
                }
            }

            //calculate score
            p1score = 0;
            if (links1.Count > 0)
            {
                p1score = links1.Count / 2 - 1;
            }
            p1scorelabel.Text = $"{p1score}";

            p2score = 0;
            if (links2.Count > 0)
            {
                p2score = links2.Count / 2 - 1;
            }
            p2scorelabel.Text = $"{p2score}";

            //add dots
            dotsCounter++;
            if (dotsCounter == 20)
            {
                dots.Add(new Rectangle(rnd.Next(5, 995), rnd.Next(5, 695), 7, 7));
                dotsc = rnd.Next(0, 8);
                if (dotsc == 0)
                {
                    dotsColour.Add("yellow");
                }
                else if (dotsc == 1)
                {
                    dotsColour.Add("white");
                }
                else if (dotsc == 2)
                {
                    dotsColour.Add("blue");
                }
                else if (dotsc == 3)
                {
                    dotsColour.Add("green");
                }
                else if (dotsc == 4)
                {
                    dotsColour.Add("red");
                }
                else if (dotsc == 5)
                {
                    dotsColour.Add("orange");
                }
                else if (dotsc == 6)
                {
                    dotsColour.Add("purple");
                }
                else if (dotsc == 7)
                {
                    dotsColour.Add("turquoise");
                }
                dotsCounter = 0;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            debugLabel.Text = $"angle1: {angle1}\n";
            debugLabel.Text += $"angle2: {angle2}\n";
            debugLabel.Text += $"thetaAngle: {thetaAngle}\n";
            debugLabel.Text += $"p1xSpeed: {p1xSpeed}\n";
            debugLabel.Text += $"p1ySpeed: {p1ySpeed}\n";
            for (int i = 0; i < links1.Count; i++)
            {
                e.Graphics.TranslateTransform(links1[i].X, links1[i].Y);
                e.Graphics.RotateTransform(angle1);
                e.Graphics.DrawRectangle(yellowPen, 0, 0,links1[i].Width, links1[i].Height);
                e.Graphics.FillEllipse(yellowBrush, 0, 0, links1[i].Width, links1[i].Height);
                e.Graphics.ResetTransform();
            }

            for (int i = 0; i < links2.Count; i++)
            {
                e.Graphics.RotateTransform(angle2);
                e.Graphics.DrawRectangle(bluePen, links2[i]);
                e.Graphics.FillEllipse(blueBrush, links2[i]);
                e.Graphics.ResetTransform();
            }

            for (int i = 0; i < dots.Count; i++)
            {
                if (dotsColour[i] == "yellow")
                {
                    e.Graphics.FillEllipse(yellowBrush, dots[i]);
                }
                else if (dotsColour[i] == "white")
                {
                    e.Graphics.FillEllipse(whiteBrush, dots[i]);
                }
                else if (dotsColour[i] == "blue")
                {
                    e.Graphics.FillEllipse(blueBrush, dots[i]);
                }
                else if (dotsColour[i] == "green")
                {
                    e.Graphics.FillEllipse(greenBrush, dots[i]);
                }
                else if (dotsColour[i] == "red")
                {
                    e.Graphics.FillEllipse(redBrush, dots[i]);
                }
                else if (dotsColour[i] == "orange")
                {
                    e.Graphics.FillEllipse(orangeBrush, dots[i]);
                }
                else if (dotsColour[i] == "purple")
                {
                    e.Graphics.FillEllipse(purpleBrush, dots[i]);
                }
                else if (dotsColour[i] == "turquoise")
                {
                    e.Graphics.FillEllipse(turquoiseBrush, dots[i]);
                }
            }
        }
    }
}

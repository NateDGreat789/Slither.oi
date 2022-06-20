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

namespace Slither.oi
{
    public partial class Form1 : Form
    {
        List<Rectangle> links1 = new List<Rectangle>();
        List<Rectangle> links2 = new List<Rectangle>();
        List<Rectangle> dots = new List<Rectangle>();
        List<String> dotsColour = new List<String>();

        Rectangle time = new Rectangle(0, 0, 0, 5);

        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool aDown = false;
        bool dDown = false;
        bool wDown = false;
        bool p1dead = false;
        bool p2dead = false;
        bool moveable1 = false;
        bool moveable2 = false;

        int dotsc;
        int dotsCounter;
        int p1score = 0;
        int p2score = 0;
        int angle1 = 0;
        int angle2 = 0;
        int p1Speed = 3;
        int p2Speed = 3;
        int deathCounter1;
        int deathCounter2;
        int player1Size = 25;
        int player2Size = 25;
        int p1speedCounter = 0;
        int p2speedCounter = 0;

        double timer = 1000;
        double p1xSpeed;
        double p1ySpeed;
        double p2xSpeed;
        double p2ySpeed;

        float temp;
        float thetaAngle1;
        float thetaAngle2;
        float p1x = 780;
        float p1y = 580;
        float p2x = 180;
        float p2y = 580;

        string gamestate = "waiting";

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
        }

        public void GameInitialize()
        {
            gamestate = "running";

            gametimer.Enabled = true;

            titlelabel.Visible = false;
            titlelabel.Visible = false;
            subtitlelabel.Visible = false;
            subtitle2label.Visible = false;
            control1label.Visible = false;
            control2label.Visible = false;

            p1scorelabel.Visible = true;
            p2scorelabel.Visible = true;

            links1.Clear();
            links2.Clear();
            dots.Clear();
            dotsColour.Clear();

            p1score = 0;
            p2score = 0;
            timer = 1000;
            dotsCounter = 0;
            angle1 = 0;
            angle2 = 0;

            for (int i = 0; i < 10; i++)
            {
                links1.Add(new Rectangle((int)p1x, (int)p1y, player1Size, player1Size));
                links2.Add(new Rectangle((int)p2x, (int)p2y, player2Size, player2Size));
            }

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
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
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
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.Space:
                    if (gamestate == "waiting")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gamestate == "waiting")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            //count down timer
            if (gamestate == "running")
            {
                timer -= 0.25;
                time.Width = (int)timer;
                if (timer == 0)
                {
                    gamestate = "over";
                }
            }

            //check for boost
            if (upDown == true && links1.Count > 10)
            {
                try
                {
                    p1speedCounter++;
                    p1Speed = 7;
                    if (p1speedCounter == 2)
                    {
                        links1.RemoveAt(links1.Count - 1);
                        p1speedCounter = 0;
                    }
                }
                catch
                {
                    p1Speed = 3;
                }
            }
            else
            {
                p1Speed = 3;
            }

            if (wDown == true && links2.Count > 10)
            {
                try
                {
                    p2speedCounter++;
                    p2Speed = 7;
                    if (p2speedCounter == 2)
                    {
                        links2.RemoveAt(links2.Count - 1);
                        p2speedCounter = 0;
                    }
                }
                catch
                {
                    p2Speed = 3;
                }
            }
            else
            {
                p2Speed = 3;
            }

            //move links
            if (links1.Count > 1)
            {
                for (int i = links1.Count - 1; i > 0; i--)
                {
                    links1[i] = new Rectangle(links1[i - 1].X, links1[i - 1].Y, player1Size, player1Size);
                }
            }
            
            if (links2.Count > 1)
            {
                for (int i = links2.Count - 1; i > 0; i--)
                {
                    links2[i] = new Rectangle(links2[i - 1].X, links2[i - 1].Y, player2Size, player2Size);
                }
            }

            //move players
            if (leftDown == true)
            {
                moveable1 = true;
                angle1 -= 6;
            }
            if (rightDown == true)
            {
                moveable1 = true;
                angle1 += 6;
            }

            if (aDown == true)
            {
                moveable2 = true;
                angle2 -= 6;
            }
            if (dDown == true)
            {
                moveable2 = true;
                angle2 += 6;
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

            thetaAngle1 = (90 - angle1);
            thetaAngle2 = (90 - angle2);

            p1xSpeed = Math.Cos(thetaAngle1 * Math.PI / 180.0);
            p1ySpeed = Math.Sin(thetaAngle1 * Math.PI / 180.0) * -1;
            p2xSpeed = Math.Cos(thetaAngle2 * Math.PI / 180.0);
            p2ySpeed = Math.Sin(thetaAngle2 * Math.PI / 180.0) * -1;

            if (gamestate == "running")
            {
                if (moveable1 == true)
                {
                    p1x += (float)p1xSpeed * p1Speed;
                    p1y += (float)p1ySpeed * p1Speed;
                }

                if (moveable2 == true)
                {
                    p2x += (float)p2xSpeed * p2Speed;
                    p2y += (float)p2ySpeed * p2Speed;
                }
            }

            //create player rectangles
            if (gamestate == "running")
            {
                if (p1dead == false)
                {
                    links1[0] = new Rectangle((int)p1x, (int)p1y, player1Size, player1Size);
                }
                if (p2dead == false)
                {
                    links2[0] = new Rectangle((int)p2x, (int)p2y, player2Size, player2Size);
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
                        for (int j = 0; j < 5; j++)
                        {
                            links1.Add(new Rectangle(links1[0].X, links1[0].Y, player1Size, player1Size));
                        }
                        dots.RemoveAt(i);
                        dotsColour.RemoveAt(i);
                        break;
                    }
                }
                if (links2.Count > 0)
                {
                    if (links2[0].IntersectsWith(dots[i]))
                    {
                        p2score++;
                        for (int j = 0; j < 5; j++)
                        {
                            links2.Add(new Rectangle(links2[0].X, links2[0].Y, player2Size, player2Size));
                        }
                        dots.RemoveAt(i);
                        dotsColour.RemoveAt(i);
                        break;
                    }
                }
            }

            //check if players are out of bounds
            if (links1.Count > 0)
            {
                if (links1[0].X < 0)
                {
                    links1[0] = new Rectangle(0, links1[0].Y, 30, 30);
                }
                if (links1[0].X > 1000)
                {
                    links1[0] = new Rectangle(1000, links1[0].Y, 30, 30);
                }
                if (links1[0].Y < 0)
                {
                    links1[0] = new Rectangle(links2[0].X, 0, 30, 30);
                }
                if (links1[0].Y > 700)
                {
                    links1[0] = new Rectangle(links1[0].X, 700, 30, 30);
                }
            }

            if (links2.Count > 0)
            {
                if (links2[0].X < 0)
                {
                    links2[0] = new Rectangle(0, links2[0].Y, 30, 30);
                }
                if (links2[0].X > 1000)
                {
                    links2[0] = new Rectangle(1000, links2[0].Y, 30, 30);
                }
                if (links2[0].Y < 0)
                {
                    links2[0] = new Rectangle(links2[0].X, 0, 30, 30);
                }
                if (links2[0].Y > 700)
                {
                    links2[0] = new Rectangle(links2[0].X, 700, 30, 30);
                }
            }

            //check if players intersect
            for (int i = 0; i < links2.Count; i++)
            {
                if (links1.Count > 0)
                {
                    if (links1[0].IntersectsWith(links2[i]))
                    {
                        moveable1 = false;
                        links1.Clear();
                        p1score = 0;
                        p1dead = true;
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
                        }
                    }
                }
            }

            for (int i = 0; i < links1.Count; i++)
            {
                if (links2.Count > 0)
                {
                    if (links2[0].IntersectsWith(links1[i]))
                    {
                        moveable2 = false;
                        links2.Clear();
                        p2score = 0;
                        p2dead = true;
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
                        }
                    }
                }
            }

            //revive player if it is time
            if (p1dead == true)
            {
                deathCounter1++;
            }

            if (deathCounter1 == 100)
            {
                p1dead = false;
                deathCounter1 = 0;
                links1.Add(new Rectangle(780, 580, 30, 30));
            }

            if (p2dead == true)
            {
                deathCounter2++;
            }

            if (deathCounter2 == 100)
            {
                p2dead = false;
                deathCounter2 = 0;
                links2.Add(new Rectangle(180, 580, 30, 30));
            }

            //calculate score
            p1score = 0;
            if (links1.Count > 1)
            {
                p1score = (links1.Count - 10) / 5;
            }
            p1scorelabel.Text = $"{p1score}";

            p2score = 0;
            if (links2.Count > 0)
            {
                p2score = (links2.Count - 10) / 5;
            }
            p2scorelabel.Text = $"{p2score}";

            //add dots
            if (gamestate == "running")
            {
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
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < links1.Count; i++)
            {
                e.Graphics.TranslateTransform(links1[i].X, links1[i].Y);
                e.Graphics.RotateTransform(angle1);
                if (i == 0)
                {
                    e.Graphics.DrawRectangle(yellowPen, 0, 0, links1[i].Width, links1[i].Height);
                    e.Graphics.FillEllipse(redBrush, 0, 0, links1[i].Width, links1[i].Height);
                }
                else
                {
                    e.Graphics.DrawRectangle(yellowPen, 0, 0, links1[i].Width, links1[i].Height);
                    e.Graphics.FillEllipse(yellowBrush, 0, 0, links1[i].Width, links1[i].Height);
                }
                e.Graphics.ResetTransform();
            }

            for (int i = 0; i < links2.Count; i++)
            {
                e.Graphics.TranslateTransform(links2[i].X, links2[i].Y);
                e.Graphics.RotateTransform(angle2);
                if (i == 0)
                {
                    e.Graphics.DrawRectangle(bluePen, 0, 0, links2[i].Width, links2[i].Height);
                    e.Graphics.FillEllipse(greenBrush, 0, 0, links2[i].Width, links2[i].Height);
                }
                else
                {
                    e.Graphics.DrawRectangle(bluePen, 0, 0, links2[i].Width, links2[i].Height);
                    e.Graphics.FillEllipse(blueBrush, 0, 0, links2[i].Width, links2[i].Height);
                }
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

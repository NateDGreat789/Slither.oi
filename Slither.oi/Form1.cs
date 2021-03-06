using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
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
        int p1SUpC = 0;
        int p2SUpC = 0;
        int p1speedCounter = 0;
        int p2speedCounter = 0;
        int p1dc = 0;
        int p2dc = 0;

        double timer = 1000;
        double p1xSpeed;
        double p1ySpeed;
        double p2xSpeed;
        double p2ySpeed;

        float thetaAngle1;
        float thetaAngle2;
        float p1x = 780;
        float p1y = 580;
        float p2x = 180;
        float p2y = 580;

        string gamestate = "waiting";

        SolidBrush yellowBrush = new SolidBrush(Color.Goldenrod);
        SolidBrush blueBrush = new SolidBrush(Color.RoyalBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush turquoiseBrush = new SolidBrush(Color.Turquoise);

        Pen yellowPen = new Pen(Color.DarkGoldenrod, 2);
        Pen bluePen = new Pen(Color.Blue, 2);

        SoundPlayer eat = new SoundPlayer(Properties.Resources.eat);
        SoundPlayer boom = new SoundPlayer(Properties.Resources.boom);
        SoundPlayer win = new SoundPlayer(Properties.Resources.win);

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
            subtitlelabel.Visible = false;
            subtitle2label.Visible = false;
            control1label.Visible = false;
            control2label.Visible = false;

            p2scorelabel.Visible = true;
            p1scorelabel.Visible = true;

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
                    if (gamestate == "waiting" || gamestate == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gamestate == "waiting" || gamestate == "over")
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
                timer -=  0.5;
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
                angle1 -= 5;
            }
            if (rightDown == true)
            {
                moveable1 = true;
                angle1 += 5;
            }

            if (aDown == true)
            {
                moveable2 = true;
                angle2 -= 5;
            }
            if (dDown == true)
            {
                moveable2 = true;
                angle2 += 5;
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
                        eat.Play();
                        p1score++;
                        p1SUpC++;
                        if (p1SUpC == 8)
                        {
                            player1Size += 3;
                            p1SUpC = 0;
                        }
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
                        eat.Play();
                        p2score++;
                        p2SUpC++;
                        if (p2SUpC == 8)
                        {
                            player2Size += 3;
                            p1SUpC = 0;
                        }
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
            
            //check if players intersect
            for (int i = 0; i < links2.Count; i++)
            {
                if (links1.Count > 0)
                {
                    if (links1[0].IntersectsWith(links2[i]))
                    {
                        boom.Play();
                        p1dc++;
                        moveable1 = false;
                        for (int j = 0; j < links1.Count; j++)
                        {
                            links2.Add(new Rectangle(links2[0].X, links2[0].Y, player2Size, player2Size));
                            p2SUpC++;
                            if (p2SUpC == 8)
                            {
                                player2Size += 3;
                                p2SUpC = 0;
                            }
                        }
                        links1.Clear();
                        p1score = 0;
                        p1dead = true;
                    }
                }
            }

            for (int i = 0; i < links1.Count; i++)
            {
                if (links2.Count > 0)
                {
                    if (links2[0].IntersectsWith(links1[i]))
                    {
                        boom.Play();
                        p2dc++;
                        moveable2 = false;
                        for (int j = 0; j < links2.Count; j++)
                        {
                            links1.Add(new Rectangle(links1[0].X, links1[0].Y, player1Size, player1Size));
                            p1SUpC++;
                            if (p1SUpC == 8)
                            {
                                player1Size += 3;
                                p1SUpC = 0;
                            }
                        }
                        links2.Clear();
                        p2score = 0;
                        p2dead = true;
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
                p1SUpC = 0;
                player1Size = 25;
                deathCounter1 = 0;
                angle1 = 0;
                p1x = rnd.Next(40, 960);
                p1y = rnd.Next(40, 660);
                for (int i = 0; i < 10; i++)
                {
                    links1.Add(new Rectangle(780, 580, player1Size, player1Size));
                }
            }

            if (p2dead == true)
            {
                deathCounter2++;
            }

            if (deathCounter2 == 100)
            {
                p2dead = false;
                p2SUpC = 0;
                player2Size = 25;
                deathCounter2 = 0;
                angle2 = 0;
                p2x = rnd.Next(40, 960);
                p2y = rnd.Next(40, 660);
                for (int i = 0; i < 10; i++)
                {
                    links2.Add(new Rectangle(780, 580, player2Size, player2Size));
                }
            }

            //calculate score
            p1score = 0;
            if (links1.Count > 1)
            {
                p1score = (links1.Count - 10) / 5;
            }
            p2scorelabel.Text = $"{p1score}";

            p2score = 0;
            if (links2.Count > 0)
            {
                p2score = (links2.Count - 10) / 5;
            }
            p1scorelabel.Text = $"{p2score}";

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

            if (gamestate == "over")
            {
                win.Play();
                if (p1score > p2score)
                {
                    titlelabel.Text = "PLAYER 2 WINS!";
                }
                else if (p2score > p1score)
                {
                    titlelabel.Text = "PLAYER 1 WINS!";
                }
                else
                {
                    titlelabel.Text = "TIE!";
                }

                titlelabel.Visible = true;
                subtitlelabel.Visible = true;
                subtitle2label.Visible = true;

                control1label.Text = $"Player 1 score: {p2score}\nKills: {p2dc}";
                control2label.Text = $"Player 2 score: {p1score}\nKills: {p1dc}";
                control1label.Visible = true;
                control2label.Visible = true;

                p2scorelabel.Visible = false;
                p1scorelabel.Visible = false;

                player1Size = 0;
                player2Size = 0;


                p1score = 0;
                p2score = 0;

                links1.Clear();
                links2.Clear();
                dots.Clear();
                dotsColour.Clear();

                gametimer.Enabled = false;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < links1.Count; i++)
            {
                e.Graphics.DrawEllipse(yellowPen, links1[i].X, links1[i].Y, links1[i].Width, links1[i].Height);
                e.Graphics.FillEllipse(yellowBrush, links1[i].X, links1[i].Y, links1[i].Width, links1[i].Height);
            }

            for (int i = 0; i < links2.Count; i++)
            {
                e.Graphics.DrawEllipse(bluePen, links2[i].X, links2[i].Y, links2[i].Width, links2[i].Height);
                e.Graphics.FillEllipse(blueBrush, links2[i].X, links2[i].Y, links2[i].Width, links2[i].Height);
            }

            e.Graphics.FillRectangle(whiteBrush, time);

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

namespace Slither.oi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.p2scorelabel = new System.Windows.Forms.Label();
            this.p1scorelabel = new System.Windows.Forms.Label();
            this.titlelabel = new System.Windows.Forms.Label();
            this.subtitlelabel = new System.Windows.Forms.Label();
            this.control1label = new System.Windows.Forms.Label();
            this.control2label = new System.Windows.Forms.Label();
            this.subtitle2label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 20;
            this.gametimer.Tick += new System.EventHandler(this.gametimer_Tick);
            // 
            // p2scorelabel
            // 
            this.p2scorelabel.ForeColor = System.Drawing.Color.White;
            this.p2scorelabel.Location = new System.Drawing.Point(12, 9);
            this.p2scorelabel.Name = "p2scorelabel";
            this.p2scorelabel.Size = new System.Drawing.Size(25, 13);
            this.p2scorelabel.TabIndex = 1;
            // 
            // p1scorelabel
            // 
            this.p1scorelabel.ForeColor = System.Drawing.Color.White;
            this.p1scorelabel.Location = new System.Drawing.Point(953, 9);
            this.p1scorelabel.Name = "p1scorelabel";
            this.p1scorelabel.Size = new System.Drawing.Size(35, 13);
            this.p1scorelabel.TabIndex = 2;
            // 
            // titlelabel
            // 
            this.titlelabel.Font = new System.Drawing.Font("Sitka Small", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.ForeColor = System.Drawing.Color.White;
            this.titlelabel.Location = new System.Drawing.Point(182, 183);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(638, 116);
            this.titlelabel.TabIndex = 3;
            this.titlelabel.Text = "SLITHER.OI";
            // 
            // subtitlelabel
            // 
            this.subtitlelabel.AutoSize = true;
            this.subtitlelabel.Font = new System.Drawing.Font("Sitka Small", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitlelabel.ForeColor = System.Drawing.Color.White;
            this.subtitlelabel.Location = new System.Drawing.Point(311, 344);
            this.subtitlelabel.Name = "subtitlelabel";
            this.subtitlelabel.Size = new System.Drawing.Size(366, 71);
            this.subtitlelabel.TabIndex = 4;
            this.subtitlelabel.Text = "SPACE to play";
            // 
            // control1label
            // 
            this.control1label.Font = new System.Drawing.Font("Sitka Small", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.control1label.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.control1label.Location = new System.Drawing.Point(56, 459);
            this.control1label.Name = "control1label";
            this.control1label.Size = new System.Drawing.Size(506, 232);
            this.control1label.TabIndex = 5;
            this.control1label.Text = "Player 1 Controls:\r\nA and D to move\r\nW to boost";
            // 
            // control2label
            // 
            this.control2label.Font = new System.Drawing.Font("Sitka Small", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.control2label.ForeColor = System.Drawing.Color.Gold;
            this.control2label.Location = new System.Drawing.Point(503, 459);
            this.control2label.Name = "control2label";
            this.control2label.Size = new System.Drawing.Size(460, 232);
            this.control2label.TabIndex = 6;
            this.control2label.Text = "Player 2 Controls:\r\nLeft and Right to move\r\nUp to boost";
            // 
            // subtitle2label
            // 
            this.subtitle2label.AutoSize = true;
            this.subtitle2label.Font = new System.Drawing.Font("Sitka Small", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle2label.ForeColor = System.Drawing.Color.White;
            this.subtitle2label.Location = new System.Drawing.Point(365, 9);
            this.subtitle2label.Name = "subtitle2label";
            this.subtitle2label.Size = new System.Drawing.Size(263, 48);
            this.subtitle2label.TabIndex = 7;
            this.subtitle2label.Text = "ESCAPE to quit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.subtitle2label);
            this.Controls.Add(this.control2label);
            this.Controls.Add(this.control1label);
            this.Controls.Add(this.subtitlelabel);
            this.Controls.Add(this.titlelabel);
            this.Controls.Add(this.p1scorelabel);
            this.Controls.Add(this.p2scorelabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.Label p2scorelabel;
        private System.Windows.Forms.Label p1scorelabel;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label subtitlelabel;
        private System.Windows.Forms.Label control1label;
        private System.Windows.Forms.Label control2label;
        private System.Windows.Forms.Label subtitle2label;
    }
}


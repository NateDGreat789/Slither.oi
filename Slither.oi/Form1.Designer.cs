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
            this.debugLabel = new System.Windows.Forms.Label();
            this.p1scorelabel = new System.Windows.Forms.Label();
            this.p2scorelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 20;
            this.gametimer.Tick += new System.EventHandler(this.gametimer_Tick);
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.ForeColor = System.Drawing.Color.White;
            this.debugLabel.Location = new System.Drawing.Point(845, 504);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(35, 13);
            this.debugLabel.TabIndex = 0;
            this.debugLabel.Text = "label1";
            // 
            // p1scorelabel
            // 
            this.p1scorelabel.AutoSize = true;
            this.p1scorelabel.ForeColor = System.Drawing.Color.White;
            this.p1scorelabel.Location = new System.Drawing.Point(12, 9);
            this.p1scorelabel.Name = "p1scorelabel";
            this.p1scorelabel.Size = new System.Drawing.Size(0, 13);
            this.p1scorelabel.TabIndex = 1;
            // 
            // p2scorelabel
            // 
            this.p2scorelabel.AutoSize = true;
            this.p2scorelabel.ForeColor = System.Drawing.Color.White;
            this.p2scorelabel.Location = new System.Drawing.Point(953, 9);
            this.p2scorelabel.Name = "p2scorelabel";
            this.p2scorelabel.Size = new System.Drawing.Size(0, 13);
            this.p2scorelabel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.p2scorelabel);
            this.Controls.Add(this.p1scorelabel);
            this.Controls.Add(this.debugLabel);
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
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Label p1scorelabel;
        private System.Windows.Forms.Label p2scorelabel;
    }
}


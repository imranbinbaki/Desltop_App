
namespace FarmFriends
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.RefreshBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CircleProgressBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CircleProgressBar1
            // 
            this.CircleProgressBar1.Controls.Add(this.RefreshBox);
            this.CircleProgressBar1.FillColor = System.Drawing.Color.RoyalBlue;
            this.CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.CircleProgressBar1.ForeColor = System.Drawing.Color.White;
            this.CircleProgressBar1.InnerColor = System.Drawing.Color.Transparent;
            this.CircleProgressBar1.Location = new System.Drawing.Point(187, 106);
            this.CircleProgressBar1.Minimum = 0;
            this.CircleProgressBar1.Name = "CircleProgressBar1";
            this.CircleProgressBar1.ProgressColor = System.Drawing.Color.White;
            this.CircleProgressBar1.ProgressColor2 = System.Drawing.Color.White;
            this.CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.CircleProgressBar1.Size = new System.Drawing.Size(201, 201);
            this.CircleProgressBar1.TabIndex = 0;
            this.CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // RefreshBox
            // 
            this.RefreshBox.BackColor = System.Drawing.Color.Transparent;
            this.RefreshBox.Image = ((System.Drawing.Image)(resources.GetObject("RefreshBox.Image")));
            this.RefreshBox.Location = new System.Drawing.Point(49, 58);
            this.RefreshBox.Name = "RefreshBox";
            this.RefreshBox.Size = new System.Drawing.Size(105, 87);
            this.RefreshBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RefreshBox.TabIndex = 153;
            this.RefreshBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(92, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(404, 36);
            this.label5.TabIndex = 143;
            this.label5.Text = "Agro Solution Software";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(213, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 144;
            this.label2.Text = "Loading ... .. .";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 145;
            this.label1.Text = "V.2.1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(473, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 24);
            this.label3.TabIndex = 146;
            this.label3.Text = "Group -A";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(585, 438);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CircleProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.CircleProgressBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefreshBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar CircleProgressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox RefreshBox;
    }
}

namespace Project_Group_10
{
    partial class ScreenStart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart1 = new Project_Group_10.ButtonStart();
            this.SuspendLayout();
            // 
            // buttonStart1
            // 
            this.buttonStart1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonStart1.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.buttonStart1.BoderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonStart1.Boderradius = 40;
            this.buttonStart1.BoderSize = 0;
            this.buttonStart1.FlatAppearance.BorderSize = 0;
            this.buttonStart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart1.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStart1.ForeColor = System.Drawing.Color.White;
            this.buttonStart1.Location = new System.Drawing.Point(376, 357);
            this.buttonStart1.Name = "buttonStart1";
            this.buttonStart1.Size = new System.Drawing.Size(245, 73);
            this.buttonStart1.TabIndex = 1;
            this.buttonStart1.Text = "START";
            this.buttonStart1.TextColor = System.Drawing.Color.White;
            this.buttonStart1.UseVisualStyleBackColor = false;
            this.buttonStart1.Click += new System.EventHandler(this.buttonStart1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.BackgroundImage = global::Project_Group_10.Properties.Resources.QUIZ__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1043, 534);
            this.Controls.Add(this.buttonStart1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonStart buttonStart1;
    }
}


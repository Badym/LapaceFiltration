namespace LaplaceFilter
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
<<<<<<< HEAD
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cppCheckBox = new System.Windows.Forms.CheckBox();
            this.asmCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
=======
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
>>>>>>> origin/main
            this.SuspendLayout();
            // 
            // button1
            // 
<<<<<<< HEAD
            this.button1.Location = new System.Drawing.Point(920, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open image";
=======
            this.button1.Location = new System.Drawing.Point(30, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 110);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
>>>>>>> origin/main
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Label1";
            this.label1.Text = "Orginal Img";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(554, 443);
=======
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Label1";
            this.label1.Text = "Result";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(67, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 297);
>>>>>>> origin/main
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "picturebox_1";
            // 
            // button2
            // 
<<<<<<< HEAD
            this.button2.Location = new System.Drawing.Point(1017, 578);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Run";
=======
            this.button2.Location = new System.Drawing.Point(827, 482);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 110);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
>>>>>>> origin/main
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
<<<<<<< HEAD
            this.pictureBox2.Location = new System.Drawing.Point(572, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(554, 443);
=======
            this.pictureBox2.Location = new System.Drawing.Point(707, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(340, 297);
>>>>>>> origin/main
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "picturebox_1";
            // 
<<<<<<< HEAD
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 526);
            this.trackBar1.Maximum = 64;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1096, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(569, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Tag = "Label2";
            this.label2.Text = "Result Img";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Tag = "label3";
            this.label3.Text = "Count of Threats";
            // 
            // cppCheckBox
            // 
            this.cppCheckBox.AutoSize = true;
            this.cppCheckBox.Location = new System.Drawing.Point(12, 589);
            this.cppCheckBox.Name = "cppCheckBox";
            this.cppCheckBox.Size = new System.Drawing.Size(45, 17);
            this.cppCheckBox.TabIndex = 8;
            this.cppCheckBox.Text = "C++";
            this.cppCheckBox.UseVisualStyleBackColor = true;
            // 
            // asmCheckBox
            // 
            this.asmCheckBox.AutoSize = true;
            this.asmCheckBox.Location = new System.Drawing.Point(63, 589);
            this.asmCheckBox.Name = "asmCheckBox";
            this.asmCheckBox.Size = new System.Drawing.Size(46, 17);
            this.asmCheckBox.TabIndex = 9;
            this.asmCheckBox.Text = "Asm";
            this.asmCheckBox.UseVisualStyleBackColor = true;
            // 
=======
>>>>>>> origin/main
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 617);
<<<<<<< HEAD
            this.Controls.Add(this.asmCheckBox);
            this.Controls.Add(this.cppCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
=======
>>>>>>> origin/main
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
<<<<<<< HEAD
            this.Text = "Błażej Sztefka LaplaceFilter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
=======
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
>>>>>>> origin/main
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
<<<<<<< HEAD
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cppCheckBox;
        private System.Windows.Forms.CheckBox asmCheckBox;
=======
>>>>>>> origin/main
    }
}


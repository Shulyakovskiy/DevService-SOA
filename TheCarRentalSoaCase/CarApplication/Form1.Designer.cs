namespace CarApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_listcar = new System.Windows.Forms.Button();
            this.btn_insertNewCar = new System.Windows.Forms.Button();
            this.btn_getcarPicture = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Car Application";
            // 
            // btn_listcar
            // 
            this.btn_listcar.Location = new System.Drawing.Point(18, 68);
            this.btn_listcar.Name = "btn_listcar";
            this.btn_listcar.Size = new System.Drawing.Size(178, 46);
            this.btn_listcar.TabIndex = 1;
            this.btn_listcar.Text = "ListCars";
            this.btn_listcar.UseVisualStyleBackColor = true;
            this.btn_listcar.Click += new System.EventHandler(this.btn_listcar_Click);
            // 
            // btn_insertNewCar
            // 
            this.btn_insertNewCar.Location = new System.Drawing.Point(18, 120);
            this.btn_insertNewCar.Name = "btn_insertNewCar";
            this.btn_insertNewCar.Size = new System.Drawing.Size(178, 46);
            this.btn_insertNewCar.TabIndex = 2;
            this.btn_insertNewCar.Text = "InsertNewCar";
            this.btn_insertNewCar.UseVisualStyleBackColor = true;
            this.btn_insertNewCar.Click += new System.EventHandler(this.btn_insertNewCar_Click);
            // 
            // btn_getcarPicture
            // 
            this.btn_getcarPicture.Location = new System.Drawing.Point(18, 177);
            this.btn_getcarPicture.Name = "btn_getcarPicture";
            this.btn_getcarPicture.Size = new System.Drawing.Size(178, 46);
            this.btn_getcarPicture.TabIndex = 3;
            this.btn_getcarPicture.Text = "GetCarPicture";
            this.btn_getcarPicture.UseVisualStyleBackColor = true;
            this.btn_getcarPicture.Click += new System.EventHandler(this.btn_getcarPicture_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(202, 68);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(198, 277);
            this.listBox1.TabIndex = 4;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(18, 352);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(382, 95);
            this.listBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 229);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(406, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 181);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_getcarPicture);
            this.Controls.Add(this.btn_insertNewCar);
            this.Controls.Add(this.btn_listcar);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Car Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_listcar;
        private System.Windows.Forms.Button btn_insertNewCar;
        private System.Windows.Forms.Button btn_getcarPicture;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


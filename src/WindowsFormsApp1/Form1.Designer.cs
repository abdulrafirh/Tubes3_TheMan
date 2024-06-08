namespace WindowsFormsApp1
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
            this.imageInput = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TitleText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OutputImage = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.InputImage = new System.Windows.Forms.PictureBox();
            this.AlgToggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imageInput
            // 
            this.imageInput.Location = new System.Drawing.Point(215, 69);
            this.imageInput.Name = "imageInput";
            this.imageInput.Size = new System.Drawing.Size(198, 43);
            this.imageInput.TabIndex = 1;
            this.imageInput.Text = "Click me! (Input Image)";
            this.imageInput.UseVisualStyleBackColor = true;
            this.imageInput.Click += new System.EventHandler(this.ImageInputButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Comic Sans MS", 24F);
            this.TitleText.Location = new System.Drawing.Point(71, 12);
            this.TitleText.Multiline = true;
            this.TitleText.Name = "TitleText";
            this.TitleText.ReadOnly = true;
            this.TitleText.Size = new System.Drawing.Size(479, 51);
            this.TitleText.TabIndex = 2;
            this.TitleText.Text = "THE MAN\'S FINGERPRINTS";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(215, 167);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(198, 43);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search!";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // OutputImage
            // 
            this.OutputImage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OutputImage.Location = new System.Drawing.Point(464, 260);
            this.OutputImage.Name = "OutputImage";
            this.OutputImage.Size = new System.Drawing.Size(131, 123);
            this.OutputImage.TabIndex = 4;
            this.OutputImage.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(190, 223);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(254, 160);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // InputImage
            // 
            this.InputImage.Location = new System.Drawing.Point(40, 260);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(133, 123);
            this.InputImage.TabIndex = 6;
            this.InputImage.TabStop = false;
            // 
            // AlgToggle
            // 
            this.AlgToggle.Text = "Now using: KMP\n(Click to toggle)";
            this.AlgToggle.Location = new System.Drawing.Point(215, 118);
            this.AlgToggle.Name = "AlgToggle";
            this.AlgToggle.Size = new System.Drawing.Size(198, 43);
            this.AlgToggle.TabIndex = 7;
            this.AlgToggle.UseVisualStyleBackColor = true;
            this.AlgToggle.Click += new System.EventHandler(this.AlgToggle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 429);
            this.Controls.Add(this.AlgToggle);
            this.Controls.Add(this.InputImage);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.OutputImage);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.imageInput);
            this.Name = "Form1";
            this.Text = "The Man\'s Fingerprints";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button imageInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TitleText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.PictureBox OutputImage;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox InputImage;
        private System.Windows.Forms.Button AlgToggle;
    }
}


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
            this.components = new System.ComponentModel.Container();
            this.imageInput = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TitleText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OutputImage = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.InputImage = new System.Windows.Forms.PictureBox();
            this.AlgToggle = new System.Windows.Forms.Button();
            this.YourImageText = new System.Windows.Forms.RichTextBox();
            this.SearchResultText = new System.Windows.Forms.RichTextBox();
            this.PerfCounterText = new System.Windows.Forms.RichTextBox();
            this.InputErrorMsg = new System.Windows.Forms.RichTextBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
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
            this.OutputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputImage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OutputImage.Location = new System.Drawing.Point(464, 260);
            this.OutputImage.Name = "OutputImage";
            this.OutputImage.Size = new System.Drawing.Size(131, 123);
            this.OutputImage.TabIndex = 4;
            this.OutputImage.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(190, 242);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(247, 160);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // InputImage
            // 
            this.InputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputImage.Location = new System.Drawing.Point(40, 260);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(133, 123);
            this.InputImage.TabIndex = 6;
            this.InputImage.TabStop = false;
            // 
            // AlgToggle
            // 
            this.AlgToggle.Location = new System.Drawing.Point(215, 118);
            this.AlgToggle.Name = "AlgToggle";
            this.AlgToggle.Size = new System.Drawing.Size(198, 43);
            this.AlgToggle.TabIndex = 7;
            this.AlgToggle.Text = "Now using: KMP\n(Click to toggle)";
            this.AlgToggle.UseVisualStyleBackColor = true;
            this.AlgToggle.Click += new System.EventHandler(this.AlgToggle_Click);
            // 
            // YourImageText
            // 
            this.YourImageText.BackColor = System.Drawing.SystemColors.Control;
            this.YourImageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.YourImageText.Font = new System.Drawing.Font("Cambria Math", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YourImageText.HideSelection = false;
            this.YourImageText.Location = new System.Drawing.Point(40, 227);
            this.YourImageText.Name = "YourImageText";
            this.YourImageText.ReadOnly = true;
            this.YourImageText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.YourImageText.Size = new System.Drawing.Size(133, 29);
            this.YourImageText.TabIndex = 8;
            this.YourImageText.Text = "YOUR IMAGE:";
            this.YourImageText.Visible = false;
            // 
            // SearchResultText
            // 
            this.SearchResultText.BackColor = System.Drawing.SystemColors.Control;
            this.SearchResultText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchResultText.Font = new System.Drawing.Font("Cambria Math", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SearchResultText.HideSelection = false;
            this.SearchResultText.Location = new System.Drawing.Point(443, 192);
            this.SearchResultText.Name = "SearchResultText";
            this.SearchResultText.ReadOnly = true;
            this.SearchResultText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.SearchResultText.Size = new System.Drawing.Size(176, 64);
            this.SearchResultText.TabIndex = 9;
            this.SearchResultText.Text = "SEARCH RESULT:";
            this.SearchResultText.Visible = false;
            this.SearchResultText.TextChanged += new System.EventHandler(this.SearchResultText_TextChanged);
            // 
            // PerfCounterText
            // 
            this.PerfCounterText.BackColor = System.Drawing.SystemColors.Control;
            this.PerfCounterText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PerfCounterText.HideSelection = false;
            this.PerfCounterText.Location = new System.Drawing.Point(440, 408);
            this.PerfCounterText.Name = "PerfCounterText";
            this.PerfCounterText.ReadOnly = true;
            this.PerfCounterText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.PerfCounterText.Size = new System.Drawing.Size(179, 20);
            this.PerfCounterText.TabIndex = 10;
            this.PerfCounterText.Text = "The last calculation took: -";
            this.PerfCounterText.Visible = false;
            // 
            // InputErrorMsg
            // 
            this.InputErrorMsg.BackColor = System.Drawing.SystemColors.Control;
            this.InputErrorMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputErrorMsg.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.InputErrorMsg.Location = new System.Drawing.Point(6, 79);
            this.InputErrorMsg.Name = "InputErrorMsg";
            this.InputErrorMsg.Size = new System.Drawing.Size(207, 33);
            this.InputErrorMsg.TabIndex = 11;
            this.InputErrorMsg.Text = "Your file is🗙 try again! -->";
            this.InputErrorMsg.Visible = false;
            this.InputErrorMsg.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(WindowsFormsApp1.Form1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 429);
            this.Controls.Add(this.InputErrorMsg);
            this.Controls.Add(this.PerfCounterText);
            this.Controls.Add(this.SearchResultText);
            this.Controls.Add(this.YourImageText);
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
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
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
        private System.Windows.Forms.RichTextBox SearchResultText;
        private System.Windows.Forms.RichTextBox YourImageText;
        private System.Windows.Forms.RichTextBox PerfCounterText;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.RichTextBox InputErrorMsg;
    }
}


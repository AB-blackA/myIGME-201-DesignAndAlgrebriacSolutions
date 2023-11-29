namespace PE17___Guessing_Game
{
    partial class GameForm
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
            this.guessButton = new System.Windows.Forms.Button();
            this.guessTextBox = new System.Windows.Forms.TextBox();
            this.hintLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.guessButtonLabel = new System.Windows.Forms.Label();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guessButton
            // 
            this.guessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guessButton.Location = new System.Drawing.Point(35, 80);
            this.guessButton.Name = "guessButton";
            this.guessButton.Size = new System.Drawing.Size(100, 43);
            this.guessButton.TabIndex = 0;
            this.guessButton.Text = "Guess";
            this.guessButton.UseVisualStyleBackColor = true;
            // 
            // guessTextBox
            // 
            this.guessTextBox.Location = new System.Drawing.Point(35, 54);
            this.guessTextBox.Name = "guessTextBox";
            this.guessTextBox.Size = new System.Drawing.Size(100, 20);
            this.guessTextBox.TabIndex = 1;
            this.guessTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.hintLabel.Location = new System.Drawing.Point(177, 54);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(203, 26);
            this.hintLabel.TabIndex = 2;
            this.hintLabel.Text = "Waiting for Guess...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 151);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(392, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Location = new System.Drawing.Point(45, 9);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(82, 13);
            this.rangeLabel.TabIndex = 4;
            this.rangeLabel.Text = "Range of Game";
            this.rangeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // guessButtonLabel
            // 
            this.guessButtonLabel.AutoSize = true;
            this.guessButtonLabel.Location = new System.Drawing.Point(40, 38);
            this.guessButtonLabel.Name = "guessButtonLabel";
            this.guessButtonLabel.Size = new System.Drawing.Size(91, 13);
            this.guessButtonLabel.TabIndex = 5;
            this.guessButtonLabel.Text = "Your Guess Here!";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 90;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(370, 16);
            this.toolStripProgressBar1.Value = 90;
            // 
            // GameForm
            // 
            this.AcceptButton = this.guessButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 173);
            this.Controls.Add(this.guessButtonLabel);
            this.Controls.Add(this.rangeLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.guessTextBox);
            this.Controls.Add(this.guessButton);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button guessButton;
        private System.Windows.Forms.TextBox guessTextBox;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.Label guessButtonLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}
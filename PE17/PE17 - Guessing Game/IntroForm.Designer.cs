namespace PE17___Guessing_Game
{
    partial class IntroForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.highTextBox = new System.Windows.Forms.TextBox();
            this.lowTextBox = new System.Windows.Forms.TextBox();
            this.lowNumLabel = new System.Windows.Forms.Label();
            this.highNumLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(267, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(157, 45);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // highTextBox
            // 
            this.highTextBox.Location = new System.Drawing.Point(132, 51);
            this.highTextBox.Name = "highTextBox";
            this.highTextBox.Size = new System.Drawing.Size(100, 20);
            this.highTextBox.TabIndex = 2;
            this.highTextBox.Text = "100";
            // 
            // lowTextBox
            // 
            this.lowTextBox.Location = new System.Drawing.Point(132, 12);
            this.lowTextBox.Name = "lowTextBox";
            this.lowTextBox.Size = new System.Drawing.Size(100, 20);
            this.lowTextBox.TabIndex = 3;
            this.lowTextBox.Text = "1";
            // 
            // lowNumLabel
            // 
            this.lowNumLabel.AutoSize = true;
            this.lowNumLabel.Location = new System.Drawing.Point(13, 15);
            this.lowNumLabel.Name = "lowNumLabel";
            this.lowNumLabel.Size = new System.Drawing.Size(103, 13);
            this.lowNumLabel.TabIndex = 4;
            this.lowNumLabel.Text = "Set Lowest Number:";
            this.lowNumLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // highNumLabel
            // 
            this.highNumLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.highNumLabel.AutoSize = true;
            this.highNumLabel.Location = new System.Drawing.Point(14, 51);
            this.highNumLabel.Name = "highNumLabel";
            this.highNumLabel.Size = new System.Drawing.Size(105, 13);
            this.highNumLabel.TabIndex = 5;
            this.highNumLabel.Text = "Set Highest Number:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 90);
            this.Controls.Add(this.highNumLabel);
            this.Controls.Add(this.lowNumLabel);
            this.Controls.Add(this.lowTextBox);
            this.Controls.Add(this.highTextBox);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox highTextBox;
        private System.Windows.Forms.TextBox lowTextBox;
        private System.Windows.Forms.Label lowNumLabel;
        private System.Windows.Forms.Label highNumLabel;
    }
}


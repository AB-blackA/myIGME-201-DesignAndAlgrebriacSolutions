namespace EditPerson
{
    partial class PersonEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonEditForm));
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.ageText = new System.Windows.Forms.TextBox();
            this.licLabel = new System.Windows.Forms.Label();
            this.licText = new System.Windows.Forms.TextBox();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.specText = new System.Windows.Forms.TextBox();
            this.gpaLabel = new System.Windows.Forms.Label();
            this.gpaText = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.himRadioButton = new System.Windows.Forms.RadioButton();
            this.herRadioButton = new System.Windows.Forms.RadioButton();
            this.themRadioButton = new System.Windows.Forms.RadioButton();
            this.freshRadioButton = new System.Windows.Forms.RadioButton();
            this.sophRadioButton = new System.Windows.Forms.RadioButton();
            this.juniorRadioButton = new System.Windows.Forms.RadioButton();
            this.seniorRadioButton = new System.Windows.Forms.RadioButton();
            this.genderGroupBox = new System.Windows.Forms.GroupBox();
            this.classGroupBox = new System.Windows.Forms.GroupBox();
            this.classOfLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.genderGroupBox.SuspendLayout();
            this.classGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.typeLabel.Location = new System.Drawing.Point(12, 25);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(93, 16);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "Person type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.typeComboBox.Location = new System.Drawing.Point(107, 22);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.typeComboBox.MaxDropDownItems = 2;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(157, 24);
            this.typeComboBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nameLabel.Location = new System.Drawing.Point(12, 68);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(93, 16);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // nameText
            // 
            this.nameText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameText.Location = new System.Drawing.Point(107, 65);
            this.nameText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(274, 26);
            this.nameText.TabIndex = 1;
            // 
            // emailLabel
            // 
            this.emailLabel.BackColor = System.Drawing.Color.Transparent;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailLabel.Location = new System.Drawing.Point(12, 113);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(93, 16);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email:";
            // 
            // emailText
            // 
            this.emailText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.emailText.Location = new System.Drawing.Point(107, 110);
            this.emailText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(468, 26);
            this.emailText.TabIndex = 2;
            // 
            // ageLabel
            // 
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ageLabel.Location = new System.Drawing.Point(12, 161);
            this.ageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(93, 16);
            this.ageLabel.TabIndex = 3;
            this.ageLabel.Text = "Age:";
            // 
            // ageText
            // 
            this.ageText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ageText.Location = new System.Drawing.Point(107, 158);
            this.ageText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(79, 26);
            this.ageText.TabIndex = 3;
            // 
            // licLabel
            // 
            this.licLabel.BackColor = System.Drawing.Color.Transparent;
            this.licLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.licLabel.Location = new System.Drawing.Point(12, 210);
            this.licLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.licLabel.Name = "licLabel";
            this.licLabel.Size = new System.Drawing.Size(93, 16);
            this.licLabel.TabIndex = 4;
            this.licLabel.Text = "License Id:";
            // 
            // licText
            // 
            this.licText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.licText.Location = new System.Drawing.Point(107, 208);
            this.licText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.licText.Name = "licText";
            this.licText.Size = new System.Drawing.Size(157, 26);
            this.licText.TabIndex = 4;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.BackColor = System.Drawing.Color.Transparent;
            this.specialtyLabel.Location = new System.Drawing.Point(12, 258);
            this.specialtyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(93, 16);
            this.specialtyLabel.TabIndex = 5;
            this.specialtyLabel.Text = "Specialty:";
            // 
            // specText
            // 
            this.specText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.specText.Location = new System.Drawing.Point(107, 255);
            this.specText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.specText.Name = "specText";
            this.specText.Size = new System.Drawing.Size(468, 26);
            this.specText.TabIndex = 5;
            // 
            // gpaLabel
            // 
            this.gpaLabel.BackColor = System.Drawing.Color.Transparent;
            this.gpaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpaLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gpaLabel.Location = new System.Drawing.Point(12, 258);
            this.gpaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(80, 16);
            this.gpaLabel.TabIndex = 6;
            this.gpaLabel.Text = "GPA:";
            // 
            // gpaText
            // 
            this.gpaText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpaText.Location = new System.Drawing.Point(107, 255);
            this.gpaText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpaText.Name = "gpaText";
            this.gpaText.Size = new System.Drawing.Size(79, 26);
            this.gpaText.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(375, 299);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 30);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(501, 299);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 30);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // himRadioButton
            // 
            this.himRadioButton.AutoSize = true;
            this.himRadioButton.Location = new System.Drawing.Point(8, 23);
            this.himRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.himRadioButton.Name = "himRadioButton";
            this.himRadioButton.Size = new System.Drawing.Size(51, 20);
            this.himRadioButton.TabIndex = 8;
            this.himRadioButton.TabStop = true;
            this.himRadioButton.Text = "Him";
            this.himRadioButton.UseVisualStyleBackColor = true;
            // 
            // herRadioButton
            // 
            this.herRadioButton.AutoSize = true;
            this.herRadioButton.Location = new System.Drawing.Point(8, 52);
            this.herRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.herRadioButton.Name = "herRadioButton";
            this.herRadioButton.Size = new System.Drawing.Size(49, 20);
            this.herRadioButton.TabIndex = 9;
            this.herRadioButton.TabStop = true;
            this.herRadioButton.Text = "Her";
            this.herRadioButton.UseVisualStyleBackColor = true;
            // 
            // themRadioButton
            // 
            this.themRadioButton.AutoSize = true;
            this.themRadioButton.Location = new System.Drawing.Point(8, 82);
            this.themRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.themRadioButton.Name = "themRadioButton";
            this.themRadioButton.Size = new System.Drawing.Size(57, 20);
            this.themRadioButton.TabIndex = 10;
            this.themRadioButton.TabStop = true;
            this.themRadioButton.Text = "They";
            this.themRadioButton.UseVisualStyleBackColor = true;
            // 
            // freshRadioButton
            // 
            this.freshRadioButton.AutoSize = true;
            this.freshRadioButton.Location = new System.Drawing.Point(8, 23);
            this.freshRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.freshRadioButton.Name = "freshRadioButton";
            this.freshRadioButton.Size = new System.Drawing.Size(89, 20);
            this.freshRadioButton.TabIndex = 11;
            this.freshRadioButton.TabStop = true;
            this.freshRadioButton.Text = "Freshman";
            this.freshRadioButton.UseVisualStyleBackColor = true;
            // 
            // sophRadioButton
            // 
            this.sophRadioButton.AutoSize = true;
            this.sophRadioButton.Location = new System.Drawing.Point(8, 55);
            this.sophRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sophRadioButton.Name = "sophRadioButton";
            this.sophRadioButton.Size = new System.Drawing.Size(91, 20);
            this.sophRadioButton.TabIndex = 12;
            this.sophRadioButton.TabStop = true;
            this.sophRadioButton.Text = "Sophmore";
            this.sophRadioButton.UseVisualStyleBackColor = true;
            // 
            // juniorRadioButton
            // 
            this.juniorRadioButton.AutoSize = true;
            this.juniorRadioButton.Location = new System.Drawing.Point(8, 90);
            this.juniorRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.juniorRadioButton.Name = "juniorRadioButton";
            this.juniorRadioButton.Size = new System.Drawing.Size(64, 20);
            this.juniorRadioButton.TabIndex = 13;
            this.juniorRadioButton.TabStop = true;
            this.juniorRadioButton.Text = "Junior";
            this.juniorRadioButton.UseVisualStyleBackColor = true;
            this.juniorRadioButton.CheckedChanged += new System.EventHandler(this.juniorRadioButton_CheckedChanged);
            // 
            // seniorRadioButton
            // 
            this.seniorRadioButton.AutoSize = true;
            this.seniorRadioButton.Location = new System.Drawing.Point(8, 124);
            this.seniorRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seniorRadioButton.Name = "seniorRadioButton";
            this.seniorRadioButton.Size = new System.Drawing.Size(66, 20);
            this.seniorRadioButton.TabIndex = 14;
            this.seniorRadioButton.TabStop = true;
            this.seniorRadioButton.Text = "Senior";
            this.seniorRadioButton.UseVisualStyleBackColor = true;
            this.seniorRadioButton.CheckedChanged += new System.EventHandler(this.seniorRadioButton_CheckedChanged);
            // 
            // genderGroupBox
            // 
            this.genderGroupBox.Controls.Add(this.himRadioButton);
            this.genderGroupBox.Controls.Add(this.herRadioButton);
            this.genderGroupBox.Controls.Add(this.themRadioButton);
            this.genderGroupBox.Location = new System.Drawing.Point(605, 65);
            this.genderGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.genderGroupBox.Name = "genderGroupBox";
            this.genderGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.genderGroupBox.Size = new System.Drawing.Size(120, 111);
            this.genderGroupBox.TabIndex = 6;
            this.genderGroupBox.TabStop = false;
            this.genderGroupBox.Text = "Gender";
            // 
            // classGroupBox
            // 
            this.classGroupBox.Controls.Add(this.classOfLabel);
            this.classGroupBox.Controls.Add(this.freshRadioButton);
            this.classGroupBox.Controls.Add(this.sophRadioButton);
            this.classGroupBox.Controls.Add(this.seniorRadioButton);
            this.classGroupBox.Controls.Add(this.juniorRadioButton);
            this.classGroupBox.Location = new System.Drawing.Point(768, 65);
            this.classGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.classGroupBox.Name = "classGroupBox";
            this.classGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.classGroupBox.Size = new System.Drawing.Size(206, 167);
            this.classGroupBox.TabIndex = 15;
            this.classGroupBox.TabStop = false;
            this.classGroupBox.Text = "Class";
            // 
            // classOfLabel
            // 
            this.classOfLabel.AutoSize = true;
            this.classOfLabel.Location = new System.Drawing.Point(44, 149);
            this.classOfLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.classOfLabel.Name = "classOfLabel";
            this.classOfLabel.Size = new System.Drawing.Size(101, 16);
            this.classOfLabel.TabIndex = 16;
            this.classOfLabel.Text = "Class of 9999";
            this.classOfLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(984, 258);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // PersonEditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(221)))), ((int)(((byte)(240)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1096, 535);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.classGroupBox);
            this.Controls.Add(this.genderGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gpaText);
            this.Controls.Add(this.specText);
            this.Controls.Add(this.specialtyLabel);
            this.Controls.Add(this.licText);
            this.Controls.Add(this.licLabel);
            this.Controls.Add(this.ageText);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.gpaLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(12)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1116, 578);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1116, 578);
            this.Name = "PersonEditForm";
            this.Text = "Edit Person";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.genderGroupBox.ResumeLayout(false);
            this.genderGroupBox.PerformLayout();
            this.classGroupBox.ResumeLayout(false);
            this.classGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox ageText;
        private System.Windows.Forms.Label licLabel;
        private System.Windows.Forms.TextBox licText;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox specText;
        private System.Windows.Forms.Label gpaLabel;
        private System.Windows.Forms.TextBox gpaText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton seniorRadioButton;
        private System.Windows.Forms.RadioButton juniorRadioButton;
        private System.Windows.Forms.RadioButton sophRadioButton;
        private System.Windows.Forms.RadioButton freshRadioButton;
        private System.Windows.Forms.RadioButton themRadioButton;
        private System.Windows.Forms.RadioButton herRadioButton;
        private System.Windows.Forms.RadioButton himRadioButton;
        private System.Windows.Forms.GroupBox classGroupBox;
        private System.Windows.Forms.GroupBox genderGroupBox;
        private System.Windows.Forms.Label classOfLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


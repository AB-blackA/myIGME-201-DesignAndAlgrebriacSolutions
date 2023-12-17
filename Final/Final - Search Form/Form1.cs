using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final___Search_Form
{
    public partial class Form1 : Form
    {

        const string DefaultSearchText = "Search for a Game!";


        public Form1()
        {
            InitializeComponent();
            this.searchGameButton.Click += new EventHandler(SearchButton__Click);
            this.comboBox1.SelectedIndex = 0;

            
        }

        private void SearchButton__Click(object sender, EventArgs e)
        {

            int s;

            try
            {
                s = Int32.Parse(this.searchGameTextBox.Text);
            }
            catch
            {
                return;
            }
            for(int i = s; i < 10; i++)
            {
                Label label = new Label();
                Label label2 = new Label();

                label.Text = i.ToString();
                label2.Text = (i * i).ToString();

                // Set AutoSize to true for labels
                label.AutoSize = true;
                label2.AutoSize = true;

                // Add labels to the TableLayoutPanel
                gameTableLayoutPanel.Controls.Add(label);
                gameTableLayoutPanel.Controls.Add(label2);

            }
        }

        private void RequestButton__Click(object sender, EventArgs e)
        {
            return;
        }

        
    }
}

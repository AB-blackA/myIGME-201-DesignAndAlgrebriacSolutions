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
        List<Game> games;
        List<Team> teams;

        public Form1()
        {
            InitializeComponent();
            this.searchGameButton.Click += new EventHandler(SearchButton__Click);
            this.comboBox1.SelectedIndex = 0;

            InstantiateGameList();

            
        }

        private void InstantiateGameList()
        {
            games = new List<Game>
            {
                new Game("Fortnite", new List<string> { "PC", "Nintendo Switch", "Xbox One", "Xbox Series X/S", "Playstation 5", "Playstation 4" }),
                new Game("Overwatch 2", new List<string> { "PC", "Nintendo Switch", "Xbox One", "Xbox Series X/S", "Playstation 5", "Playstation 4" }),
                new Game("Call of Duty Modern Warfare 3", new List<string> { "PC", "Xbox One", "Playstation 5", "Playstation 4" }),
                new Game("MineCraft", new List<string> { "PC", "Mac", "Linux", "Nintendo Switch", "Xbox One", "Xbox Series X/S", "Playstation 5", "Playstation 4" }),
                new Game("StarCraft 2", new List<string> {"PC", "Mac"})
                
            };
        }

        private void SearchButton__Click(object sender, EventArgs e)
        {
            foreach(Game g in games)
            {
                if (g.Name.Contains(searchGameTextBox.Text)
                {

                }
            }
            
        }

        private void RequestButton__Click(object sender, EventArgs e)
        {
            return;
        }

        
    }
}

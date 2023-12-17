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
        GameDatabase gameDB;
        TeamDatabase teamDB;
        Requester requester;
        Searcher searcher;

        public Form1()
        {
            InitializeComponent();
            this.searchGameButton.Click += new EventHandler(SearchButton__Click);
            this.comboBox1.SelectedIndex = 0;

            InstantiateGameList();
            CreateSearcher();

            
        }

        private void CreateSearcher()
        {
            searcher = new Searcher(this.requester, this.gameDB, this.teamDB);
        }

        private void InstantiateGameList()
        {
            gameDB = new GameDatabase();

            gameDB.AddGame(new Game("Fortnite", new List<string> { "PC", "Nintendo Switch", "Xbox One", "Xbox Series X/S", "Playstation 5", "Playstation 4" }));
            gameDB.AddGame(new Game("Overwatch 2", new List<string> { "PC", "Nintendo Switch", "Xbox One", "Xbox Series X/S", "Playstation 5", "Playstation 4" }));
            gameDB.AddGame(new Game("Call of Duty Modern Warfare 3", new List<string> { "PC", "Xbox One", "Playstation 5", "Playstation 4" }));
            gameDB.AddGame(new Game("MineCraft", new List<string> { "PC", "Mac", "Linux", "Nintendo Switch", "Xbox One", "Xbox Series X/S", "Playstation 5", "Playstation 4" }));
            gameDB.AddGame(new Game("StarCraft 2", new List<string> {"PC", "Mac"}));
                
        }

        private void SearchButton__Click(object sender, EventArgs e)
        {
            games = searcher.SearchGame(searchGameTextBox.Text);
            RichTextBox gameName;
            RichTextBox gamePlatforms;

            // Clear existing controls and reset properties
            gameTableLayoutPanel.Controls.Clear();
            gameTableLayoutPanel.RowStyles.Clear();  // Optionally clear row styles


            foreach (Game game in games)
            {
                gameName = new RichTextBox();
                gamePlatforms = new RichTextBox();

                gameName.Text = game.Name;

                foreach (string platform in game.Platforms)
                {

                    gamePlatforms.Text += platform + "\n";
                }

                gameName.Dock = DockStyle.Fill;
                gamePlatforms.Dock = DockStyle.Fill;


                gameTableLayoutPanel.Controls.Add(gameName);
                gameTableLayoutPanel.Controls.Add(gamePlatforms);

            }

            


        }

        private void RequestButton__Click(object sender, EventArgs e)
        {
            return;
        }

        
    }
}

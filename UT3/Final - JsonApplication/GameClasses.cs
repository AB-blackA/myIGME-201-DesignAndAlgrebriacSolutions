using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Author: Andrew Black, since 12/18/23
 * Purpose: Classes that uses JSON deserializing classes to load and save a player's data for a theoretically RPG.
 * Note that this is only for the purpose of using JSON and is not a real game. Per specs of IGME201 final.
 */
namespace Final___JsonApplication
{

    /* Class: Player
     * Purpose: class that contains player information
     */
    public class Player
    {
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public string[] Inventory { get; set; }
        public string LicenseKey { get; set; }
    }

    /* Class: SaveManager
     * Purpose: Allows loading and saving of Json file for a Player.
     */
    public class SaveManager
    {
        private static SaveManager instance;
        private static readonly object lockObject = new object();

        private SaveManager() { }

        public static SaveManager Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SaveManager();
                    }
                    return instance;
                }
            }
        }

        /* Method: SaveSettings
         * Purpose: saves the Player info to the json file
         */
        public void SaveSettings(Player settings, string filePath)
        {
            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(filePath, json);
        }

        /* Method: LoadSettings
         * Purpose: Loads the Player information from a json file
         */
        public Player LoadSettings(string filePath)
        {
            //provided there is a file, load it into a Player and return
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Player>(json);
            }
            else
            {
                //if the file doesn't exist, creates a new Player ("new game")
                return new Player();
            }
        }
    }
}

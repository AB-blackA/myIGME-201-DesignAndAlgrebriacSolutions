using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


/* Author: Andrew Black, since 12/18/23
 * Project - JsonGame
 * Purpose: Hold classes related to a Player and SaveManager to load/save Player data using json deserialization, per IGME201 Final specs
 */
namespace Final___JsonGame
{
    
    /* Class: Player
     * Purpose: Hold Player related Information
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
     * Purpose: Using Json, save or load Player info
     */
    public class SaveManager
    {
        private static SaveManager instance;
        private static readonly object lockObject = new object();

        /*Defaul constructor*/
        private SaveManager() { }

        /* Create an Instance of savemanager
         */
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
         * Purpose: Save Player settings to a filepath
         */
        public void SaveSettings(Player settings, string filePath)
        {
            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(filePath, json);
        }

        /* Method: LoadSettings
         * Purpose: Load Player data via a filepath
         */
        public Player LoadSettings(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Player>(json);
            }
            //if no filepath with a file, make a new player
            else
            {
                // If the file doesn't exist, return a new instance of PlayerSettings with default values.
                return new Player();
            }
        }
    }

    class Program
    {
        /* Method: main
         * Purpose: fiddle with class information for testing purposes
         */
        static void Main()
        {

            //specify the file path where the settings will be saved/loaded
            string filePath = "playerSettings.json";

            //create an instance of the Player class. used to generate default save information
            /*Player player = new Player
            {
                PlayerName = "dschuh",
                Level = 4,
                HP = 99,
                Inventory = new[]
                {
                "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball",
                "wood", "Scooby snack", "Hydra", "poisonous potato", "dead bush", "repair powder"
            },
                LicenseKey = "DFGU99-1454"
            };*/


            //use the singleton instance of SettingsManager to save and load player settings
            //SaveManager.Instance.SaveSettings(player, filePath);

            Player loadedSave = SaveManager.Instance.LoadSettings(filePath);

            //sisplay the loaded settings 
            Console.WriteLine($"Player Name: {loadedSave.PlayerName}");
            Console.WriteLine($"Level: {loadedSave.Level}");
            Console.WriteLine($"HP: {loadedSave.HP}");
            Console.WriteLine($"Inventory: {string.Join(", ", loadedSave.Inventory)}");
            Console.WriteLine($"License Key: {loadedSave.LicenseKey}");
        }
    }

}

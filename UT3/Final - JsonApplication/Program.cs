using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

/* Author: Andrew Black, since 12/18/23
 * Purpose: Program that uses JSON deserializing classes to load and save a player's data for a theoretically RPG.
 * Note that this is only for the purpose of using JSON and is not a real game. Per specs of IGME201 final.
 * Limitations: requires reference to GameClasses.cs
 */
namespace Final___JsonApplication
{

    
    class Program
    {
        /* Method: Main
         * Purpose: test features of Class's Player and SaveManager
         */
        static void Main()
        {
            //test code added in to create initial json file from speculations given
            /*Player playerSettings = new Player
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

            //filepath for save file
            string filePath = "playerSettings.json";

            //once again, test code to save the actual file
           /* SaveManager.Instance.SaveSettings(playerSettings, filePath);*/

            Player loadedSettings = SaveManager.Instance.LoadSettings(filePath);

            //display the loaded settings for testing
            Console.WriteLine($"Player Name: {loadedSettings.PlayerName}");
            Console.WriteLine($"Level: {loadedSettings.Level}");
            Console.WriteLine($"HP: {loadedSettings.HP}");
            Console.WriteLine($"Inventory: {string.Join(", ", loadedSettings.Inventory)}");
            Console.WriteLine($"License Key: {loadedSettings.LicenseKey}");
        }
    }

    


}

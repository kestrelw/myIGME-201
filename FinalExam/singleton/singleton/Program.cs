using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton
{
    // Singleton class for player settings
    public class PlayerSettings
    {
        private static PlayerSettings instance = new PlayerSettings();

        // Player settings properties
        public string player_name { get; set; }
        public int level { get; set; }
        public int hp { get; set; }
        public List<string> inventory { get; set; }
        public string license_key { get; set; }

        // Private constructor to prevent instantiation
        private PlayerSettings()
        {
            // Default settings
            player_name = "Unknown";
            level = 1;
            hp = 100;
            inventory = new List<string>();
            license_key = "";
        }

        // Public method to get the singleton instance
        public static PlayerSettings GetInstance()
        {
            return instance;
        }

        // Save player settings to a JSON file
        public void SaveSettings(string filePath)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Settings saved to file.");
        }

        // Load player settings from a JSON file
        public void LoadSettings(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                PlayerSettings loadedSettings = JsonConvert.DeserializeObject<PlayerSettings>(json);

                // Update settings from the loaded file
                player_name = loadedSettings.player_name;
                level = loadedSettings.level;
                hp = loadedSettings.hp;
                inventory = loadedSettings.inventory;
                license_key = loadedSettings.license_key;

                Console.WriteLine("Settings loaded from file.");
            }
            else
            {
                Console.WriteLine("File not found. Defaults used.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // File path for saving/loading settings
            string filePath = "player_settings.json";

            // Get the singleton instance
            PlayerSettings settings = PlayerSettings.GetInstance();


            // Modify settings
            settings.player_name = "dschuh";
            settings.level = 4;
            settings.hp = 99;
            settings.inventory = new List<string> { "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball", "wood", "Scooby snack", "Hydra", "poisonous potato", "dead bush", "repair powder" };
            settings.license_key = "DFGU99-1454";

            // Save modified settings
            settings.SaveSettings(filePath);

            // Load settings from file
            settings.LoadSettings(filePath);

        }
    }
}

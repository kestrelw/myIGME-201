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
        public string player_name;
        public int level;
        public int hp;
        public List<string> inventory;
        public string license_key;

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
                PlayerName = loadedSettings.PlayerName;
                Level = loadedSettings.Level;
                Hp = loadedSettings.Hp;
                Inventory = loadedSettings.Inventory;
                LicenseKey = loadedSettings.LicenseKey;

                Console.WriteLine("Settings loaded from file.");
            }
            else
            {
                Console.WriteLine("File not found. Default settings will be used.");
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
            PlayerSettings settings = PlayerSettings.Instance;

            // Display current settings
            //Console.WriteLine("Current Settings:");
            //Console.WriteLine($"Player Name: {settings.PlayerName}");
            //Console.WriteLine($"Level: {settings.Level}");
            //Console.WriteLine($"HP: {settings.Hp}");
            //Console.WriteLine($"Inventory: {string.Join(", ", settings.Inventory)}");
            //Console.WriteLine($"License Key: {settings.LicenseKey}");
            //Console.WriteLine();

            // Modify settings
            settings.PlayerName = "dschuh";
            settings.Level = 4;
            settings.Hp = 99;
            settings.Inventory = new List<string> { "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball", "wood", "Scooby snack", "Hydra", "poisonous potato", "dead bush", "repair powder" };
            settings.LicenseKey = "DFGU99-1454";

            // Save modified settings
            settings.SaveSettings(filePath);

            // Load settings from file
            settings.LoadSettings(filePath);

            // Display updated settings
            //Console.WriteLine("\nUpdated Settings:");
            //Console.WriteLine($"Player Name: {settings.PlayerName}");
            //Console.WriteLine($"Level: {settings.Level}");
            //Console.WriteLine($"HP: {settings.Hp}");
            //Console.WriteLine($"Inventory: {string.Join(", ", settings.Inventory)}");
            //Console.WriteLine($"License Key: {settings.LicenseKey}");
        }
    }
}

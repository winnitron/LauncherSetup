using System.IO;
using SimpleJSON;

namespace WinnitronSetup {

    class ApiKeyConfig {
        private string optionsFile;
        private JSONNode fullOptions;
        private string apiKey;

        public ApiKeyConfig(string dataDir) {
            optionsFile = Path.Combine(dataDir, "Options/winnitron_options.json");

            try {
                string json = File.ReadAllText(optionsFile);
                fullOptions = JSON.Parse(json);
                apiKey = fullOptions["sync"]["apiKey"];
            } catch (DirectoryNotFoundException e) {
                WConsole.Warn(e.Message);
                WConsole.WriteLine("\n");
            } catch (FileNotFoundException e) {
                WConsole.Warn(e.Message);
                WConsole.WriteLine("\n");
            }
        }

        public void ChooseAction() {
            WConsole.WriteLine("Options file is located at " + optionsFile + "\n");

            WConsole.WriteLine("Your Winnitron is currently using this API key:");
            WConsole.WriteLine("\n\t" + apiKey);

            WConsole.WriteLine("\nIf you don't have an API key yet, register your arcade machine at network.winnitron.com");

            WConsole.WriteLine("\n");

            WConsole.WriteLine(" (k) keep using this API key");
            WConsole.WriteLine(" (n) enter a new key");

            string choice = WConsole.Prompt();
            if (choice == "n") {
                apiKey = WConsole.Prompt(" new key");
            }

            Save();
        }

        private void Save() {
            fullOptions["sync"]["apiKey"] = new JSONString(apiKey);
            File.WriteAllText(optionsFile, fullOptions.ToString(2));
        }
    }
}
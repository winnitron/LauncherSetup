using System;
using System.IO;
using SimpleJSON;

namespace WinnitronSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            WConsole.WriteLine("********************************************************************************");
            WConsole.WriteLine(" WINNITRON LAUNCHER SETUP");
            WConsole.WriteLine("********************************************************************************\n\n");

            UserdataLocationConfig dataLoc = new UserdataLocationConfig();
            dataLoc.ChooseAction();

            // TODO:
            // ApiKeyConfig
        }
    }

    class UserdataLocationConfig {
        private string locFile = "Assets/Options/winnitron_userdata_path.json";
        private string defaultDataDir = "C:/WINNITRON_UserData";
        public string dataDir;

        public UserdataLocationConfig() {
            dataDir = defaultDataDir;

            try {
                string json = File.ReadAllText(locFile);
                dataDir = JSON.Parse(json)["userDataPath"];
            } catch (DirectoryNotFoundException e) {
                WConsole.Warn(e.Message);
                WConsole.WriteLine("\n");
            }
        }

        public void ChooseAction() {
            WConsole.WriteLine("The Winnitron User Data folder is currently configured to:");
            WConsole.WriteLine("\n\t" + dataDir);

            if (!File.Exists(dataDir)) {
                WConsole.Warn("This folder does not exist!");
            }

            WConsole.WriteLine("\n");

            WConsole.WriteLine(" (k) keep using this folder");
            WConsole.WriteLine(" (d) use default (" + defaultDataDir + ")");
            WConsole.WriteLine(" (n) enter a new path");

            string choice = WConsole.Prompt();
            if (choice == "d") {
                dataDir = defaultDataDir;
            } else if (choice == "n") {
                dataDir = WConsole.Prompt(" new path");
            }

            Save();
        }

        private void Save() {
            JSONObject json = new JSONObject();
            json.Add("userDataPath", dataDir);

            File.WriteAllText(json.ToString(2));
        }
    }
}

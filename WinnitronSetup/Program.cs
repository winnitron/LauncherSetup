using System;

namespace WinnitronSetup {

    class Program {

        static void Main(string[] args) {
            WConsole.WriteLine("********************************************************************************");
            WConsole.WriteLine(" WINNITRON LAUNCHER SETUP");
            WConsole.WriteLine("********************************************************************************\n\n");

            UserdataLocationConfig dataLoc = new UserdataLocationConfig();
            dataLoc.ChooseAction();

            ApiKeyConfig api = new ApiKeyConfig(dataLoc.dataDir);
            api.ChooseAction();

            WConsole.WriteLine("\n\n");
            WConsole.Congrats("All done!");
            WConsole.WriteLine("You can further configure your Winnitron by editing " + api.optionsFile);
        }
    }
}

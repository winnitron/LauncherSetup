using System;

namespace WinnitronSetup {

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
}

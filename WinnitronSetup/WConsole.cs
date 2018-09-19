using System;

namespace WinnitronSetup {

    public class WConsole {

        public static void WriteLine(string text) {
            Console.WriteLine(text);
        }

        public static void Warn(string msg) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\tWARNING: ");
            Console.ResetColor();
            Console.WriteLine(msg);
        }

        public static void Congrats(string msg) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static string Prompt(string txt = "") {
            Console.Write(txt + "> ");
            return Console.ReadLine().ToLower();
        }
    
    }
}

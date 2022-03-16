using System;

namespace Rasp_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileLogWriter fileLogWriter = new FileLogWriter();
            Pathfinder pathfinder1 = new(fileLogWriter);
            pathfinder1.Find("1");
            ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter();
            Pathfinder pathfinder2 = new(consoleLogWriter);
            pathfinder2.Find("2");
            FridayLogWriter fridayFileLogWriter = new FridayLogWriter(fileLogWriter);
            Pathfinder pathfinder3 = new(fridayFileLogWriter);
            pathfinder3.Find("3");
            FridayLogWriter fridayConsoleLogWriter = new FridayLogWriter(consoleLogWriter);
            Pathfinder pathfinder4 = new(fridayConsoleLogWriter);
            pathfinder4.Find("4");
            ConsoleLogWriter consolePlusFridayFileLogWriter = new ConsoleLogWriter(fridayFileLogWriter);
            Pathfinder pathfinder5 = new(consolePlusFridayFileLogWriter);
            pathfinder5.Find("5");
        }
    }
}

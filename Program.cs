namespace IJ_Rasp03_Logging
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FileLogWritter fileLogWritter = new FileLogWritter();
            Pathfinder pathfinder1 = new Pathfinder(fileLogWritter);
            pathfinder1.Find("1");
            ConsoleLogWritter consoleLogWritter = new ConsoleLogWritter();
            Pathfinder pathfinder2 = new Pathfinder(consoleLogWritter);
            pathfinder2.Find("2");
            FridayLogWritter fridayFileLogWritter = new FridayLogWritter(fileLogWritter);
            Pathfinder pathfinder3 = new Pathfinder(fridayFileLogWritter);
            pathfinder3.Find("3");
            FridayLogWritter fridayConsoleLogWritter = new FridayLogWritter(consoleLogWritter);
            Pathfinder pathfinder4 = new Pathfinder(fridayConsoleLogWritter);
            pathfinder4.Find("4");
            ConsoleLogWritter consolePlusFridayFileLogWriter = new ConsoleLogWritter(fridayFileLogWritter);
            Pathfinder pathfinder5 = new Pathfinder(consolePlusFridayFileLogWriter);
            pathfinder5.Find("5");
        }
    }
}

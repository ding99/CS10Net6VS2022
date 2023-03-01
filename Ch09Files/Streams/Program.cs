using System.Xml;

using static System.Console;
using static System.Environment;
using static System.IO.Path;

ForegroundColor = ConsoleColor.Yellow; WorkWithText ();




ResetColor ();

static void WorkWithText ()
{
    string textFile = Combine (CurrentDirectory, "streams.txt");
    StreamWriter text = File.CreateText (textFile);
    foreach(string item in Viper.Callsigns)
        text.WriteLine (item);
    text.Close ();
    WriteLine ("{0} contains {1:N0} bytes.", arg0:textFile, arg1:new FileInfo(textFile).Length);
    WriteLine (File.ReadAllText (textFile));
}

static class Viper
{
    public static string[] Callsigns = new[]
    {
        "Husker",
        "Starbuck",
        "Apollo",
        "Boomer",
        "Bulldog",
        "Athena",
        "Helo",
        "Racetrack"
    };
}
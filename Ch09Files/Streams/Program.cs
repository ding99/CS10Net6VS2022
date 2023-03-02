using System.Xml;

using static System.Console;
using static System.Environment;
using static System.IO.Path;

ForegroundColor = ConsoleColor.Yellow; WorkWithText ();
ForegroundColor = ConsoleColor.Cyan; WorkWithXml ();

ResetColor ();

static void WorkWithText ()
{
    string textFile = Combine (CurrentDirectory, "streams.txt");
    StreamWriter text = File.CreateText (textFile);
    foreach(string item in Viper.Callsigns)
        text.Write ($" {item}");
    text.WriteLine ();
    text.Close ();
    WriteLine ("{0} contains {1:N0} bytes.", arg0:textFile, arg1:new FileInfo(textFile).Length);
    WriteLine (File.ReadAllText (textFile));
}

static void WorkWithXml ()
{
    FileStream? xmlFileStream = null;
    XmlWriter? xml = null;

    try
    {
        string xmlFile = Combine (CurrentDirectory, "streams.xml");
        xmlFileStream = File.Create (xmlFile);
        xml = XmlWriter.Create (xmlFileStream, new XmlWriterSettings { Indent = true });
        xml.WriteStartDocument ();
        xml.WriteStartElement ("callsigns");
        foreach (string item in Viper.Callsigns)
            xml.WriteElementString ("callsign", item);
        xml.WriteEndElement ();
        xml.Close ();
        xmlFileStream.Close ();
        WriteLine ("{0} contains {1:N0} bytes.", arg0: xmlFile, arg1: new FileInfo (xmlFile).Length);
        WriteLine (File.ReadAllText (xmlFile));
    }
    catch (Exception ex)
    {
        WriteLine ($"{ex.GetType ()} says {ex.Message}");
    }
    finally
    {
        if(xml != null)
        {
            xml.Dispose ();
            WriteLine ("The XML writer's unmanaged resources have been disposed.");
            if(xmlFileStream != null)
            {
                xmlFileStream.Dispose ();
                WriteLine ("The file stream's unmanaged resources have been disposed.");
            }
        }
    }
}

static class Viper
{
    public static string[] Callsigns = new[]
    {
        "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack"
    };
}
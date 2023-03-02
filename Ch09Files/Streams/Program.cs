using System.Xml;
using System.IO.Compression; // BrotliStream, GZipStream, CompressionMode

using static System.Console;
using static System.Environment;
using static System.IO.Path;

ForegroundColor = ConsoleColor.Yellow; WorkWithText ();
ForegroundColor = ConsoleColor.Cyan; WorkWithXml ();
ForegroundColor = ConsoleColor.DarkYellow; WorkWithXmlUsing ();
ForegroundColor = ConsoleColor.Green; WorkWithCompression ();
ForegroundColor = ConsoleColor.Yellow; WorkWithCompression (false);

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
        string xmlFile = Combine (CurrentDirectory, "streamsUsing.xml");
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

static void WorkWithXmlUsing ()
{
    string fileExt = "xml";
    string xmlFile = Combine (CurrentDirectory, $"streams.{fileExt}");

    using FileStream xmlFileStream = File.Create (xmlFile);
    using XmlWriter xml = XmlWriter.Create (xmlFileStream, new XmlWriterSettings { Indent = true });
    try
    {
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
}

static void WorkWithCompression (bool useBrotli = true)
{
    string fileExt = useBrotli ? "brotli" : "gzip";
    string filePath = Combine (CurrentDirectory, $"stream.{fileExt}");

    FileStream file = File.Create (filePath);

    Stream compressor;
    if (useBrotli)
        compressor = new BrotliStream (file, CompressionMode.Compress);
    else
        compressor = new GZipStream (file, CompressionMode.Compress);

    using (compressor)
    {
        using XmlWriter xml = XmlWriter.Create (compressor);
        xml.WriteStartDocument ();
        xml.WriteStartElement ("callsigns");
        foreach (string item in Viper.Callsigns)
            xml.WriteElementString ("callsign", item);
        xml.WriteEndElement ();
        xml.Close ();
        compressor.Close ();
        file.Close ();
    }
    WriteLine ("{0} contains {1:N0} bytes.", filePath, new FileInfo (filePath).Length);
    WriteLine ($"The compressed contents:");
    WriteLine (File.ReadAllText (filePath));

    WriteLine ("-- Reading the compressed XML file:");
    file = File.Open (filePath, FileMode.Open);
    Stream decompressor;
    if (useBrotli)
        decompressor = new BrotliStream (file, CompressionMode.Decompress);
    else
        decompressor = new GZipStream (file, CompressionMode.Decompress);

    using (decompressor)
    {
        using XmlReader reader = XmlReader.Create (decompressor);
        while (reader.Read ())
        {
            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
            {
                reader.Read ();
                WriteLine ($"{reader.Value}");
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

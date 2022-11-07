using System.Diagnostics;

Trace.Listeners.Add(new TextWriterTraceListener(
    File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt"))));
Trace.AutoFlush = true;

Debug.WriteLine("Debug says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");

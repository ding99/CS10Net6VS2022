using static System.Console;

ForegroundColor = ConsoleColor.Yellow;
WriteLine("I can run everywhere!");
WriteLine($"OS Version is {Environment.OSVersion}");
if(OperatingSystem.IsMacOS())
    WriteLine("I am macOS.");
else if(OperatingSystem.IsWindowsVersionAtLeast(major: 10))
    WriteLine("I am Windows 10 or 11.");
else
    WriteLine("I am some other mysterious OS.");

ResetColor();

/***
 dotnet publish -c Release -r win10-x64
 dotnet publish -c Release -r linux-x64
 ***/

﻿using static System.Console;
WriteLine($"There are {args.Length} arguments.");
foreach(string arg in args) {
    WriteLine(arg);
}

if (args.Length < 3) {
    WriteLine("You mush specify two colors and cursor size, e.g.");
    WriteLine("dotnet run red yellow 50");
    return;
}
ForegroundColor = (ConsoleColor)Enum.Parse(
    enumType:typeof(ConsoleColor),
    value:args[0],
    ignoreCase:true);
BackgroundColor = (ConsoleColor)Enum.Parse(
    enumType: typeof(ConsoleColor),
    value: args[1],
    ignoreCase: true);
try {
    CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException) {
    WriteLine("The current platform does not support changing the size of the cursor.");
}

if (OperatingSystem.IsWindows()) {
    WriteLine("This is Windows.");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10)) {
    WriteLine("This is Windows 10 or later.");
}


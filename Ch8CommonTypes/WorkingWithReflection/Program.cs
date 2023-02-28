using System.Reflection;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

WriteLine("Assembly metadata:");

Assembly? asm = Assembly.GetEntryAssembly();
if(asm is null)
{
    WriteLine("Failed to get entry assembly.");
    return;
}

WriteLine($" Full name: {asm.FullName}");
WriteLine($" Location: {asm.Location}");
IEnumerable<Attribute> attrs = asm.GetCustomAttributes();
WriteLine($" Assembly-level attributes:");
foreach(Attribute a in attrs)
    WriteLine($" {a.GetType()}");

ForegroundColor = ConsoleColor.Cyan;

AssemblyInformationalVersionAttribute? ver = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
WriteLine($" Version: {ver?.InformationalVersion}");

AssemblyCompanyAttribute? company = asm.GetCustomAttribute<AssemblyCompanyAttribute>();
WriteLine($" Company: {company?.Company}");

ResetColor();

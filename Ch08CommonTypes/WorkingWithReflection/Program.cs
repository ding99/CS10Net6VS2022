using System.Reflection;
using Packt.Shared;

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

ForegroundColor = ConsoleColor.DarkYellow;

WriteLine();
WriteLine($"* Types:");
Type[] types = asm.GetTypes();
foreach(Type t in types)
{
    WriteLine();
    WriteLine($"Type: {t.FullName}");
    MemberInfo[] members = t.GetMembers();
    foreach(MemberInfo m in members)
    {
        WriteLine("{0}: {1} {2}",
            arg0:m.MemberType,
            arg1:m.Name,
            arg2:m.DeclaringType?.Name);

        IOrderedEnumerable<CoderAttribute> coders = m.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);
        foreach(CoderAttribute coder in coders)
            WriteLine("-> Modified by {0} on {1}",
                coder.Coder, coder.LastModified.ToShortTimeString());
    }

}

ResetColor();


class Animal
{
    [Coder("Mark Price", "22 August 2021")]
    [Coder("Johnni Rasmussen", "13 September 2021")]
    public void Speak()
    {
        WriteLine("Woof...");
    }
}

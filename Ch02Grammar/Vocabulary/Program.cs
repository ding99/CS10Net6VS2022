using System.Reflection;
System.Data.DataSet ds;
HttpClient client;

Console.WriteLine("== Start Chapter 2.");

Assembly? assembly = Assembly.GetEntryAssembly();
if(assembly == null) return;

Console.WriteLine($"Reference Assemblies ({assembly.GetReferencedAssemblies().Length})");

foreach (AssemblyName name in assembly.GetReferencedAssemblies()) {

    Assembly a = Assembly.Load(name);

    int methodCount = 0;
    foreach (TypeInfo t in a.DefinedTypes) {
        methodCount += t.GetMethods().Length;
    }

    Console.WriteLine(
        "- {0:N0} types with {1:N0} methods in {2} assembly.",
        arg0: a.DefinedTypes.Count(),
        arg1: methodCount,
        arg2: name.Name
        );
}

ICal cal1 = new Cal();
Cal cal2 = new();
Console.WriteLine($"type of {nameof(cal1)} : {cal1.GetType()}");
Console.WriteLine($"type of {nameof(cal2)} : {cal2.GetType()}");
Console.WriteLine($"type of Cal  : {typeof(Cal)}");
Console.WriteLine($"{nameof(cal1)} == Cal? : {cal1.GetType() == typeof(Cal)}");
Console.WriteLine($"type of ICal : {typeof(ICal)}");

Console.ResetColor();
Console.WriteLine("== End Chapter 2.");

interface ICal {
    int Add(int x, int y);
}

public class Cal : ICal {
    public int Add(int x, int y) {
        return x + y;
    }
}

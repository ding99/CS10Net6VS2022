using System.Reflection;
System.Data.DataSet ds;
HttpClient client;

Console.WriteLine("== Start Chapter 2.");

Assembly? assembly = Assembly.GetEntryAssembly();
if(assembly == null) return;

Console.WriteLine($"Reference Assemblies ({assembly.GetReferencedAssemblies().Length})");

foreach(AssemblyName name in assembly.GetReferencedAssemblies()) {

    Assembly a = Assembly.Load(name);

    int methodCount = 0;
    foreach(TypeInfo t in a.DefinedTypes) {
        methodCount += t.GetMethods().Length;
    }

    Console.WriteLine(
        "- {0:N0} types with {1:N0} methods in {2} assembly.",
        arg0:a.DefinedTypes.Count(),
        arg1:methodCount,
        arg2:name.Name
        );
}

Console.ResetColor();
Console.WriteLine("== End Chapter 2.");

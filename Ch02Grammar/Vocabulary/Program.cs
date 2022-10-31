using System.Reflection;
System.Data.DataSet ds;
HttpClient client;

Console.WriteLine("== Start Chapter 2.");

Console.ForegroundColor = ConsoleColor.Green;

Assembly? assembly = Assembly.GetEntryAssembly();
if(assembly == null) return;

Console.WriteLine($"Reference Assemblies ({assembly.GetReferencedAssemblies().Length})");

foreach (AssemblyName name in assembly.GetReferencedAssemblies()) {

    Assembly aa = Assembly.Load(name);

    int methodCount = 0;
    foreach (TypeInfo t in aa.DefinedTypes) {
        methodCount += t.GetMethods().Length;
    }

    Console.WriteLine(
        "- {0:N0} types with {1:N0} methods in {2} assembly.",
        arg0: aa.DefinedTypes.Count(),
        arg1: methodCount,
        arg2: name.Name
        );
}

Console.ForegroundColor = ConsoleColor.Yellow;

ICal cal1 = new Cal();
Cal cal2 = new();
Console.WriteLine($"type of {nameof(cal1)} : {cal1.GetType()}");
Console.WriteLine($"type of {nameof(cal2)} : {cal2.GetType()}");
Console.WriteLine($"type of Cal  : {typeof(Cal)}");
Console.WriteLine($"{nameof(cal1)} == Cal? : {cal1.GetType() == typeof(Cal)}");
Console.WriteLine($"type of ICal : {typeof(ICal)}");

Console.ForegroundColor = ConsoleColor.Cyan;

object origObject = new object();
string origString = "abc";
object fromString = origString;
object strAsObj = origString as object;
int origInt = 5;
object fromInt = origInt;
object intasObj = origInt as object;
Console.WriteLine($"type of {nameof(origObject)} : {origObject.GetType()}");
Console.WriteLine($"type of {nameof(origString)} : {origString.GetType()}");
Console.WriteLine($"type of {nameof(fromString)} : {fromString.GetType()}");
Console.WriteLine($"type of {nameof(strAsObj)} : {strAsObj.GetType()}");
Console.WriteLine($"type of {nameof(origInt)} : {origInt.GetType()}");
Console.WriteLine($"type of {nameof(fromInt)} : {fromInt.GetType()}");
Console.WriteLine($"type of {nameof(intasObj)} : {intasObj.GetType()}");

Console.ForegroundColor = ConsoleColor.Red;

int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;
Console.WriteLine($"decimalNotion eqauls to binaryNotion: {decimalNotation == binaryNotation}");
Console.WriteLine($"decimalNotion eqauls to hexadecimalNotation: {decimalNotation == hexadecimalNotation}");

Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}");
Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}");
Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}");

Console.ForegroundColor = ConsoleColor.Cyan;

Console.WriteLine("Using doubles");
double a = 0.1, b = 0.2;
if (a + b == 0.3) Console.WriteLine($"{a} + {b} equals {0.3}");
else Console.WriteLine($"{a} + {b} does NOT equal {0.3}");

Console.WriteLine("Using decimals");
decimal c = 0.1M, d = 0.2M;
if (c + d == 0.3M) Console.WriteLine($"{c} + {d} equals {0.3M}");
else Console.WriteLine($"{c} + {d} does NOT equal {0.3M}");

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine($"Version: {Environment.Version}");

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

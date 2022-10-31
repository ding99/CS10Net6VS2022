int a = 10;
int b = 6;

Console.WriteLine($"a = {a} / {ToBinaryString(a)}");
Console.WriteLine($"b = {b} / {ToBinaryString(b)}");
Console.WriteLine($"a << 3 = {a << 3} / {ToBinaryString(a << 3)}");

Console.WriteLine($"a & b = {a & b} / {ToBinaryString(a & b)}");
Console.WriteLine($"a | b = {a | b} / {ToBinaryString(a | b)}");
Console.WriteLine($"a ^ b = {a ^ b} / {ToBinaryString(a ^ b)}");

Console.WriteLine($"name of a : {nameof(a)}");

int age = 47;
char firstDigit = age.ToString()[0];
Console.WriteLine($"age {age}, first digit {firstDigit}");

static string ToBinaryString(int value) {
    return Convert.ToString(value, toBase:2).PadLeft(8, '0');
}
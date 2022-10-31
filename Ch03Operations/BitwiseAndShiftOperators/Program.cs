int a = 10;
int b = 6;

Console.WriteLine($"a = {a} / {ToBinaryString(a)}");
Console.WriteLine($"a << 3 = {a << 3} / {ToBinaryString(a << 3)}");

static string ToBinaryString(int value) {
    return Convert.ToString(value, toBase:2).PadLeft(8, '0');
}
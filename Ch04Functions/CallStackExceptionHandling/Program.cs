using Packt;

Console.WriteLine("In Main");

Alpha();

static void Alpha() {
    Console.WriteLine("In Alpha");
    Beta();
}

static void Beta() {
    Console.WriteLine("In Beta");
    Calculator.Gamma();
}
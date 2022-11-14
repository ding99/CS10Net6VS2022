using Packt;

Console.WriteLine("In Main");

Alpha();

static void Alpha() {
    Console.WriteLine("In Alpha");
    Beta();
}

static void Beta() {
    Console.WriteLine("In Beta");
    try {
        Calculator.Gamma();
    }
    catch (Exception ex) {
        Console.WriteLine($"Caught this: {ex.Message}");
//        throw ex;
        throw;
    }
}
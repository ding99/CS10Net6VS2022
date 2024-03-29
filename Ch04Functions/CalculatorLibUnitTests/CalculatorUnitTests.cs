using Packt;

namespace CalculatorLibUnitTests;

public class CalculatorUnitTests {
    [Fact]
    public void TestAdding2And2() {
        double a = 2, b = 2;
        double expected = 4;
        Calculator calc = new();

        double actual = calc.Add(a, b);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAdding2And3() {
        double a = 2, b = 3;
        double expected = 5;
        Calculator calc = new();

        double actual = calc.Add(a, b);

        Assert.Equal(expected, actual);
    }
}
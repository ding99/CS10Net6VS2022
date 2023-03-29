using static System.Console;

Doer.DoSomething();
public interface IWithStaticAbstract
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2252:This API requires opting into preview features", Justification = "<Pending>")]
    static abstract void DoSomething();
}
public class Doer : IWithStaticAbstract
{
    public static void DoSomething()
    {
        WriteLine("I am an implementation of a static abstract method.");
    }
}

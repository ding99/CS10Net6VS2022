namespace Packt.Shared
{
    public partial class Person
    {
        public void ShowPartial()
        {
            System.Console.WriteLine("PersonAutoGen file");
        }

        public string Origin
        {
            get {
                return $"{Name} was born on {HomePlanet}";
            }
        }

        public string Greeting => $"{Name} says 'Hello!'";

        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;
    }
}

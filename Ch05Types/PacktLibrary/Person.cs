using System;
using System.Collections.Generic;

namespace Packt.Shared {
    public class Person : object
    {
        public const string Species = "Homo Sapien";

        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;

        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;

        public List<Person> Children = new List<Person>();

        public Person()
        {
            this.Name = "Unknown";
            this.Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            this.Name = initialName;
            this.HomePlanet = homePlanet;
            this.Instantiated = DateTime.Now;
        }

        public void Deconstruct(out string name, out DateTime dob)
        {
            name = this.Name;
            dob = this.DateOfBirth;
        }

        public void Deconstruct(out string name, out DateTime dob, out WondersOfTheAncientWorld fav)
        {
            name = this.Name;
            dob = this.DateOfBirth;
            fav = this.FavoriteAncientWonder;
        }

        #region methods

        public void WriteToConsole()
        {
            Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public string GetOrigin()
        {
            return $"{this.Name} was born on {HomePlanet}.";
        }

        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }

        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Apples", Number: 5);
        }

        #region parameters

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }

        public string OptionalParameters(
            string command = "Run!",
            double number = 0.0,
            bool active = true)
        {
            return string.Format(
                format: "command is {0}, number is {1}, active is {2}",
                arg0: command,
                arg1: number,
                arg2: active);
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            z = 99;
            x++;
            y++;
            z++;
        }

        #endregion

        #endregion
    }
}

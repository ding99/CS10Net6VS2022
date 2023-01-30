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
    }
}

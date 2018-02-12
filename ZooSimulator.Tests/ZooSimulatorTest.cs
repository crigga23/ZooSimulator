using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZooSimulator.Tests
{
    [TestClass]
    public class ZooSimulatorTest
    {
        [TestMethod]
        public void Zoo__TakesOneMonkey_ReturnsOneMonkey()
        {
            // arrange 
            List<Animal> animals = new List<Animal>() {
                new Animal() { Type = AnimalType.Monkey }
            };

            Zoo zoo = new Zoo(animals);

            // assert
            Assert.AreEqual(1, zoo.animals.Count());
            Assert.IsTrue(zoo.animals.FirstOrDefault().Type == AnimalType.Monkey);
        }

        [TestMethod]
        public void Zoo__TakesOneGiraffe_ReturnsOneGiraffe()
        {
            // arrange 
            List<Animal> animals = new List<Animal>() {
                new Animal() { Type = AnimalType.Giraffe }
            };

            Zoo zoo = new Zoo(animals);

            // assert
            Assert.AreEqual(1, zoo.animals.Count());
            Assert.IsTrue(zoo.animals.FirstOrDefault().Type == AnimalType.Giraffe);
        }

        [TestMethod]
        public void Zoo__TakesOneElephant_ReturnsOneElephant()
        {
            // arrange 
            List<Animal> animals = new List<Animal>() {
                new Animal() { Type = AnimalType.Elephant }
            };

            Zoo zoo = new Zoo(animals);

            // assert
            Assert.AreEqual(1, zoo.animals.Count());
            Assert.IsTrue(zoo.animals.FirstOrDefault().Type == AnimalType.Elephant);
        }

        [TestMethod]
        public void Zoo_TakesFifteenAnimals_ReturnsFifteenAnimals()
        {

            // arrange
            List<Animal> animals = new List<Animal>();
            for (var i = 0; i < 5; i++)
            {
                animals.Add(new Animal { Type = AnimalType.Monkey });
                animals.Add(new Animal { Type = AnimalType.Giraffe });
                animals.Add(new Animal { Type = AnimalType.Elephant });
            }

            // act
            Zoo zoo = new Zoo(animals);

            // assert
            Assert.AreEqual(15, zoo.animals.Count());
            Assert.AreEqual(5, zoo.animals.Count(a => a.Type == AnimalType.Monkey));
            Assert.AreEqual(5, zoo.animals.Count(a => a.Type == AnimalType.Giraffe));
            Assert.AreEqual(5, zoo.animals.Count(a => a.Type == AnimalType.Elephant));
        }

        [TestMethod]
        public void Zoo_WhenAnimalCreated_ItShouldHave100PercentHealth()
        {

            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            Zoo zoo = new Zoo(animals);

            // assert
            Assert.AreEqual(100.00, zoo.animals.FirstOrDefault().Health);
        }

        [TestMethod]
        public void Zoo_WhenOneOfEachAnimalCreated_TheyShouldAllHave100PercentHealth()
        {

            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });
            animals.Add(new Animal { Type = AnimalType.Giraffe });
            animals.Add(new Animal { Type = AnimalType.Elephant });

            // act
            Zoo zoo = new Zoo(animals);

            // assert
            Assert.AreEqual(100, zoo.animals.FirstOrDefault(m => m.Type == AnimalType.Monkey).Health);
            Assert.AreEqual(100, zoo.animals.FirstOrDefault(g => g.Type == AnimalType.Giraffe).Health);
            Assert.AreEqual(100, zoo.animals.FirstOrDefault(e => e.Type == AnimalType.Elephant).Health);
        }

        // rate is 1hr every 20 seconds
        // TODO: Add some rate of flow of time tests
    }

    public class Zoo
    {
        public List<Animal> animals { get; set; }

        public Zoo(List<Animal> animals)
        {
            this.animals = animals;
        }
    }

    public enum AnimalType
    {
        Monkey,
        Giraffe,
        Elephant
    }

    public class Animal
    {
        public AnimalType Type { get; internal set; }

        private float health;
        public float Health
        {
            get
            {
                return health;
            }
        }

        public Animal()
        {
            health = 100;
        }
    }
}

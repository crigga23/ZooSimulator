using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

namespace ZooSimulator.Tests
{
    [TestClass]
    public class ZooSimulatorTest
    {
        // TODO: Probably looking at a IHealth, IWalkable and abstract class for Animal!!!
        // TODO: Zoo should feed rather than animal
        // TODO: Timer test to check reduce health is called ??? Not sure about this one now!!!
        // TODO: #### FEED #### random between 10 and 25
        

        [TestMethod]
        public void Zoo_TakesOneMonkey_ReturnsOneMonkey()
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
        public void Zoo_TakesOneGiraffe_ReturnsOneGiraffe()
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
        public void Zoo_TakesOneElephant_ReturnsOneElephant()
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

        [TestMethod]
        public void ReduceHealth_WhenHealthIs100AndReducedBy0Percent_ReturnsHealthOf100Percent()
        {
            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            var healthReductionInPercent = 0;
            Zoo zoo = new Zoo(animals);
            zoo.animals.FirstOrDefault().ReduceHealth(healthReductionInPercent);
            // assert
            Assert.AreEqual(100, zoo.animals.FirstOrDefault().Health);
        }

        [TestMethod]
        public void ReduceHealth_WhenHealthIs100AndReducedBy10Percent_ReturnsHealthOf90Percent()
        {
            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            var healthReductionInPercent = 10;
            Zoo zoo = new Zoo(animals);
            zoo.animals.FirstOrDefault().ReduceHealth(healthReductionInPercent);
            // assert
            Assert.AreEqual(90, zoo.animals.FirstOrDefault().Health);
        }

        [TestMethod]
        public void ReduceHealth_WhenHealthIs100AndReducedBy20Percent_ReturnsHealthOf80Percent()
        {
            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            var healthReductionInPercent = 20;
            Zoo zoo = new Zoo(animals);
            zoo.animals.FirstOrDefault().ReduceHealth(healthReductionInPercent);
            // assert
            Assert.AreEqual(80, zoo.animals.FirstOrDefault().Health);
        }

        [TestMethod]
        public void ReduceHealth_WhenHealthIs10AndReducedBy20Percent_ReturnsHealthOf8Percent()
        {
            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            var healthReductionInPercent = 20;
            Zoo zoo = new Zoo(animals);
            zoo.animals.FirstOrDefault().Health = 10;
            zoo.animals.FirstOrDefault().ReduceHealth(healthReductionInPercent);
            // assert
            Assert.AreEqual(8, zoo.animals.FirstOrDefault().Health);
        }

        [TestMethod]
        
        public void ReduceHealth_WhenInputIsLessThanZero_ReturnsArgumentOutOfRangeException()
        {
            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            var healthReductionInPercent = -1;
            Zoo zoo = new Zoo(animals);
            // assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => zoo.animals.FirstOrDefault().ReduceHealth(healthReductionInPercent));
        }

        [TestMethod]

        public void ReduceHealth_WhenInputIsGreaterThanTwenty_ReturnsArgumentOutOfRangeException()
        {
            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            var healthReductionInPercent = 21;
            Zoo zoo = new Zoo(animals);
            // assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => zoo.animals.FirstOrDefault().ReduceHealth(healthReductionInPercent));
        }

        [TestMethod]

        public void ReduceHealth_ReduceHealthForMultipleAnimals_ReturnsReductionInHealthForEachAnimal()
        {
            // arrange
            List<Animal> animals = new List<Animal>();

            animals.Add(new Animal { Type = AnimalType.Monkey });
            animals.Add(new Animal { Type = AnimalType.Giraffe });
            animals.Add(new Animal { Type = AnimalType.Elephant });

            // generate a list of random numbers - list equal to the size of animals
            var randomNumberGenerator = new Random();
            List<double> randomNumbers = new List<double>(animals.Count);
            for (var animalIndex = 0; animalIndex < animals.Count; animalIndex++)
            {
                randomNumbers.Add(randomNumberGenerator.NextDouble() * 20);
            }

            // act
            Zoo zoo = new Zoo(animals);

            // loop thru the animals list and call reducehealth for each animal
            for (var animalIndex = 0; animalIndex < animals.Count; animalIndex++)
            {
                var reductionPercentage = randomNumbers[animalIndex];
                animals[animalIndex].ReduceHealth(reductionPercentage);
            }

            // assert
            double denominator = 100;
            double expected1 = (randomNumbers[0] / denominator) * 100;
            double expected2 = (randomNumbers[1] / denominator) * 100;
            double expected3 = (randomNumbers[2] / denominator) * 100;

            Assert.AreEqual(expected1, 100 - zoo.animals[0].Health, 0.0001);
            Assert.AreEqual(expected2, 100 - zoo.animals[1].Health, 0.0001);
            Assert.AreEqual(expected3, 100 - zoo.animals[2].Health, 0.0001);
        }

        [TestMethod]
        public void ReduceHealth_ReduceHealthForAllAnimals_ReturnsReductionInHealthForEachAnimal()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            for (var i = 0; i < 5; i++)
            {
                animals.Add(new Animal { Type = AnimalType.Monkey });
                animals.Add(new Animal { Type = AnimalType.Giraffe });
                animals.Add(new Animal { Type = AnimalType.Elephant });
            }

            // generate a list of random numbers - list equal to the size of animals
            var randomNumberGenerator = new Random();
            List<double> randomNumbers = new List<double>(animals.Count);
            for (var animalIndex = 0; animalIndex < animals.Count; animalIndex++)
            {   
                randomNumbers.Add(randomNumberGenerator.NextDouble() * 20);
            }

            // act
            Zoo zoo = new Zoo(animals);

            // loop thru the animals list and call reducehealth for each animal
            for (var animalIndex = 0; animalIndex < animals.Count; animalIndex++)
            {
                var reductionPercentage = randomNumbers[animalIndex];
                animals[animalIndex].ReduceHealth(reductionPercentage);
            }

            // assert
            double denominator = 100;
            double expected1 = (randomNumbers[0] / denominator) * 100;
            double expected2 = (randomNumbers[1] / denominator) * 100;
            double expected3 = (randomNumbers[2] / denominator) * 100;
            double expected4 = (randomNumbers[3] / denominator) * 100;
            double expected5 = (randomNumbers[4] / denominator) * 100;
            double expected6 = (randomNumbers[5] / denominator) * 100;
            double expected7 = (randomNumbers[6] / denominator) * 100;
            double expected8 = (randomNumbers[7] / denominator) * 100;
            double expected9 = (randomNumbers[8] / denominator) * 100;
            double expected10 = (randomNumbers[9] / denominator) * 100;
            double expected11 = (randomNumbers[10] / denominator) * 100;
            double expected12 = (randomNumbers[11] / denominator) * 100;
            double expected13 = (randomNumbers[12] / denominator) * 100;
            double expected14 = (randomNumbers[13] / denominator) * 100;
            double expected15 = (randomNumbers[14] / denominator) * 100;

            Assert.AreEqual(expected1, 100 - zoo.animals[0].Health, 0.0001);
            Assert.AreEqual(expected2, 100 - zoo.animals[1].Health, 0.0001);
            Assert.AreEqual(expected3, 100 - zoo.animals[2].Health, 0.0001);
            Assert.AreEqual(expected4, 100 - zoo.animals[3].Health, 0.0001);
            Assert.AreEqual(expected5, 100 - zoo.animals[4].Health, 0.0001);
            Assert.AreEqual(expected6, 100 - zoo.animals[5].Health, 0.0001);
            Assert.AreEqual(expected7, 100 - zoo.animals[6].Health, 0.0001);
            Assert.AreEqual(expected8, 100 - zoo.animals[7].Health, 0.0001);
            Assert.AreEqual(expected9, 100 - zoo.animals[8].Health, 0.0001);
            Assert.AreEqual(expected10, 100 - zoo.animals[9].Health, 0.0001);
            Assert.AreEqual(expected11, 100 - zoo.animals[10].Health, 0.0001);
            Assert.AreEqual(expected12, 100 - zoo.animals[11].Health, 0.0001);
            Assert.AreEqual(expected13, 100 - zoo.animals[12].Health, 0.0001);
            Assert.AreEqual(expected14, 100 - zoo.animals[13].Health, 0.0001);
            Assert.AreEqual(expected15, 100 - zoo.animals[14].Health, 0.0001);

            Assert.AreEqual(15, zoo.animals.Count);
        }

        [TestMethod]
        public void Feed_MonkeyWith90HealthBy10_Returns99HealthForMonkey()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal { Type = AnimalType.Monkey });
            
            // act
            Zoo zoo = new Zoo(animals);

            foreach (var animal in zoo.animals) {
                animal.Health = 90;
                animal.Feed(10);
            }

            // assert
            Assert.AreEqual(99, zoo.animals[0].Health, 0.0001);
        }

        [TestMethod]
        public void Feed_MonkeyWith90HealthBy0_Returns90HealthForMonkey()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal { Type = AnimalType.Monkey });
            
            // act
            Zoo zoo = new Zoo(animals);

            foreach (var animal in zoo.animals)
            {
                animal.Health = 90;
                animal.Feed(0);
            }

            // assert
            Assert.AreEqual(90, zoo.animals[0].Health, 0.0001);
        }

        [TestMethod]
        public void Feed_3DifferentAnimalTypesWith90HealthBy10Percent_Returns99()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal { Type = AnimalType.Monkey });
            animals.Add(new Animal { Type = AnimalType.Giraffe });
            animals.Add(new Animal { Type = AnimalType.Elephant });

            // act
            Zoo zoo = new Zoo(animals);
            foreach (var animal in zoo.animals)
            {
                animal.Health = 90;
                animal.Feed(10);
            }

            Assert.AreEqual(AnimalType.Monkey, zoo.animals[0].Type);
            Assert.AreEqual(AnimalType.Giraffe, zoo.animals[1].Type);
            Assert.AreEqual(AnimalType.Elephant, zoo.animals[2].Type);

            Assert.AreEqual(99, zoo.animals[0].Health, 0.0001);
            Assert.AreEqual(99, zoo.animals[1].Health, 0.0001);
            Assert.AreEqual(99, zoo.animals[2].Health, 0.0001);


        }

        [TestMethod]
        public void Feed_MonkeyWith100HealthBy1_ReturnsInvalidOperationException()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal { Type = AnimalType.Monkey });

            // act
            Zoo zoo = new Zoo(animals);            

            // assert
            Assert.ThrowsException<InvalidOperationException>(() => animals[0].Feed(1));
        }

        [TestMethod]
        public void RandomNumberGenerator_WhenGenerateIsCalled_ReturnsARandomNumberBetween0And20()
        {
            // arrange
            RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator(0, 20);

            // act
            var randomNumber = randomNumberGenerator.GetNumber();

            // assert
            Assert.IsTrue(randomNumber >= 0 && randomNumber <= 20);
        }

        [TestMethod]
        public void RandomNumberGenerator_WhenGenerateIsCalled_ReturnsARandomNumberBetween10And25()
        {
            // arrange
            RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator(10, 25);

            // act
            var randomNumber = randomNumberGenerator.GetNumber();

            // assert
            Assert.IsTrue(randomNumber >= 10 && randomNumber <= 25);
        }

        // This could be a test for the future.. Maybe there should be different implementations of random number generator
        // i.e. different implementations should have different default range passed in
        [TestMethod]
        public void RandomNumberGenerator_WhenGenerateIsCalled_ThrowOutOfRan()
        {
            // arrange
            RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator(10, 25);

            // act
            var randomNumber = randomNumberGenerator.GetNumber();

            // assert
            Assert.IsTrue(randomNumber >= 10 && randomNumber <= 25);
        }




        //[TestMethod]
        //public void Feed_Generates3RandomNumbers_ReturnsRandomNumberBetween10And25()
        //{
        //    // arrange
        //    List<Animal> animals = new List<Animal>();
        //    animals.Add(new Animal { Type = AnimalType.Monkey });

        //    // act
        //    Zoo zoo = new Zoo(animals);
        //    zoo.Feed();

        //    // assert

        //}

        //private static readonly Random random = new Random();

        //private static double RandomNumberBetween(double minValue, double maxValue)
        //{
        //    var next = random.NextDouble();

        //    return minValue + (next * (maxValue - minValue));
        //}


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
        public double Health
        {
            get; set; }        
        public Animal()
        {
            Health = 100;
        }

        internal void ReduceHealth(double healthReductionInPercent)
        {
            if (healthReductionInPercent < 0 || healthReductionInPercent > 20) {
                throw new ArgumentOutOfRangeException("healthReductionInPercent", "Please enter a value between than 0 and 20");
            }

            const double denominator = 100;
            double reduction = (healthReductionInPercent / denominator) * Health;
            Health -= reduction;
        }

        internal void Feed(double healthBoost)
        {
            if (Health == 100) {
                throw new InvalidOperationException("The health of this animal is already at its maximum");
            }

            const double denominator = 100;
            double boost = (healthBoost / denominator) * Health;
            Health += boost; 
        }
    }

    public class RandomNumberGenerator
    {
        private int minValue;
        private int maxValue;

        public RandomNumberGenerator(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        internal double GetNumber()
        {
            return 0;
        }
    }
}

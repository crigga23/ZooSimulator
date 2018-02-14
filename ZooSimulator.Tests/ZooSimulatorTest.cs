using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;
using ZooSimulator.Models;

namespace ZooSimulator.Tests
{
    [TestClass]
    public class ZooSimulatorTest
    {
        [TestMethod]
        public void Zoo_TakesOneMonkey_ReturnsOneMonkey()
        {
            // arrange 
            List<Animal> animals = new List<Animal>() {
                new Monkey()
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
                new Giraffe()
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
                new Elephant()
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
                animals.Add(new Monkey());
                animals.Add(new Giraffe());
                animals.Add(new Elephant());
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

            animals.Add(new Monkey());

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

            animals.Add(new Monkey());
            animals.Add(new Giraffe());
            animals.Add(new Elephant());

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

            animals.Add(new Monkey());

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

            animals.Add(new Monkey());

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

            animals.Add(new Monkey());

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

            animals.Add(new Monkey());

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

            animals.Add(new Monkey());

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

            animals.Add(new Monkey());

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

            animals.Add(new Monkey());
            animals.Add(new Giraffe());
            animals.Add(new Elephant());

            // generate a list of random numbers - list equal to the size of animals
            List<double> randomNumbers = new List<double>(animals.Count);
            for (var animalIndex = 0; animalIndex < animals.Count; animalIndex++)
            {
                randomNumbers.Add(RandomNumberGenerator.GetNumberInRange(0, 20));
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
                animals.Add(new Monkey());
                animals.Add(new Giraffe());
                animals.Add(new Elephant());
            }

            // generate a list of random numbers - list equal to the size of animals
            List<double> randomNumbers = new List<double>(animals.Count);
            for (var animalIndex = 0; animalIndex < animals.Count; animalIndex++)
            {   
                randomNumbers.Add(RandomNumberGenerator.GetNumberInRange(0, 20));
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
        public void Feed_MonkeyWith90PercentHealth_HealthIsBoostedForMonkey()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Monkey());

            Zoo zoo = new Zoo(animals);

            foreach (var animal in zoo.animals)
            {
                animal.Health = 90;
            }

            // act
            zoo.Feed();

            // assert
            var healthIsBoosted = zoo.animals[0].Health >= 90;
            Assert.IsTrue(healthIsBoosted);
        }

        [TestMethod]
        public void Feed_MonkeyWith100PercentHealth_HealthIsStill100PercentForMonkey()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Monkey());

            Zoo zoo = new Zoo(animals);

            foreach (var animal in zoo.animals)
            {
                animal.Health = 100;
            }

            // act
            zoo.Feed();

            // assert
            var healthIsMax = zoo.animals[0].Health == 100;
            Assert.IsTrue(healthIsMax);
        }

        [TestMethod]
        public void Feed_3DifferentAnimalTypesWith50PercentHealth_HealthBoostedForThem()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Monkey());
            animals.Add(new Giraffe());
            animals.Add(new Elephant());

            Zoo zoo = new Zoo(animals);
            foreach (var animal in zoo.animals)
            {
                animal.Health = 50;
            }

            // act
            zoo.Feed();

            Assert.AreEqual(AnimalType.Monkey, zoo.animals[0].Type);
            Assert.AreEqual(AnimalType.Giraffe, zoo.animals[1].Type);
            Assert.AreEqual(AnimalType.Elephant, zoo.animals[2].Type);
            
            Assert.IsTrue(zoo.animals[0].Health >= 50);
            Assert.IsTrue(zoo.animals[1].Health >= 50);
            Assert.IsTrue(zoo.animals[2].Health >= 50);


        }

        [TestMethod]
        public void RandomNumberGenerator_WhenGenerateIsCalled_ReturnsARandomNumberBetween0And20()
        {
            // arrange
            // act
            var randomNumber = RandomNumberGenerator.GetNumberInRange(0, 20);

            // assert
            Assert.IsTrue(randomNumber >= 0 && randomNumber <= 20);
        }

        [TestMethod]
        public void RandomNumberGenerator_WhenGenerateIsCalled_ReturnsARandomNumberBetween10And25()
        {
            // arrange
            // act
            var randomNumber = RandomNumberGenerator.GetNumberInRange(10, 25);

            // assert
            Assert.IsTrue(randomNumber >= 10 && randomNumber <= 25);
        }


        [TestMethod]
        public void ReduceHealth_ElephantHealthBelow70Percent_ElephantCannotWalk()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Elephant());
            Zoo zoo = new Zoo(animals);
            animals[0].Health = 70;
            animals[0].CanWalk = true;

            // act

            animals[0].ReduceHealth(10);

            // assert
            Assert.IsFalse(animals[0].CanWalk);

        }

        //[TestMethod]
        //public void ReduceHealth_ElephantHealthStillBelow50Percent_ElephantIsDead()
        //{
        //    // arrange
        //    List<Animal> animals = new List<Animal>();
        //    animals.Add(new Giraffe());
        //    Zoo zoo = new Zoo(animals);
        //    animals[0].Health = 50;

        //    // act
        //    animals[0].ReduceHealth(10);

        //    // assert
        //    Assert.IsTrue(animals[0].IsDead);

        //}

        [TestMethod]
        public void ReduceHealth_MonkeyHealthBelow30Percent_MonkeyIsDead()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Monkey());
            Zoo zoo = new Zoo(animals);
            animals[0].Health = 30;

            // act

            animals[0].ReduceHealth(10);

            // assert
            Assert.IsTrue(animals[0].IsDead);

        }

        [TestMethod]
        public void ReduceHealth_KillMonkey()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Monkey());
            Zoo zoo = new Zoo(animals);

            // act
            animals[0].ReduceHealth(20);
            animals[0].ReduceHealth(20);
            animals[0].ReduceHealth(20);
            animals[0].ReduceHealth(20);
            animals[0].ReduceHealth(20);
            animals[0].ReduceHealth(20);

            // assert
            Assert.IsTrue(animals[0].IsDead, string.Format("The current health is: {0}", animals[0].Health));

        }

        [TestMethod]
        public void ReduceHealth_GiraffeHealthBelow50Percent_GiraffeIsDead()
        {
            // arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Giraffe());
            Zoo zoo = new Zoo(animals);
            animals[0].Health = 50;

            // act

            animals[0].ReduceHealth(10);

            // assert
            Assert.IsTrue(animals[0].IsDead);

        }
    }
}

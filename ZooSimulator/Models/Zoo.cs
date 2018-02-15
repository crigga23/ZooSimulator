using System.Collections.Generic;
using System;
using System.Linq;

namespace ZooSimulator.Models
{
    public class Zoo : IZooKeeper
    {
        public List<Animal> animals { get; set; }

        private string[] animalTypeStrings = Enum.GetNames(typeof(AnimalType));
        private Dictionary<AnimalType, double> randomPerAnimal;
        
        public Zoo(List<Animal> animals)
        {
            this.animals = animals;
            randomPerAnimal = new Dictionary<AnimalType, double>();
        }
        
        public void Feed()
        {
            GetRandomNumberPerAnimalType();
            BoostAnimalHealth();
        }

        private void BoostAnimalHealth()
        {
            foreach (var animal in animals)
            {
                var boostHealthByPercent = randomPerAnimal.FirstOrDefault(a => a.Key == animal.Type).Value;
                var isNotMaxHealth = animal.Health != 100;
                if (isNotMaxHealth)
                {
                    const double denominator = 100;
                    double boost = (boostHealthByPercent / denominator) * animal.Health;
                    animal.Health += boost;
                }
            }
        }

        private void GetRandomNumberPerAnimalType()
        {
            foreach (var animalTypeString in animalTypeStrings)
            {
                randomPerAnimal.Add((AnimalType)Enum.Parse(typeof(AnimalType), animalTypeString), RandomNumberGenerator.GetNumberInRange(0, 25));
            }
        }
    }
}

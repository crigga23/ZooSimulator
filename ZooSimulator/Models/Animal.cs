using System;

namespace ZooSimulator.Models
{
    public class Animal : IHealth, IWalkable
    {  
        public int ID { get; set; }
        public AnimalType Type { get; set; }
        public double Health { get; set; }
        public virtual bool CanWalk { get; set; }
        public virtual bool IsDead { get; set; }

        public Animal()
        {
            Health = 100;
        }

        public void ReduceHealth(double reduceHealthByInPercent)
        {
            if (reduceHealthByInPercent < 0 || reduceHealthByInPercent > 20) {
                throw new ArgumentOutOfRangeException("healthReductionInPercent", "Please enter a value between than 0 and 20");
            }

            // This smells should probably live in Elephant
            if (Type == AnimalType.Elephant && !CanWalk)
            {
                IsDead = true;
            }

            const double denominator = 100;
            double reduction = (reduceHealthByInPercent / denominator) * Health;
            Health -= reduction;
        }
    }
}

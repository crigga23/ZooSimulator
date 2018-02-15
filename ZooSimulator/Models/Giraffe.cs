namespace ZooSimulator.Models
{
    public class Giraffe : Animal
    {
        public Giraffe()
        {
            Type = AnimalType.Giraffe;
        }

        public override bool IsDead
        {
            get { return Health < 50; }
        }
    }
}

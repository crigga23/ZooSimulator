namespace ZooSimulator.Models
{
    public class Elephant : Animal
    {
        public Elephant()
        {
            Type = AnimalType.Elephant;
        }

        public override bool CanWalk {
            get { return Health >= 70; }
        }
    }
}

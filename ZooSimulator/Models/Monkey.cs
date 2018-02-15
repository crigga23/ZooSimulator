namespace ZooSimulator.Models
{
    public class Monkey : Animal
    {
        public Monkey()
        {
            Type = AnimalType.Monkey;
        }

        public override bool IsDead
        {
            get { return Health < 30; }
        }
    }
}

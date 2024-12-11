namespace EggfarmModel.Model
{
    public class Egg
    {
        public Egg(IEggProducer mother)
        {
            this.Mother = mother;
            this.Id = Guid.NewGuid();
            this.DateLayed = DateOnly.FromDateTime(DateTime.Now);

            Random random = new();
            this.Weight = random.Next(45, 81);
            this.Color = (EggColor)random.Next(Enum.GetValues(typeof(EggColor)).Length);
        }

        public double Weight { get; set; }
        public Guid Id { get; set; }
        public DateOnly DateLayed { get; set; }

        public EggColor Color { get; set; }
        public IEggProducer Mother { get; set; }
    }

    public enum EggColor
    {
        Dark,
        Light,
        Green
    }
}
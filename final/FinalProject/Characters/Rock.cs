namespace RPG.Characters
{
    public class Rock : Character
    {
        public Rock() : base("Rock", 80, 0) { }

        public override int Attack() => 0;

        public override string MakeSound() => "...";
    }
}

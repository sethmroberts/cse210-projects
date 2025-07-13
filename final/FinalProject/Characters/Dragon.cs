namespace RPG.Characters
{
    public class Dragon : Character
    {
        public Dragon() : base("Dragon", 200, 25) { }

        public override int Attack() => baseDamage;

        public override string MakeSound() => "ROAR!";
    }
}

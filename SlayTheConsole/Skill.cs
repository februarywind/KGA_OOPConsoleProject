using SlayTheConsole.Monster;

namespace SlayTheConsole
{
    public abstract class Skill
    {
        public string name { get; private set; }
        public string info { get; private set; }
        public Skill(string name, string info)
        {
            this.name = name;
            this.info = info;
        }

        public abstract void Action(Monsters monster, Player player);
    }

    public class Strike : Skill
    {
        public Strike() : base("타격", "피해를 6 줍니다.") { }
        public override void Action(Monsters monster, Player player)
        {
            monster.Hit(6);
        }
    }

    public class Bash : Skill
    {
        public Bash() : base("강타", "피해를 8 줍니다. 취약을 2 부여합니다.") { }
        public override void Action(Monsters monster, Player player)
        {
            monster.Hit(6);
        }
    }

    public class Defend : Skill
    {
        public Defend() : base("수비", "방어도를 5 얻습니다.") { }
        public override void Action(Monsters monster, Player player)
        {
            player.SetDp(5);
        }
    }
}

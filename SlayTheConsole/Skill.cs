using SlayTheConsole.Monster;

namespace SlayTheConsole
{
    public abstract class Skill
    {
        public string name { get; private set; }
        public string info { get; private set; }
        public int cost { get; private set; }
        public bool atackType { get; private set; }
        public Skill(string name, string info, int cost, bool atackType)
        {
            this.name = name;
            this.info = info;
            this.atackType = atackType;
            this.cost = cost;
        }

        public abstract bool Action(Monsters monster, Player player);
    }

    public class Strike : Skill
    {
        public Strike() : base("타격", "피해를 6 줍니다.", 1, true) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            monster.Hit(6);
            return true;
        }
    }

    public class Bash : Skill
    {
        public Bash() : base("강타", "피해를 8 줍니다. 취약을 2 부여합니다.", 2, true) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            monster.Hit(8);
            return true;
        }
    }

    public class Defend : Skill
    {
        public Defend() : base("수비", "방어도를 5 얻습니다.", 1, false) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            player.SetDp(5);
            return true;
        }
    }
}

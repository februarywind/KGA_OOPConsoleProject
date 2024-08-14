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
        public Strike() : base("타격", "피해를 6(+ap) 줍니다.", 1, true) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            monster.Hit(6 + player.ap);
            return true;
        }
    }

    public class Bash : Skill
    {
        public Bash() : base("강타", "피해를 8(+ap) 줍니다. 취약을 부여합니다.", 2, true) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            monster.Hit(8 + player.ap);
            monster.MonsterState();
            return true;
        }
    }

    public class Defend : Skill
    {
        public Defend() : base("수비", "방어도를 5(+dp) 얻습니다.", 1, false) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            player.SetDp(5 + player.upDp);
            return true;
        }
    }
    public class BodySlam : Skill
    {
        public BodySlam() : base("몸통 박치기", "현재 방어도 만큼의 피해를 줍니다.", 1, true) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            monster.Hit(player.dp + player.ap);
            return true;
        }
    }
    public class HeavyBlade : Skill
    {
        public HeavyBlade() : base("대검", "피해를 14(+ap * 3) 줍니다.", 2, true) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            monster.Hit(14 + player.ap * 3);
            return true;
        }
    }
    public class IronWave : Skill
    {
        public IronWave() : base("철의 파동", "방어도를 5(+dp) 얻습니다. 피해를 5(+ap) 줍니다.", 1, true) { }
        public override bool Action(Monsters monster, Player player)
        {
            player.UseMp(cost);
            if (player.mp < 0)
            {
                player.UseMp(-cost);
                return false;
            }
            monster.Hit(5 + player.ap);
            player.SetDp(5 + player.upDp);
            return true;
        }
    }
}

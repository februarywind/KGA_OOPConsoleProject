using SlayTheConsole.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheConsole
{
    public abstract class MonsterSKill
    {
        public string name;
        public int value;
        public MonsterSKill(string name)
        {
            this.name = name;
        }

        public abstract void Action(Monsters monster, Player player);

    }
    public class MonsterAtack : MonsterSKill
    {
        public MonsterAtack() : base("공격") { }
        public override void Action(Monsters monster, Player player)
        {
            player.Hit(monster.ap);
        }
    }
    public class MonsterDefend : MonsterSKill
    {
        public MonsterDefend() : base("방어") { }
        public override void Action(Monsters monster, Player player)
        {
            monster.SetDp(monster.dp);
        }
    }
}

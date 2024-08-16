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

        public abstract void Action(Monsters monster, Player player);

    }
    public class MonsterAtack : MonsterSKill
    {
        public MonsterAtack(Monsters monsters)
        {
            name = "공격";
            value = monsters.ap;
        }
        public override void Action(Monsters monster, Player player)
        {
            player.Hit(monster.ap);
        }
    }
    public class MonsterDefend : MonsterSKill
    {
        public MonsterDefend(Monsters monsters)
        {
            name = "방어";
            value = monsters.setDp;
        }
        public override void Action(Monsters monster, Player player)
        {
            monster.SetDp(monster.setDp);
        }
    }
    public class MonsterBuff : MonsterSKill
    {
        public MonsterBuff(Monsters monsters)
        {
            name = "버프";
            value = monsters.setAp;
        }
        public override void Action(Monsters monster, Player player)
        {
            monster.SetAp(monster.setAp);
        }
    }
}

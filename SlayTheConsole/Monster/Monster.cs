namespace SlayTheConsole.Monster
{
    public class Monsters
    {
        public string name { get; private set; } = "";
        public int maxHp { get; private set; }
        public int hp { get; private set; }
        public int dp { get; private set; }
        public int setDp { get; private set; }
        public int ap { get; private set; }
        public bool state { get; private set; }
        public MonsterSKill[] action { get; private set; }

        string[] monstersName = { 
            "가시 슬라임", 
            "산성 슬라임",
            "턱벌레"
        };
        int[] monstersHp = { 
            10,
            8,
            40
        };
        int[] monstersSetDp = {
            0,
            0,
            5,
        };
        int[] monstersAp = { 
            5,
            3,
            11,
        };
        MonsterSKill[][] monstersAction = { 
            new MonsterSKill[]{new MonsterAtack() }, 
            new MonsterSKill[] { new MonsterAtack() },
            new MonsterSKill[] { new MonsterAtack(), new MonsterDefend() } 
        };

        public static Monsters GetMonster(int n)
        {
            Monsters monster = new Monsters();
            monster.name = monster.monstersName[n];
            monster.maxHp = monster.monstersHp[n];
            monster.hp = monster.monstersHp[n];
            monster.ap = monster.monstersAp[n];
            monster.setDp = monster.monstersSetDp[n];
            monster.action = monster.monstersAction[n];
            return monster;
        }

        public void Hit(int damage)
        {
            if (state)
                damage = (int)(damage * 1.5);
            if (dp >= damage)
            {
                dp -= damage;
                damage = 0;
            }
            else
            {
                damage -= dp;
                dp = 0;
            }
            hp -= damage;
        }

        public void SetDp(int value)
        {
            dp += value;
        }
        public void MonsterTurn()
        {
            dp = 0;
        }

        public void MonsterState()
        {
            state = true;
        }
    }
}

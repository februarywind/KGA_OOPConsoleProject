namespace SlayTheConsole.Monster
{
    public class Monsters
    {
        public string name { get; protected set; } = "";
        public int maxHp { get; protected set; }
        public int hp { get; protected set; }
        public int dp { get; private set; }
        public int setDp { get; protected set; }
        public int ap { get; protected set; }
        public int setAp { get; protected set; }
        public bool state { get; private set; }
        public MonsterSKill[] action { get; protected set; }

        public static List<Monsters> SetMonster(List<Monsters> monsters, int stage)
        {
            Monsters[][] stageMonster = new Monsters[10][];
            stageMonster[0] = new Monsters[] { new SpikeSlime() };
            stageMonster[1] = new Monsters[] { new SpikeSlime(), new AcidSlime() };
            stageMonster[2] = new Monsters[] { new JawWorm() };
            stageMonster[3] = new Monsters[] { new Cultist(), new Cultist() };
            stageMonster[4] = new Monsters[] { new Cultist(), new SpikeSlime(), new SpikeSlime() };
            stageMonster[5] = new Monsters[] { new JawWorm(), new JawWorm() };
            stageMonster[6] = new Monsters[] { new ShieldGremlin(), new WizardGremlin(), new SneakyGremlin(), };
            stageMonster[7] = new Monsters[] { new SlimeBoss() };
            stageMonster[8] = new Monsters[] { new SlimeBoss() };
            stageMonster[9] = new Monsters[] { new SlimeBoss() };
            foreach (var item in stageMonster[stage])
            {
                monsters.Add(item);
            }
            return monsters;
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

        public void SetAp(int value)
        {
            ap += value;
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

    class AcidSlime : Monsters
    {
        public AcidSlime()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "산성 슬라임";
            maxHp = 8;
            hp = maxHp;
            ap = 4;
            action = new MonsterSKill[] { new MonsterAtack(this) };
            return monsters;
        }
    }

    class SpikeSlime : Monsters
    {
        public SpikeSlime()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "가시 슬라임";
            maxHp = 10;
            hp = maxHp;
            ap = 5;
            action = new MonsterSKill[] { new MonsterAtack(this) };
            return monsters;
        }
    }

    class JawWorm : Monsters
    {
        public JawWorm()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "턱벌레";
            maxHp = 40;
            hp = maxHp;
            ap = 11;
            setDp = 11;
            action = new MonsterSKill[] { new MonsterAtack(this), new MonsterDefend(this), };
            return monsters;
        }
    }

    class Cultist : Monsters
    {
        public Cultist()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "광신자";
            maxHp = 48;
            hp = maxHp;
            ap = 6;
            setAp = 6;
            action = new MonsterSKill[] { new MonsterBuff(this), new MonsterBuff(this), new MonsterAtack(this), };
            return monsters;
        }
    }
    class ShieldGremlin : Monsters
    {
        public ShieldGremlin()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "방패 그렘린";
            maxHp = 12;
            hp = maxHp;
            ap = 6;
            setDp = 14;
            action = new MonsterSKill[] { new MonsterDefend(this), new MonsterAtack(this), };
            return monsters;
        }
    }
    class WizardGremlin : Monsters
    {
        public WizardGremlin()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "마법사 그렘린";
            maxHp = 23;
            hp = maxHp;
            ap = 5;
            setAp = 10;
            action = new MonsterSKill[] { new MonsterBuff(this), new MonsterBuff(this), new MonsterAtack(this), };
            return monsters;
        }
    }
    class SneakyGremlin : Monsters
    {
        public SneakyGremlin()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "교활한 그렘린";
            maxHp = 14;
            hp = maxHp;
            ap = 10;
            action = new MonsterSKill[] { new MonsterAtack(this), };
            return monsters;
        }
    }
    class SlimeBoss : Monsters
    {
        public SlimeBoss()
        {
            ReturnMonster();
        }
        public Monsters ReturnMonster()
        {
            Monsters monsters = new Monsters();
            name = "대왕 슬라임";
            maxHp = 140;
            hp = maxHp;
            ap = 35;
            action = new MonsterSKill[] { new MonsterBuff(this), new MonsterBuff(this), new MonsterAtack(this), };
            return monsters;
        }
    }
}

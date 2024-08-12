namespace SlayTheConsole.Monster
{
    public class Monsters
    {
        public string name { get; private set; } = "";
        public int maxHp { get; private set; }
        public int hp { get; private set; }
        public int dp { get; private set; }
        public int ap { get; private set; }
        public string[] action { get; private set; }

        string[] monstersName = { "가시 슬라임", "산성 슬라임" };
        int[] monstersHp = { 10, 8 };
        int[] monstersDp = { 0, 0 };
        int[] monstersAp = { 5, 3 };
        string[][] monstersAction = { new string[]{ "공격", "방어" }, new string[] { "공격", "방어" } };

        public static Monsters GetMonster(int n)
        {
            Monsters monster = new Monsters();
            monster.name = monster.monstersName[n];
            monster.maxHp = monster.monstersHp[n];
            monster.hp = monster.monstersHp[n];
            monster.action = monster.monstersAction[n];
            return monster;
        }

        public void Hit(int damage)
        {
            hp -= damage;
        }
    }
}

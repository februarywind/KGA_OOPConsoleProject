namespace SlayTheConsole
{
    public class Player
    {
        public int maxHp { get; private set; } = 80;
        public int hp { get; private set; } = 80;
        public int dp { get; private set; } = 0;
        public int maxMp { get; private set; } = 3;
        public int mp { get; private set; } = 3;

        public List<Skill> skillList = new List<Skill>() {new Strike(), new Defend(), new Bash(), new Bash(), new Bash() };

        public void Hit(int damage)
        {
            hp -= damage;
        }

        public void SetDp(int value)
        {
            dp += value;
        }
    }
}

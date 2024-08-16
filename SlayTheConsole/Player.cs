namespace SlayTheConsole
{
    public class Player
    {
        public int maxHp { get; private set; } = 80;
        public int hp { get; private set; } = 80;
        public int ap { get; private set; } = 0;
        public int tempAp { get; private set; } = 0;
        public int dp { get; private set; } = 0;
        public int upDp { get; private set; } = 0;
        public int maxMp { get; private set; } = 3;
        public int mp { get; private set; } = 3;

        public List<Skill> skillList = new List<Skill>() { new Strike(), new Strike(), new Strike(), new Strike(), new Strike(), new Defend(), new Defend(), new Defend(), new Defend(), new Bash() };

        public void Hit(int damage)
        {
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
        public void SetTempAp(int value)
        {
            tempAp += value;
            ap += value;
        }

        public void SetDp(int value)
        {
            dp += value;
        }
        public void UseMp(int value)
        {
            mp -= value;
        }

        public void TurnStart()
        {
            dp = 0;
            mp = maxMp;
            if (tempAp != 0)
            {
                ap -= tempAp;
                tempAp = 0;
            }
        }

        public void UpStat(int[] ints)
        {
            maxHp += ints[0];
            ap += ints[1];
            upDp += ints[2];
        }
    }
}

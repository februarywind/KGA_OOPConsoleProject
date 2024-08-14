namespace SlayTheConsole.Scenes
{
    internal class SelectScene : Scene
    {
        public SelectScene(Game game) : base(game) { }
        List<Skill> Reward = new List<Skill> { new BodySlam(), new HeavyBlade(), new IronWave() };
        public override void Enter()
        {
            Random random = new Random();
            Reward = new List<Skill>(Reward.OrderBy(x => random.Next()).ToList());

        }
        public override void Render()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine($"{"보상을 선택하십시오",60}");
            Console.WriteLine($"{"1. 능력치 상승",60}");
            Console.WriteLine($"{"2. 새로운 스킬",60}");
        }
        public override void Input()
        {
            int input = 0;
            do
            {
                input = Console.ReadKey().KeyChar - '0';
            }
            while (input < 0 || input > 2);
            if (input == 1)
            {
                UpStat();
            }
            else
            {
                AddSkill();
            }
        }
        public override void Update()
        {
            game.ChangeScene(SceneType.Battle);
        }
        public override void Exit()
        {
            Console.Clear();
        }
        public void UpStat()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 10);
            Console.WriteLine($"{"1. 최대체력 상승 2. 공격력 상승 3. 방어력 상승",65}");
            int input = 0;
            do
            {
                input = Console.ReadKey().KeyChar - '0';
            }
            while (input < 0 || input > 3);
            switch (input)
            {
                case 1:
                    game.player.UpStat([5, 0, 0]);
                    Console.WriteLine($"{"최대체력 5 상승.",60}");
                    break;
                case 2:
                    game.player.UpStat([0, 1, 0]);
                    Console.WriteLine($"{"공격력 1 상승.",60}");
                    break;
                case 3:
                    game.player.UpStat([0, 0, 1]);
                    Console.WriteLine($"{"방여력 1 상승.",60}");
                    break;
            }
            Console.ReadKey();
        }
        public void AddSkill()
        {
            {
                Console.Clear();
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"1. {Reward[0].name} 행동력 : {Reward[0].cost} {Reward[0].info}");
                Console.WriteLine($"2. {Reward[1].name} 행동력 : {Reward[1].cost} {Reward[1].info}");
                Console.WriteLine($"3. {Reward[2].name} 행동력 : {Reward[2].cost} {Reward[2].info}");
                int input = 0;
                do
                {
                    input = Console.ReadKey().KeyChar - '0';
                }
                while (input < 0 || input > 3);
                switch (input)
                {
                    case 1:
                        game.player.skillList.Add(Reward[0]);
                        Console.WriteLine($"{$"{Reward[0].name} 스킬 획득.",60}");
                        break;
                    case 2:
                        game.player.skillList.Add(Reward[1]);
                        Console.WriteLine($"{$"{Reward[1].name} 스킬 획득.",60}");
                        break;
                    case 3:
                        game.player.skillList.Add(Reward[2]);
                        Console.WriteLine($"{$"{Reward[2].name} 스킬 획득.",60}");
                        break;
                }
                Console.ReadKey();

            }
        }
    } }

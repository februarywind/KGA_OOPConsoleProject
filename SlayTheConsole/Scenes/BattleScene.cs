using SlayTheConsole.Monster;

namespace SlayTheConsole.Scenes
{
    public class BattleScene : Scene
    {
        public BattleScene(Game game) : base(game) { }
        List<Monsters> monsters = new List<Monsters>();
        Queue<Skill> drawSkill = new();
        List<Skill> holdingSkill = new();
        List<Skill> usedSkill = new();

        public override void Enter()
        {
            Console.WriteLine("1 스테이지");
            monsters.Add(Monsters.GetMonster(0));
            monsters.Add(Monsters.GetMonster(1));
            Random random = new Random();
            drawSkill = new Queue<Skill>(game.player.skillList.OrderBy(x => random.Next()).ToList());
            PlayerTurn();
        }
        public override void Render()
        {
            // 몬스터 정보 출력
            int[] setCursor = { 56, 36, 76 };
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.SetCursorPosition(setCursor[i], 5);
                Console.WriteLine(monsters[i].name);
                Console.SetCursorPosition(setCursor[i], 6);
                Console.WriteLine($"체력 : {monsters[i].hp}/{monsters[i].maxHp}");
                Console.SetCursorPosition(setCursor[i], 7);
                Console.WriteLine($"행동: {monsters[i].action[0].name}");
                Console.SetCursorPosition(setCursor[i], 8);
                Console.WriteLine("상태: 기본");
            }

            // 플레이어 정보 출력
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{$"체력 : {game.player.hp}/{game.player.maxHp}\t방어도 : {game.player.dp}\t행동력 : {game.player.mp}/{game.player.maxMp}",65}");

            // 스킬 리스트 출력
            Console.SetCursorPosition(0, 22);
            Console.Write($"사용한 스킬 {usedSkill.Count}");

            Console.SetCursorPosition(108, 22);
            Console.Write($"남은 스킬 {drawSkill.Count}");

            Console.SetCursorPosition(36, 22);
            for (int i = 0; i < holdingSkill.Count; i++)
            {
                Console.Write($"{i + 1}. {holdingSkill[i].name} ");
            }
            Console.WriteLine("0. 턴종료");
        }
        public override void Input()
        {
            // 사용할 스킬 선택
            int input;
            char yesOrNo;
            do
            {
                input = Console.ReadKey().KeyChar - '0';
                if (input == 0)
                {
                    PlayerTurnEnd();
                    return;
                }
            } while (input < 1 || input > holdingSkill.Count);

            // 선택 스킬 정보출력
            Console.SetCursorPosition(0, 24);
            Console.WriteLine($"{holdingSkill[input - 1].name,55}, 행동력 : {holdingSkill[input - 1].cost}");
            Console.WriteLine($"{holdingSkill[input - 1].info,63}");
            Console.WriteLine($"{"스킬을 사용한다. y/n",63}");
            do
            {
                yesOrNo = Console.ReadKey().KeyChar;
                if (yesOrNo == 'y')
                {
                    UseSkill(input);
                    return;
                }
            } while (yesOrNo != 'n');
        }
        public override void Update()
        {
            Console.Clear();
        }
        public override void Exit() { }

        public void Draw(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (drawSkill.Count == 0)
                {
                    Random random = new Random();
                    drawSkill = new Queue<Skill>(usedSkill.OrderBy(x => random.Next()).ToList());
                    usedSkill.Clear();
                }
                holdingSkill.Add(drawSkill.Dequeue());
            }
        }

        public void PlayerTurn()
        {
            game.player.UseMp(-(game.player.maxMp - game.player.mp));
            game.player.SetDp(-game.player.dp);
            Draw(5);
        }
        public void PlayerTurnEnd()
        {
            usedSkill.AddRange(holdingSkill);
            holdingSkill.Clear();
            MonsterTurn();
        }
        public void MonsterTurn()
        {
            foreach (var item in monsters)
            {
                item.action[0].Action(item, game.player);
            }
            PlayerTurn();
        }

        public void UseSkill(int n)
        {
            int input = 1;

            Game.ClearLine(24, 3);
            if (holdingSkill[n - 1].atackType)
            {
                do
                {
                    Console.SetCursorPosition(0, 24);
                    Console.WriteLine($"{"대상을 지정하십시오",60}");
                    input = Console.ReadKey().KeyChar - '0';
                } while (input < 1 || input > monsters.Count);
            }
            if (holdingSkill[n - 1].Action(monsters[0 + input - 1], game.player))
            {
                usedSkill.Add(holdingSkill[n - 1]);
                holdingSkill.RemoveAt(n - 1);
            }
            if (monsters[0 + input - 1].hp <= 0)
            {
                monsters.Remove(monsters[0 + input - 1]);
            }

        }
    }
}

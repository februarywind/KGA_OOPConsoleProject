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
        Player Player = new();
        int turn;
        int stage;

        public override void Enter()
        {
            Player = game.player;
            Monsters.SetMonster(monsters, stage);
            Random random = new Random();
            drawSkill = new Queue<Skill>(Player.skillList.OrderBy(x => random.Next()).ToList());
            turn = -1;
            stage++;
            PlayerTurn();
        }
        public override void Render()
        {
            Console.WriteLine($"{stage}스테이지");
            // 몬스터 정보 출력
            int[] setCursor = { 56, 36, 76 };
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.SetCursorPosition(setCursor[i], 5);
                Console.WriteLine(monsters[i].name);
                Console.SetCursorPosition(setCursor[i], 6);
                Console.WriteLine($"체력 : {monsters[i].hp}/{monsters[i].maxHp} + {monsters[i].dp}");
                Console.SetCursorPosition(setCursor[i], 7);
                Console.WriteLine($"행동: {monsters[i].action[turn % monsters[i].action.Length].name} {monsters[i].action[turn % monsters[i].action.Length].value}");
                Console.SetCursorPosition(setCursor[i], 8);
                Console.WriteLine($"상태: {(monsters[i].state ? "취약":"기본")}");
            }

            // 플레이어 정보 출력
            Console.SetCursorPosition(50, 19);
            Console.WriteLine($"ap : {Player.ap}          dp : {Player.upDp}");
            Console.WriteLine($"{$"체력 : {Player.hp}/{Player.maxHp}\t방어도 : {Player.dp}\t행동력 : {Player.mp}/{Player.maxMp}",65}");

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
            if (monsters.Count == 0)
            {
                holdingSkill.Clear();
                usedSkill.Clear();
                game.ChangeScene(SceneType.Select);
            }
            if (Player.hp <= 0)
            {
                holdingSkill.Clear();
                usedSkill.Clear();
                game.ChangeScene(SceneType.GameOver);
            }
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
            turn++;
            Player.TurnStart();
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
                item.MonsterTurn();
                item.action[turn % item.action.Length].Action(item, Player);
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
            if (holdingSkill[n - 1].Action(monsters[0 + input - 1], Player))
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

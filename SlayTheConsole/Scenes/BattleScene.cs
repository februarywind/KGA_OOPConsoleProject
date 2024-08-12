using SlayTheConsole.Monster;

namespace SlayTheConsole.Scenes
{
    public class BattleScene : Scene
    {
        public BattleScene(Game game) : base(game) { }
        List<Monsters> monsters = new List<Monsters>();

        public override void Enter()
        {
            Console.WriteLine("1 스테이지");
            monsters.Add(Monsters.GetMonster(0));
        }
        public override void Render()
        {
            int[] setCursor = { 56, 36, 76 };
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.SetCursorPosition(setCursor[i], 5);
                Console.WriteLine(monsters[i].name);
                Console.SetCursorPosition(setCursor[i], 6);
                Console.WriteLine($"체력 : {monsters[i].hp}/{monsters[i].maxHp}");
                Console.SetCursorPosition(setCursor[i], 7);
                Console.WriteLine($"행동: {monsters[i].action[0]}");
                Console.SetCursorPosition(setCursor[i], 8);
                Console.WriteLine("상태: 기본");
            }
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{$"체력 : {game.player.hp}/{game.player.maxHp}\t방어도 : {game.player.dp}\t행동력 : {game.player.mp}/{game.player.maxMp}", 65}");
            Console.SetCursorPosition(36, 22);
            for (int i = 0; i < game.player.skillList.Count; i++)
            {
                Console.Write($"{i + 1}. {game.player.skillList[i].name} ");
            }
            Console.WriteLine("0. 턴종료");
        }
        public override void Input() 
        {
            Console.ReadKey();
            game.player.skillList[0].Action(monsters[0], game.player);
        }
        public override void Update() 
        {
            Console.Clear();
        }
        public override void Exit() { }
    }
}

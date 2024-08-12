namespace SlayTheConsole.Scenes
{
    public class TitleScene : Scene
    {
        public TitleScene(Game game) : base(game) { }

        public override void Enter()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"{"Slay The Console", 68}\n");
            Console.WriteLine($"{"Enter To Start", 67}");
        }
        public override void Render() { }
        public override void Input() 
        {
            Console.ReadLine();
        }
        public override void Update() 
        {
            game.ChangeScene(SceneType.Battle);
        }
        public override void Exit() 
        {
            Console.Clear();
        }
    }
}

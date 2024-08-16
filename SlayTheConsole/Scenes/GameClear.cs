using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheConsole.Scenes
{
    class GameClear : Scene
    {
        public GameClear(Game game) : base(game) { }

        public override void Enter()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"{"Game Clear",68}\n");
        }
        public override void Render() { }
        public override void Input()
        {
            Console.ReadKey();
            game.Over();
        }
        public override void Update()
        {

        }
        public override void Exit()
        {

        }
    }
}

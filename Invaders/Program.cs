using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using Invaders.Classes;
namespace Invaders 
{
    class Program 
    {
        public const int ScreenW = 500;
        public const int ScreenH = 700;
        
        static void Main(string[] args) {
            using (var window = new RenderWindow(
                       new VideoMode(ScreenW, ScreenH), "Invaders")) {
                window.Closed += (o, e) => window.Close();
                Clock clock = new Clock();
                Scene scene = new Scene(new AssetManager(), new EventManager());
                Player player = new Player();
                while (window.IsOpen) {
                    window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    deltaTime = MathF.Min(deltaTime, 0.01f);
                    player.Update(scene, deltaTime);
                    window.Clear(new Color(0, 0, 0));
                    player.Draw(window);
                    window.Display();
                }
            }
        }
    }
}
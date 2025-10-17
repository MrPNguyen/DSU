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
        public static RenderWindow window;
        
        static void Main(string[] args) {
            using ( window = new RenderWindow(
                       new VideoMode(ScreenW, ScreenH), "Invaders")) {
                window.Closed += (o, e) => window.Close();
                Clock clock = new Clock();
                Scene scene = new Scene(new AssetManager(), new EventManager(), new SceneLoader());
                scene.Loader.LoadGame(scene);
                while (window.IsOpen) {
                    window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    deltaTime = MathF.Min(deltaTime, 0.01f);
                    scene.UpdateAll(scene, deltaTime);
                    window.Clear();
                    scene.RenderAll(window);
                    window.Display();
                }
            }
        }
    }
}
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
        
        static void Main(string[] args) 
        {
            using (window = new RenderWindow(
                       new VideoMode(ScreenW, ScreenH), "Invaders", Styles.Titlebar)) {
                window.Closed += (o, e) => window.Close();
                window.SetFramerateLimit(60);
                Clock clock = new Clock();
                Scene scene = new Scene(new AssetManager(), new EventManager(), new SceneLoader(), new ScoreManager(), new HealthManager(), new HighScoreManager(0, ""));
                GameState lastState = SceneManager.state; 
                scene.Loader.LoadGame(scene);
                while (window.IsOpen) {
                    window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    deltaTime = MathF.Min(deltaTime, 0.01f);
                    if (SceneManager.state != lastState)
                    {
                        scene.Loader.LoadGame(scene);
                        lastState = SceneManager.state;
                    }
                    scene.UpdateAll(scene, deltaTime);
                    window.Clear();
                    scene.RenderAll(scene, window);
                    window.Display(); 
                }
            }
        }
    }
}

//Fix bullets not firing in the beginning, FIXED
//Fix high score name crash, FIXED
//Fix bullet detection system, FIXED
//Fix when exiting game through pause menu and then entering back in the game and it still being frozen, FIXED
//Fix Class Diagram
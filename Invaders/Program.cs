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
                Scene scene = new Scene(new AssetManager(), new EventManager(), new SceneLoader(), new ScoreManager(), new HealthManager(), new HighScoreManager());
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

//Problems:
//Fix saving highscores
//Fix limit to amount of highscores possible to save
//Fix highscores in descending order
//Fix audio sometimes cuts when going from pause menu to main menu
//Fix my life
using SFML.System;

namespace Invaders.Classes
{
    public class SceneLoader
    {
        public float spawnCooldown = 0.0f;
        public float spawnRate = 0.0f;


        public SceneLoader()
        {
            
        }
        public void LoadGame(Scene scene)
        {
            GameState SceneSwitch = SceneManager.state;
            if (SceneSwitch == GameState.GAME)
            {
                scene.Clear();
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula", "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue", "Backgrounds"));
                scene.Spawn(new Enemy());
                scene.Spawn(new Gui(new ScoreManager(), new HealthManager()));
                scene.Spawn(new Buttons("Pause", new Vector2f(10, 10), "MainMenu", "PauseButton", new Vector2f(0.2f, 0.2f)));
                scene.Spawn(new Player());
                scene.GameLost = false;
            }
            else if (SceneSwitch == GameState.MAINMENU)
            {
                scene.Clear();
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula",  "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue" ,  "Backgrounds"));
                scene.Spawn(new MainMenu());
            }
            else if (SceneSwitch == GameState.NAMEMENU)
            {
                
            }
            else if (SceneSwitch == GameState.SCOREMENU)
            {
                
            }
            else if (SceneSwitch == GameState.QUIT)
            {
                Environment.Exit(0);
            }
        }

        public void Reload(Scene scene)
        {
            if (scene.GameLost)
            {
                scene.Clear();
                LoadGame(scene);
                scene.GameLost = false;
            }
        }
        public void SpawnEnemies(Scene scene)
        {
            if (SceneManager.state == GameState.GAME)
            {
                if (spawnCooldown <= 0)
                {
                    Enemy enemy = new Enemy();
                    scene.Spawn(enemy);
                }
                if (spawnCooldown > 0)
                {
                    return;
                }
                spawnCooldown = 9.0f;
            }
        }

        public void IncreaseSpawnRate()
        {
            if (spawnRate <= 0)
            {
                spawnCooldown--;
            }
            if (spawnRate > 0 || spawnCooldown <= 2)
            {
                return;
            }
            spawnRate = 50.0f;
        }
    }
}


using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class SceneLoader
    {
        public float spawnCooldown = 0.0f;
        public float spawnRate = 0.0f;
        private Actor actor;
        public Gui gui;
        private int ActiveScore;
        private bool GameOver = false;

        public SceneLoader()
        {
            actor = new Actor();
            gui = new Gui(new ScoreManager(), new HealthManager());
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
                scene.Spawn(new Player(new HealthManager()));
                scene.GameLost = false;
            }
            else if (SceneSwitch == GameState.MAINMENU)
            {
                scene.Clear();
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula",  "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue" ,  "Backgrounds"));
                scene.Spawn(new MainMenu());
                scene.GameLost = false;
            }
            else if (SceneSwitch == GameState.NAMEMENU)
            {
                scene.Clear();
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula",  "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue" ,  "Backgrounds"));
                scene.Spawn(new NameMenu("tileset", "tilesets"));
                scene.GameLost = false;
            }
            else if (SceneSwitch == GameState.SCOREMENU)
            {
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula",  "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue" ,  "Backgrounds"));
                scene.GameLost = false;
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
                GameOver = false;
            }
        }
        
        public void GameLost(Scene scene)
        {
            if (scene.GameLost && !GameOver)
            {
                scene.Spawn(new GameOverMenu(scene.Score));
                actor.moving = false;
                GameOver = true;
            }
        }
        public void SpawnEnemies(Scene scene)
        {
            if (!scene.GameLost)
            {
                if (SceneManager.state == GameState.GAME)
                {
                    if (spawnCooldown <= 0)
                    {
                        Enemy enemy = new Enemy();
                        enemy.Zindex = 1;
                        scene.Spawn(enemy);
                    }
                    if (spawnCooldown > 0)
                    {
                        return;
                    }
                    spawnCooldown = 5.0f;
                }
            }
        }

        public void IncreaseSpawnRate(Scene scene)
        {
            if (!scene.GameLost)
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
}


using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class SceneLoader
    {
        public float spawnCooldown = 0.0f;
        public float spawnRate = 0.0f;
        private bool GameOver = false;
        public void LoadGame(Scene scene)
        {
            GameState SceneSwitch = SceneManager.state;
            if (SceneSwitch == GameState.GAME)
            {
                scene.Clear();
                scene.Score.CurrentScore = -1;
                scene.Health.currentHealth = scene.Health.maxHealth;
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula", "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue", "Backgrounds"));
                scene.Spawn(new Enemy());
                scene.Spawn(new Gui(scene.Score, scene.Health));
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
            else if (SceneSwitch == GameState.NEWHIGHSCORE)
            {
                scene.Clear();
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula",  "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue" ,  "Backgrounds"));
                scene.Spawn(new NewHighScore("tileset", "tilesets"));
                scene.GameLost = false;
            }
            else if (SceneSwitch == GameState.YOULOSE)
            {
                scene.Clear();
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula",  "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue" ,  "Backgrounds"));
                scene.Spawn(new GameOverMenu(new ScoreManager()));
                scene.GameLost = false;
            }
            else if (SceneSwitch == GameState.SCOREMENU)
            {
                scene.Clear();
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula",  "Backgrounds"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue" ,  "Backgrounds"));
                scene.Spawn(new ScoreMenu("PauseMenu", "MainMenu"));
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
            }
        }
        
        public void GameLost(Scene scene)
        {
            scene.Score.LoadhighScore();
            if (scene.GameLost)
            {
                //Console.WriteLine($"Your score: {scene.Score.CurrentScore} & your highscore {scene.High.highScore}");
                if (scene.Score.CurrentScore > scene.Score.highScore)
                {
                    SceneManager.LoadScene(GameState.NEWHIGHSCORE);

                }
                else
                {
                    SceneManager.LoadScene(GameState.YOULOSE);

                }
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


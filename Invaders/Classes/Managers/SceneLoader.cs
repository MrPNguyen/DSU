using SFML.System;

namespace Invaders.Classes
{
    public class SceneLoader
    {
        public float spawnCooldown = 0.0f;
        public float spawnRate = 0.0f;
        private GameState state;
        public void LoadGame(Scene scene)
        {
            if (state == GameState.GAME)
            {
                scene.Spawn(new Background(new Vector2f(0,0), "Nebula"));
                scene.Spawn(new Background(new Vector2f(0,-800), "Nebula Blue"));
                scene.Spawn(new Enemy());
                scene.Spawn(new Gui(new ScoreManager()));
                scene.Spawn(new Player());
                scene.GameLost = false;
            }
            else if (state == GameState.MAINMENU)
            {
                scene.Spawn(new MainMenu());
            }
            else if (state == GameState.NAMEMENU)
            {
                
            }
            else if (state == GameState.SCOREMENU)
            {
                
            }
            else
            {
                state = GameState.MAINMENU;
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
            if (state == GameState.GAME)
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


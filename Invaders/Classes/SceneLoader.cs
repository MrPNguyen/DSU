namespace Invaders.Classes
{
    public class SceneLoader
    {
        public float spawnTimer = 0.0f;
        public float spawnCooldown = 6.0f;
        public void LoadGame(Scene scene)
        {
            scene.GameLost = false;
            scene.Spawn(new Background());
            scene.Spawn(new Player());
            scene.Spawn(new Enemy());
            scene.Spawn(new Gui(new ScoreManager()));
        }

        public void Reload(Scene scene)
        {
            Console.WriteLine(scene.GameLost);
            if (scene.GameLost)
            {
                scene.entities.Clear();
                scene.Spawn(new Background());
                scene.Spawn(new Player());
                scene.Spawn(new Enemy());
                scene.Spawn(new Gui(new ScoreManager()));
            }
        }
        public void SpawnEnemies(Scene scene)
        {
            if (spawnTimer <= 0.0f)
            {
                Enemy enemy = new Enemy();
                scene.Spawn(enemy);
            }
        }

        public void Update(Scene scene, float deltaTime)
        {
            if (scene.GameLost)
            {
                Reload(scene);
            }
            //TODO: Figure out how to reload entites once through gamelost flag
        }
    }
}


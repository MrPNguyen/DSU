using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
   public sealed class Scene
    {
        public List<Entity> entities;
        public readonly AssetManager Assets;
        public readonly EventManager Events;
        public readonly SceneLoader Loader;
        public bool GameLost;
       
        public Scene(AssetManager assets, EventManager events, SceneLoader loader)
        {
            entities = new List<Entity>();
            Assets = assets;
            Events = events;
            Loader = loader;
            events.SpawnBullet += SpawnBullet; 
        }

        public void Spawn(Entity entity)
        {
            entities.Add(entity);
            entity.Create(this);
        }

        public void Clear()
        {
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                Entity entity = entities[i];
                if (!entity.DontDestroyOnLoad) 
                {
                    entities.RemoveAt(i);
                    entity.Destroy(this);
                }
            }
            
        }

        public void UpdateAll(Scene scene, float deltaTime)
        {
            Loader.spawnCooldown -= deltaTime;
            Loader.spawnRate -= deltaTime;
            if (Loader.spawnCooldown < 0)
            {
                Loader.spawnCooldown = 0;
            }

            if (Loader.spawnRate < 0)
            {
                Loader.spawnRate = 0;
            }
            Events.Update(this);
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                Entity entity = entities[i];
                entity.Update(this, deltaTime);
            }
            Loader.SpawnEnemies(scene);
            Loader.Reload(scene);
            Loader.IncreaseSpawnRate();
        }

        public void RenderAll(RenderTarget target)
        {
            for (int i = 0; i < entities.Count;)
            {
                Entity entity = entities[i];
                if (entity.Dead) entities.RemoveAt(i);
                else i++;
                entity.Render(target);
            }
        }
      
        public bool FindByType<T>(out T found) where T : Entity
        {
            foreach (Entity entity in entities)
            {
                if (!entity.Dead && entity is T typed)
                {
                    found = typed;
                    return true;
                }
            }

            found = default(T);
            return false;
        }
        public IEnumerable<Entity> FindIntersects(FloatRect bounds)
        {
            int lastEntity = entities.Count - 1;
            for (int i = lastEntity; i >= 0; i--)
            {
                Entity entity = entities[i];
                if (entity.Dead) continue;
                if (entity.Bounds.Intersects(bounds))
                {
                    yield return entity;
                }
            }
        }

        private void SpawnBullet(Vector2f pos, float Y, Scene scene)
        {
            if (Y == -1)
            {
                pos.X += 1.0f;
                Bullet bullet1 = new Bullet(pos, Y);
                Spawn(bullet1);
                
                pos.X -= 35.0f;
                Bullet bullet2 = new Bullet(pos, Y);
                Spawn(bullet2);
            }
            else if (Y == 1)
            {
                pos.X += 19.0f;
                Bullet bullet = new Bullet(pos, Y);
                Spawn(bullet);
            }
        }
    }
}



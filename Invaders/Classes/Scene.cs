using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Scene
    {
        private Dictionary<string, Texture> textures;
        public List<Entity> entities;
        public string nextScene;
        public string currentScene;
        public Entity entity;
        public Text gui;
        public Scene()
        {
            textures = new Dictionary<string, Texture>();
            entities = new List<Entity>();
            gui = new Text();
            gui.CharacterSize = 24;
            gui.Font = new Font("assets/PressStart2P.ttf");
        }

        public void Spawn(Entity entity)
        {
            entities.Add(entity);
            entity.Create(this);
        }
        public Texture LoadTexture(string name)
        {
            if (textures.TryGetValue(name, out Texture found)) {
                return found;
            }
            string fileName = $"assets/{name}.png";
            Texture texture = new Texture(fileName);
            textures.Add(name, texture);
            return texture;
        }

        public void UpdateAll(float deltaTime)
        {
            HandleSceneChange();
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                Entity entity = entities[i];
                entity.Update(this, deltaTime);
            }
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
            gui.DisplayedString = "Score:";
            gui.Position = new Vector2f(15, 25);
            target.Draw(gui);
        }

        public bool TryMove(Entity entity, Vector2f movement)
        {
            entity.Position += movement;
            bool collided = false;
            for (int i = 0; i < entities.Count; i++)
            {
                Entity other = entities[i];
                if (!other.Solid) continue;
                if (other == entity) continue;
                FloatRect boundsA = entity.Bounds;
                FloatRect boundsB = other.Bounds;
                if (Collision.RectangleRectangle(boundsA, boundsB,
                        out Collision.Hit hit))
                {
                    entity.Position += hit.Normal * hit.Overlap;
                    i = -1; // Check everything once again
                    collided = true;
                }
            }
            return collided;
        }
        
        public void Reload()
        {
            nextScene = currentScene;
        }

        public void Load(string name)
        {
            nextScene = name;
        }

        
        private void HandleSceneChange()
        {
            if (nextScene == null) return;
            entities.Clear();
            string file = $"assets/{nextScene}.txt";
            //Console.WriteLine($"Loading scene '{file}'");
            foreach (var line in File.ReadLines(file, Encoding.UTF8))
            {
                string parsed = line.Trim();
                int commentAt = parsed.IndexOf('#');
                if (commentAt >= 0)
                {
                    parsed = parsed.Substring(0, commentAt);
                    parsed = parsed.Trim();
                }
                if (parsed.Length == 0)
                {
                    continue;
                }
                string[] words = parsed.Split(" ");
                
                switch (words[0])
                {
                    case "h":
                        Spawn(new Player() {Position = new Vector2f(int.Parse(words[1]), int.Parse(words[2])) });
                        break;
                    /*case "k":
                        Spawn(new Key() {Position = new Vector2f(int.Parse(words[1]), int.Parse(words[2])) });
                        break;
                    case "h":
                        Spawn(new Hero() {Position = new Vector2f(int.Parse(words[1]), int.Parse(words[2])) });
                        break;
                    case "d":
                        Spawn(new Door() { Position = new Vector2f(int.Parse(words[1]), int.Parse(words[2])), 
                            NextRoom = words[3]});
                        break;
                    case "c":
                        Spawn(new Coin(){Position = new Vector2f(int.Parse(words[1]), int.Parse(words[2])) });
                        break;
                    case "b":
                        Spawn(new DesBlock(){Position = new Vector2f(int.Parse(words[1]), int.Parse(words[2])) });
                        break;
                        */
                }
                
            }
            currentScene = nextScene;
            nextScene = null;
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
    }
}



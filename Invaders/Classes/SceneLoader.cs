using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Text;
using Invaders.Classes;

namespace Invaders.Assets
{
    public class SceneLoader
    {
        public readonly Dictionary<char, Func<Entity>> loaders;
        private string currentScene = "", nextScene = "";
        
        private bool Create(char symbol, out Entity created) 
        {
            if (loaders.TryGetValue(symbol, out Func<Entity> loader)) 
            {
                created = loader();
                return true;
            }
            created = null;
            return false;
        }
    
        public void HandleSceneLoad(Scene scene) 
        {
            if (nextScene == "") return;
            scene.entities.Clear(); 
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
                    case "w":
                        scene.Spawn(new Player() {Position = new Vector2f(int.Parse(words[1]), int.Parse(words[2])) });
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
    
        public void Load(string scene) => nextScene = scene;
        public void Reload() => nextScene = currentScene;
    
    }
}


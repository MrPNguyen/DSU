using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes
{
    public sealed class Background : Entity
    {
       
        private const float ScrollSpeed = 200f;
        private Vector2f spawn;
        private Sound music;
        public Background(Vector2f Spawn, string TextureName, string folder) : base(TextureName, folder)
        {
            sprite.TextureRect = new IntRect(0, 0, 4096, 4096);
            sprite.Scale = new Vector2f(0.2f, 0.2f);
            spawn = Spawn;
            sprite.Position = spawn;
            
        }

        public override void Create(Scene scene)
        {
            base.Create(scene);
            music = new Sound(scene.Assets.LoadMusic("boss", "sounds"));
            music.Play();
            music.Volume = 30f;
            music.Loop = true;
        }

        public override void Destroy(Scene scene)
        {
            base.Destroy(scene);
            music.Stop();
            music.Dispose();
        }

        public override void Update(Scene scene, float deltaTime)
        {
            if (!scene.GameLost)
            {
                sprite.Position += new Vector2f(0, ScrollSpeed * deltaTime);
          
                if (sprite.Position.Y >= 800)
                {
                    sprite.Position -= new Vector2f(0, 800*2);
                }
            }
        }
    }
}


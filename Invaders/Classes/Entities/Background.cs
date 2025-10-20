using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes
{
    public class Background : Entity
    {
        //Background image source: https://dinvstudio.itch.io/dynamic-space-background-lite-free
        //Credit to DinVStudio
        //Music source: https://opengameart.org/content/kind-of-boss
        //Credit to G_P, song name: Kind Of Boss
        public const float ScrollSpeed = 100f;
        public Vector2f spawn;
        private SoundBuffer sound;
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
            sound = new SoundBuffer( scene.Assets.LoadMusic("boss", "sounds"));
            music = new Sound(sound);
            music.Play();
            music.Volume = 40f;
            music.Loop = true;
        }

        public override void Destroy(Scene scene)
        {
            base.Destroy(scene);
            music.Stop();
            music.Dispose();
            sound.Dispose();
        }

        public override void Update(Scene scene, float deltaTime)
        {
            sprite.Position += new Vector2f(0, ScrollSpeed * deltaTime);
          
            if (sprite.Position.Y >= 800)
            {
                sprite.Position -= new Vector2f(0, 800*2);
            }
        }
    }
}


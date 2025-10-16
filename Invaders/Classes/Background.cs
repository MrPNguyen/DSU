using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes
{
    public class Background : Entity
    {
        public const float ScrollSpeed = 100f;
        public Vector2f spawn;
        public Background(Vector2f Spawn, string TextureName) : base(TextureName)
        {
            sprite.TextureRect = new IntRect(0, 0, 4096, 4096);
            sprite.Scale = new Vector2f(0.2f, 0.2f);
            spawn = Spawn;
            sprite.Position = spawn;
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


using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes
{
    public class Background : Entity
    {
        public const float ScrollSpeed = 100f;
        public Background() : base("Nebula")
        {
            sprite.TextureRect = new IntRect(0, 0, 7000, 7000);
            sprite.Scale = new Vector2f(0.2f, 0.2f);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            sprite.Position += new Vector2f(0, ScrollSpeed * deltaTime);
        }
    }
}


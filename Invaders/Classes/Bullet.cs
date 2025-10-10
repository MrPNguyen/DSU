using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Bullet : Actor
    {
        private const float BulletSpeed = 200f;
        public Bullet()
        {
            sprite.TextureRect = new IntRect(64, 0, 64, 64);
            sprite.Origin = new Vector2f(9, 9);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            sprite.Position -= new Vector2f(0, BulletSpeed * deltaTime);

            if (sprite.Position.Y < -5)
            {
                Dead = true;
            }
        }

      
    }
}


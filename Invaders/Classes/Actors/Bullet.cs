using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Bullet : Actor
    {
        
        public readonly Vector2f BulletDirection;
        public bool enemyShot;
        public readonly float Y;
        public const float BulletSpeed = 150f;
        public Bullet(Vector2f pos, float y)
        {
            sprite.TextureRect = new IntRect(64, 0, 64, 64);
            sprite.Origin = new Vector2f(9, 9);
            sprite.Scale = new Vector2f(0.7f, 0.7f);
            sprite.Position = pos;
            Y = y;
        }
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            Vector2f newPos = sprite.Position;
            newPos.Y += Y * BulletSpeed * deltaTime;
            sprite.Position = newPos;
            if (Y == 1)
            {
                sprite.Rotation = 180.0f;
            }
        }
        
    }
}


using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes
{
    public sealed class Bullet : Actor
    {
        public readonly float Y;
        public bool IsPlayerBullet;
        private const float BulletSpeed = 300f;
        public Bullet(Vector2f pos, float y, bool isPlayerBullet)
        {
            sprite.TextureRect = new IntRect(64, 0, 64, 64);
            sprite.Origin = new Vector2f(9, 9);
            sprite.Scale = new Vector2f(0.7f, 0.7f);
            sprite.Position = pos;
            Y = y;
            IsPlayerBullet = isPlayerBullet;
        }
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            newPos = sprite.Position;
            newPos.Y += Y * BulletSpeed * deltaTime;
            sprite.Position = newPos;
            if (IsPlayerBullet == false)
            {
                sprite.Rotation = 180.0f;
            }

            if (sprite.Position.Y <= 0 || sprite.Position.Y >= Program.ScreenH)
            {
                Dead = true;
            }
        }
        
    }
}


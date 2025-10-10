using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Bullet : Actor
    {
        
        public readonly Vector2f BulletDirection;
        public bool enemyShot;
        public bool bulletDiagonal;
        public bool DiagonalLeft;
        public Bullet()
        {
            sprite.TextureRect = new IntRect(64, 0, 64, 64);
            sprite.Origin = new Vector2f(9, 9);
            sprite.Scale = new Vector2f(0.7f, 0.7f);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            
        }
        


    }
}


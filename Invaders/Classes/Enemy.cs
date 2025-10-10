using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Enemy : Actor
    {
        public const float EnemySpeed = 100.0f;
        public Vector2f size;
        private Random rand;
        private float spawnPoint;
        public Vector2f direction = new Vector2f(1, 1) / MathF.Sqrt(2.0f);
        
        public Enemy()
        {
            sprite.TextureRect = new IntRect(128,128, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
            rand = new Random();
        }
        public override void Create(Scene scene)
        {
            base.Create(scene);
            spawnPoint = rand.Next(0, 500);
            sprite.Position = new Vector2f(spawnPoint, -15);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            Vector2f newPos = sprite.Position;
            newPos += direction * deltaTime * 100.0f; 
        
            newPos += direction * deltaTime * 100.0f;
            
            float halfWidth = size.X / 2; //splittra center för att göra hitbox "större"
            if (newPos.X > Program.ScreenW - halfWidth) //Right side
            {
                newPos.X = Program.ScreenW - halfWidth;
                Reflect(new Vector2f(-1, 0));
            }

            if (newPos.X < halfWidth) //Left side
            {
                newPos.X = halfWidth;
                Reflect(new Vector2f(1, 0));
            }

            if (newPos.Y > Program.ScreenH - halfWidth) //Bottom
            {
                newPos.X = Program.ScreenH - halfWidth;
                return;
            }
            sprite.Position = newPos;
        }
        
        public void Reflect(Vector2f normal)
        {
            direction -= normal * (2 * (
                direction.X * normal.X +
                direction.Y * normal.Y
            ));
        }
    }
}


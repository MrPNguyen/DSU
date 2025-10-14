using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Enemy : Actor
    {
        public const float EnemySpeed = 50.0f;
        public Vector2f size;
        private Random rand;
        private float spawnPoint;
        public Vector2f direction = new Vector2f(1, 1) / MathF.Sqrt(EnemySpeed);
        private Vector2f SpawnPos;
        private float ShotTimer;
        private float ShotDuration;
        public float ShotCooldown = 0f;
        public const float BulletSpeed = 200f;
        public Enemy()
        {
            sprite.TextureRect = new IntRect(320,256, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
            rand = new Random();
            sprite.Scale = new Vector2f(0.7f, 0.7f);
            sprite.Rotation = 180.0f;
        }
        public override void Create(Scene scene)
        {
            base.Create(scene);
            spawnPoint = rand.Next(0, 500);
            SpawnPos = sprite.Position = new Vector2f(spawnPoint, -15);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            ShotCooldown -= deltaTime;
            if (ShotCooldown < 0)
            {
                ShotCooldown = 0;
            }
            Vector2f newPos = sprite.Position;
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
                sprite.Position = SpawnPos;
                return;
            }
            sprite.Position = newPos;
            if (ShotCooldown == 0)
            {
                
                scene.Events.PublishSpawnBullet(newPos, 1, scene);
                if (ShotCooldown > 0)
                {
                    return;
                }
                ShotCooldown = 2.0f;
            }
        }
        
        public void Reflect(Vector2f normal)
        {
            direction -= normal * (2 * (
                direction.X * normal.X +
                direction.Y * normal.Y
            ));
        }

        protected override void CollideWith(Scene scene, Entity e)
        {
            if (e is Bullet bullet &&  bullet.Y == -1)
            {
                Console.WriteLine("!");
                Dead = true;
                scene.Events.PublishGainScore(100, scene);
                bullet.Dead = true;
            }
        }
    }
}


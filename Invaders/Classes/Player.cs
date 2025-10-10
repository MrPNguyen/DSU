using System.Numerics;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Player : Actor
    {
        public const float FlyingSpeed = 100.0f;
        public float ShotCooldown = 0f;
        public const float BulletSpeed = 150f;
        public Vector2f size;
        public int dir;
        

        public Player()
        {
            sprite.TextureRect = new IntRect(192, 128, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
        }

        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.Position = new Vector2f(230, 570);
        }
        
        public override void Update(Scene scene, float deltaTime)
        {
            ShotCooldown -= deltaTime;
            if (ShotCooldown < 0)
            {
                ShotCooldown = 0;
            }
            var newPos = sprite.Position;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                newPos.X += deltaTime * FlyingSpeed;
                sprite.Rotation = 45.0F;
                dir = 0;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A)  || Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                newPos.X -= deltaTime * FlyingSpeed;
                sprite.Rotation = -45.0F;
                dir = 1;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)  || Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                newPos.Y -= deltaTime * FlyingSpeed;
                sprite.Rotation = 360.0F;
                dir = 2;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)  || Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                newPos.Y += deltaTime * FlyingSpeed;
                sprite.Rotation = 180.0F;
                dir = 3;
            }

            float halfWidth = size.X / 2; //splittra center för att göra hitbox "större"

            if (newPos.X >= Program.ScreenW - halfWidth)
            {
                newPos.X = Program.ScreenW - halfWidth;
            }

            if (newPos.X <= halfWidth)
            {
                newPos.X = halfWidth;
            }
            if (newPos.Y >= Program.ScreenH - halfWidth)
            {
                newPos.Y = Program.ScreenH - halfWidth;
            }

            if (newPos.Y <= halfWidth)
            {
                newPos.Y = halfWidth;
            }
            sprite.Position = newPos;
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            {
                if (ShotCooldown == 0)
                {
                    Shoot(scene, deltaTime);
                }
            }
        }
        public void Shoot(Scene scene, float deltaTime)
        {
            if (ShotCooldown > 0)
            {
                return;
            }
            
            ShotCooldown = 0.5f;
        }
    }
}


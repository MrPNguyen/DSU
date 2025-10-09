using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Player : Entity
    {
        public const float WalkSpeed = 100.0f;
        public const float Diameter = 20.0f;
        public const float Radius = Diameter * 0.5f;
        public Vector2f size;

        public Player() : base("tileset")
        {
            sprite.TextureRect = new IntRect(192, 128, 64, 64);
            sprite.Origin = new Vector2f(9, 9);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            var newPos = sprite.Position;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                scene.TryMove(this, new Vector2f(WalkSpeed * deltaTime, 0));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                scene.TryMove(this, new Vector2f(-WalkSpeed * deltaTime, 0));
            }
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                scene.TryMove(this, new Vector2f(0, -WalkSpeed * deltaTime));
            }
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                scene.TryMove(this, new Vector2f(0 , WalkSpeed * deltaTime));
            }
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            {
                
            }
            
            if (newPos.X > Program.ScreenW - Radius - 50)
            {
                newPos.X = Program.ScreenW - Radius;
            }

            if (newPos.X < Radius)
            {
                newPos.X = Radius;
            }

        }
    }
}


using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Player : Entity
    {
        public const float WalkSpeed = 100.0f;
        public Player() : base("tileset")
        {
            sprite.TextureRect = new IntRect(192, 128, 64, 64);
            sprite.Origin = new Vector2f(9, 9);
            sprite.Position = new Vector2f(192, 128);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            var newPos = sprite.Position;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                newPos.X += deltaTime * 300.0f;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A)  || Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                newPos.X -= deltaTime * 300.0f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)  || Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                newPos.Y = deltaTime * 300.0f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)  || Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                newPos.Y -= deltaTime * 300.0f;
            }
        }

        public void Draw(RenderTarget target)
        {
            target.Draw(sprite);
        }
    }
}


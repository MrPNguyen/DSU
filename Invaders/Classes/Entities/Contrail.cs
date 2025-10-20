using System.Numerics;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Invaders.Classes
{
    public class Contrail : Entity
    {
        private Actor FollowTarget;
        
        public Contrail(Actor followTarget) : base("tileset", "tilesets")
        {
            sprite.TextureRect = new IntRect(384, 320, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            FollowTarget = followTarget;
        }
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            if (FollowTarget.isPlayer)
            {
                if (FollowTarget.direction == 0)
                {
                    sprite.Rotation = 45.0f;
                    sprite.Position = new Vector2f(FollowTarget.Position.X - 28.0f, FollowTarget.Position.Y + 30.0f);
                }
                else if (FollowTarget.direction == 1)
                {
                    sprite.Rotation = -45.0f;
                    sprite.Position = new Vector2f(FollowTarget.Position.X + 28.0f, FollowTarget.Position.Y + 30.0f);
                }
                else if (FollowTarget.direction == 2)
                {
                    sprite.Rotation = 360.0f;
                    sprite.Position = new Vector2f(FollowTarget.Position.X, FollowTarget.Position.Y + 40.0f);

                }
                else if (FollowTarget.direction == 3)
                {
                    sprite.Rotation = 180.0f;
                    sprite.Position = new Vector2f(FollowTarget.Position.X, FollowTarget.Position.Y - 40.0f);
                }
                else
                {
                    sprite.Rotation = 360.0f;
                    sprite.Position = new Vector2f(FollowTarget.Position.X, FollowTarget.Position.Y + 40.0f);

                }
            }
            else
            {
                sprite.Rotation = 180.0f;
                sprite.Position = new Vector2f(FollowTarget.Position.X, FollowTarget.Position.Y - 40.0f);
            }
            
        }
    }
}


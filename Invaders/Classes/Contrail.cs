using System.Numerics;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Invaders.Classes
{
    public class Contrail : Entity
    {
        private Vector2f Pos;
        private Vector2f CurrentPosition;
        public Vector2f newPos;
        public Contrail(Vector2f pos, Vector2f currentPosition) : base("tileset")
        {
            sprite.TextureRect = new IntRect(384, 320, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            Pos = pos;
            CurrentPosition = currentPosition;
        }

        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.Position = Pos;
        }

        public override void Update(Scene scene, float deltaTime)
        {
            
        }
    }
}


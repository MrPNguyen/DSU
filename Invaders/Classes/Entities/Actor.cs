using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Actor : Entity
    {
        
        protected float speed;
        protected bool moving;
        public int direction;
        public bool isPlayer;
        protected float ShotCooldown;
        protected Vector2f size;
        protected Vector2f newPos;
        public Contrail contrail;
       
        public Actor() : base("tileset", "tilesets")
        {
            
        }

        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            foreach (Entity found in scene.FindIntersects(Bounds)) 
            {
                CollideWith(scene, found);
            }
        }

        protected virtual void CollideWith(Scene s, Entity other) {}
    }
}
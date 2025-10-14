using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Actor : Entity
    {
        protected int direction;
       
        protected Actor() : base("tileset")
        {
        
        }

        protected void Reset()
        {
            //TODO: scene.entities.clear(of type enemy)
            //TOOD: player originalposition
            //TODO: score == 0;
            //TODO: health == 3;
        }
        protected static Vector2f ToVector(int dir) 
        {
            switch (dir)    
            {
                case 0: return new Vector2f(1, 1);
                case 1: return new Vector2f(-1, -1);
            }
            return new Vector2f(0, 0);
        }
        protected bool IsFree(Scene scene, int dir)
        {
            Vector2f at = Position + new Vector2f(9, 9);
            at += 18* ToVector(dir);
            FloatRect rect = new FloatRect(at.X, at.Y, 1, 1);
            return !scene.FindIntersects(rect).Any(e => e.Solid);
        }
        protected virtual int PickDirection(Scene scene) { return 0; }

        public void ApplyHit()
        {
            
        }

        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            direction = PickDirection(scene);
        }
        
       
    }
}


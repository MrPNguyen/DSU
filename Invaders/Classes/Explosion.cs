using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Explosion : Entity
    {
        private static int tileSize = 256;
        public Vector2f size;
        private List<IntRect> explosions = new List<IntRect>()
        {
            new IntRect(0, 0, tileSize, tileSize),
            new IntRect(1*tileSize, 0, tileSize, tileSize),
            new IntRect(2*tileSize, 0, tileSize, tileSize),
            new IntRect(3*tileSize, 0, tileSize, tileSize),
            new IntRect(4*tileSize, 0, tileSize, tileSize),
            new IntRect(5*tileSize, 0, tileSize, tileSize),
            new IntRect(6*tileSize, 0, tileSize, tileSize),
            new IntRect(7*tileSize, 0, tileSize, tileSize),
            new IntRect(0, 1, tileSize, tileSize),
            new IntRect(1*tileSize, 1*tileSize, tileSize, tileSize),
            new IntRect(2*tileSize, 1*tileSize, tileSize, tileSize),
            new IntRect(3*tileSize, 1*tileSize, tileSize, tileSize),
            new IntRect(4*tileSize, 1*tileSize, tileSize, tileSize),
            new IntRect(5*tileSize, 1*tileSize, tileSize, tileSize),
            new IntRect(6*tileSize, 1*tileSize, tileSize, tileSize),
            new IntRect(7*tileSize, 1*tileSize, tileSize, tileSize),
            new IntRect(0, 2*tileSize, tileSize, tileSize),
            new IntRect(1*tileSize, 2*tileSize, tileSize, tileSize),
            new IntRect(2*tileSize, 2*tileSize, tileSize, tileSize),
            new IntRect(3*tileSize, 2*tileSize, tileSize, tileSize),
            new IntRect(4*tileSize, 2*tileSize, tileSize, tileSize),
            new IntRect(5*tileSize, 2*tileSize, tileSize, tileSize),
            new IntRect(6*tileSize, 2*tileSize, tileSize, tileSize),
            new IntRect(7*tileSize, 2*tileSize, tileSize, tileSize),
            new IntRect(0, 3*tileSize, tileSize, tileSize),
            new IntRect(1*tileSize, 3*tileSize, tileSize, tileSize),
            new IntRect(2*tileSize, 3*tileSize, tileSize, tileSize),
            new IntRect(3*tileSize, 3*tileSize, tileSize, tileSize),
            new IntRect(4*tileSize, 3*tileSize, tileSize, tileSize),
            new IntRect(5*tileSize, 3*tileSize, tileSize, tileSize),
            new IntRect(6*tileSize, 3*tileSize, tileSize, tileSize),
            new IntRect(7*tileSize, 3*tileSize, tileSize, tileSize),
            new IntRect(0, 4*tileSize, tileSize, tileSize),
            new IntRect(1*tileSize, 4*tileSize, tileSize, tileSize),
            new IntRect(2*tileSize, 4*tileSize, tileSize, tileSize),
            new IntRect(3*tileSize, 4*tileSize, tileSize, tileSize),
            new IntRect(4*tileSize, 4*tileSize, tileSize, tileSize),
            new IntRect(5*tileSize, 4*tileSize, tileSize, tileSize),
            new IntRect(6*tileSize, 4*tileSize, tileSize, tileSize),
            new IntRect(7*tileSize, 4*tileSize, tileSize, tileSize),
            new IntRect(0, 5*tileSize, tileSize, tileSize),
            new IntRect(1*tileSize, 5*tileSize, tileSize, tileSize),
            new IntRect(2*tileSize, 5*tileSize, tileSize, tileSize),
            new IntRect(3*tileSize, 5*tileSize, tileSize, tileSize),
            new IntRect(4*tileSize, 5*tileSize, tileSize, tileSize),
            new IntRect(5*tileSize, 5*tileSize, tileSize, tileSize),
            new IntRect(6*tileSize, 5*tileSize, tileSize, tileSize),
            new IntRect(7*tileSize, 5*tileSize, tileSize, tileSize),
            new IntRect(0, 6*tileSize, tileSize, tileSize),
            new IntRect(1*tileSize, 6*tileSize, tileSize, tileSize),
            new IntRect(2*tileSize, 6*tileSize, tileSize, tileSize),
            new IntRect(3*tileSize, 6*tileSize, tileSize, tileSize),
            new IntRect(4*tileSize, 6*tileSize, tileSize, tileSize),
            new IntRect(5*tileSize, 6*tileSize, tileSize, tileSize),
            new IntRect(6*tileSize, 6*tileSize, tileSize, tileSize),
            new IntRect(7*tileSize, 6*tileSize, tileSize, tileSize),
            new IntRect(0, 5*tileSize, tileSize, tileSize),
            new IntRect(1*tileSize, 7*tileSize, tileSize, tileSize),
            new IntRect(2*tileSize, 7*tileSize, tileSize, tileSize),
            new IntRect(3*tileSize, 7*tileSize, tileSize, tileSize),
            new IntRect(4*tileSize, 7*tileSize, tileSize, tileSize),
            new IntRect(5*tileSize, 7*tileSize, tileSize, tileSize),
            new IntRect(6*tileSize, 7*tileSize, tileSize, tileSize),
            new IntRect(7*tileSize, 7*tileSize, tileSize, tileSize),
            
            
        };
        private Clock animationClock;
        private Vector2f SpawnPoint;
        private int Frame = 0;
        private bool AnimationDone = false;
        public Explosion(Vector2f spawnPoint) : base("explosion")
        {
            sprite.TextureRect = explosions[0];
            sprite.Position = spawnPoint;
            animationClock = new Clock();
            sprite.Scale = new Vector2f(0.5f, 0.5f);
        }


        public override void Update(Scene scene, float deltaTime)
        {
            if (animationClock.ElapsedTime.AsSeconds() >= 0.03f)
            {
                Frame++;
                animationClock.Restart();

                if (Frame < explosions.Count)
                {
                    sprite.TextureRect = explosions[Frame];
                }
                else
                {
                    AnimationDone = true;
                    scene.entities.Remove(this);
                }
            }
        }
    }
}


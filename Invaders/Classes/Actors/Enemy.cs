using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Enemy : Actor
    {
        private Vector2f size;
        private Random rand;
        private float spawnPoint;
        public Vector2f direction = new Vector2f(1, 1) / MathF.Sqrt(2.0f);
        private Vector2f SpawnPos;
        public float ShotCooldown = 0f;
        private Explosion explosion;
        private Vector2f newPos;
        private Contrail contrail;
        private int Direction = 2;

        public Enemy()
        {
            sprite.TextureRect = new IntRect(320,256, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
            rand = new Random();
            sprite.Scale = new Vector2f(0.7f, 0.7f);
            sprite.Rotation = 180.0f;
            speed = 30.0f;
            explosion = new Explosion(newPos);
            contrail = new Contrail(this);
            isPlayer = false;
            Zindex = 1;
            moving = true;
        }
        public override void Create(Scene scene)
        {
            base.Create(scene);
            moving = true;
            spawnPoint = rand.Next(0, 500);
            SpawnPos = sprite.Position = new Vector2f(spawnPoint, -15);
            scene.Spawn(contrail);
        }

        public override void Update(Scene scene, float deltaTime)
        {
            if (moving)
            {
                base.Update(scene, deltaTime);
                ShotCooldown -= deltaTime;
                if (ShotCooldown < 0)
                {
                    ShotCooldown = 0;
                }
                newPos = sprite.Position;
                newPos += direction * deltaTime * speed; 
            
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
                    //Sound Source: https://kenney.nl/assets/sci-fi-sounds
                    //Credit: CC0
                    SoundBuffer sound = new SoundBuffer( scene.Assets.LoadSound("PlayerShot", "sounds"));
                    Sound shot =  new Sound(sound);
                    shot.Play();
                    if (ShotCooldown > 0)
                    {
                        return;
                    }
                    ShotCooldown = 2.0f;
                }
            }
            if (scene.PauseActive)
            {
                moving = false;
            }
            else
            {
                moving = true;
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
                Dead = true;
                contrail.Dead = true;
                scene.Events.PublishGainScore(100, scene);
                bullet.Dead = true;
                Explosion explosion = new Explosion(new Vector2f(sprite.Position.X-50f, sprite.Position.Y-25));
                scene.Spawn(explosion);
            }
        }
    }
}


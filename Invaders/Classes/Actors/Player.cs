using System.Numerics;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Player : Actor
    {
        public float ShotCooldown = 0f;
        public Vector2f size;
        private bool isInvulnerable= false;
        private float invulnerableTimer = 0.0f;
        private const float invulnerableDuration = 2.0f; // 4 seconds
        public Color normalColor;
        public Vector2f PlayerSpawn;
        public bool ableToShoot;
        private Vector2f newPos;
        private Contrail contrail;
        public Player()
        {
            sprite.TextureRect = new IntRect(192, 128, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            PlayerSpawn = new Vector2f(230, 570);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
            normalColor = sprite.Color;
            speed = 100.0f;
            newPos = new Vector2f();
            contrail = new Contrail(this);
            Zindex = 1;
            isPlayer = true;
        }

        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.Position = PlayerSpawn;
            scene.Spawn(contrail);
        }
        
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            ShotCooldown -= deltaTime;
            if (isInvulnerable)
            {
                invulnerableTimer -= deltaTime;
                if (invulnerableTimer <= 0)
                {
                    sprite.Color = normalColor;
                    isInvulnerable = false;
                }
            }
            if (ShotCooldown < 0)
            {
                ShotCooldown = 0;
            }
            newPos = sprite.Position;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                newPos.X += deltaTime * speed;
                sprite.Rotation = 45.0f;
                ableToShoot = false;
                moving = true;
                direction = 0;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A)  || Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                newPos.X -= deltaTime * speed;
                sprite.Rotation = -45.0f;
                ableToShoot = false;
                moving = true;
                direction = 1;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.W)  || Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                newPos.Y -= deltaTime * speed;
                sprite.Rotation = 360.0f;
                ableToShoot = true;
                direction = 2;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S)  || Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                newPos.Y += deltaTime * speed;
                sprite.Rotation = 180.0f;
                ableToShoot = false;
                direction = 3;
            }
            else
            {
                sprite.Rotation = 360.0f;
                moving = false;
                direction = 2;
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
                if (ableToShoot)
                {
                    if (ShotCooldown == 0)
                    {
                        scene.Events.PublishSpawnBullet(newPos, -1, scene);
                        if (ShotCooldown > 0)
                        {
                            return;
                        }
                        ShotCooldown = 0.5f;
                    }
                }
            }
        }
        
        protected override void CollideWith(Scene scene, Entity e)
        {
            if (isInvulnerable)
            {
                sprite.Color = new Color(100, 100, 100);
            }
            
            if (e is Bullet bullet &&  bullet.Y == 1 && isInvulnerable == false)
            {
                scene.Events.PublishLoseHealth(1, scene);
                bullet.Dead = true;
                isInvulnerable = true;
                invulnerableTimer = invulnerableDuration;
            }
            else if (e is Enemy enemy && isInvulnerable == false)
            {
                scene.Events.PublishLoseHealth(1, scene);
                enemy.Dead = true;
                isInvulnerable = true;
                invulnerableTimer = invulnerableDuration;
            }
        }
        
    }
}


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
        public Vector2f size;
        private bool isInvulnerable= false;
        private float invulnerableTimer = 0.0f;
        private const float invulnerableDuration = 2.0f; // 4 seconds
        public Color normalColor;
        public Sprite Contrail;
        public Vector2f PlayerSpawn;
        public bool ableToShoot;
        public Player()
        {
            sprite.TextureRect = new IntRect(192, 128, 64, 64);
            sprite.Origin = new Vector2f(32, 32);
            PlayerSpawn = new Vector2f(230, 570);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
            normalColor = sprite.Color;
            Contrail = new Sprite();
            Contrail.TextureRect = new IntRect(384, 384, 64, 64);
        }

        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.Position = PlayerSpawn;
            originalPosition = PlayerSpawn;
            if (scene.LoseGame)
            {
                sprite.Position = PlayerSpawn;
            }
            // TODO: CONTRAIL
        }
        
        public override void Destroy(Scene scene)
        {
            base.Destroy(scene);
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
            Vector2f newPos = sprite.Position;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                newPos.X += deltaTime * FlyingSpeed;
                sprite.Rotation = 45.0f;
                ableToShoot = false;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A)  || Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                newPos.X -= deltaTime * FlyingSpeed;
                sprite.Rotation = -45.0f;
                ableToShoot = false;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.W)  || Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                newPos.Y -= deltaTime * FlyingSpeed;
                sprite.Rotation = 360.0f;
                ableToShoot = true;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S)  || Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                newPos.Y += deltaTime * FlyingSpeed;
                sprite.Rotation = 180.0f;
                ableToShoot = false;
            }
            else
            {
                sprite.Rotation = 360.0f;
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


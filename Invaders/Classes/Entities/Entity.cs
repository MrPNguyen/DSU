using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;

namespace Invaders.Classes
{
    public class Entity
    {
        private readonly string textureName;
        private readonly string folder;
        protected readonly Sprite sprite;
        protected readonly Sound sounds;
        public bool Dead;
        public int Zindex;
        public virtual bool Solid => false;

        protected Entity(string textureName, string folder)
        {
            this.textureName = textureName;
            this.folder = folder;
            sprite = new Sprite();
            sounds = new Sound();
        }

        public Vector2f Position
        {
            get => sprite.Position;
            set => sprite.Position = value;
        }

        public virtual FloatRect Bounds => sprite.GetGlobalBounds();

        public virtual void Create(Scene scene)
        {
            sprite.Texture = scene.Assets.LoadTexture(textureName, folder);
        }
        public virtual void Destroy(Scene scene)
        {
        
        }
        
        public virtual void Update(Scene scene, float deltaTime)
        {
            
        }

        public virtual void Render(RenderTarget target)
        {
            if (!Dead)
            {
                target.Draw(sprite);
            }
        }
    }
}


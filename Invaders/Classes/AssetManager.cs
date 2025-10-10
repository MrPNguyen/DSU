using SFML.Audio;
using SFML.Graphics;

namespace Invaders.Classes
{
    public class AssetManager
    {
        public static readonly string AssetPath = "assets";
        private readonly Dictionary<string, Texture> textures;
        private readonly Dictionary<string, Font> fonts;
        private readonly Dictionary<string, SoundBuffer> sounds;

        public AssetManager()
        {
            textures = new Dictionary<string, Texture>();
            fonts = new Dictionary<string, Font>();
            sounds = new Dictionary<string, SoundBuffer>();
        }

        public Texture LoadTexture(string name)
        {
            if (textures.TryGetValue(name, out Texture found))
            {
                return found;
            }

            string fileName = $"assets/{name}.png";
            Texture texture = new Texture(fileName);
            textures.Add(name, texture);
            return texture;
        }

        public Font LoadFont(string name)
        {
            if (fonts.TryGetValue(name, out Font found))
            {
                return found;
            }

            string fileName = $"assets/{name}.ttf";
            Font font = new Font(fileName);
            fonts.Add(name, font);
            return font;
        }

        public SoundBuffer LoadSound(string name)
        {
            if (sounds.TryGetValue(name, out SoundBuffer found))
            {
                return found;
            }

            string fileName = $"assets/{name}.wav";
            SoundBuffer sound = new SoundBuffer(fileName);
            sounds.Add(name, sound);
            return sound;
        }
    }
}


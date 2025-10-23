using System.Drawing;
using SFML.Graphics;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace Invaders.Classes;

public class Menus : Entity
{
    protected Font font;
    protected List<Text> texts;

    public Menus(string textureName, string folder) : base(textureName, folder)
    {
        texts = new List<Text>();
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        font = scene.Assets.LoadFont("PressStart2P", "fonts");
    }
}
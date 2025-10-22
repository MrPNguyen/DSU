using System.Drawing;
using SFML.Graphics;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace Invaders.Classes;

public class Menus : Entity
{
    private string TextureName;
    private string Folder;
    public Font font;

    public Menus(string textureName, string folder) : base(textureName, folder)
    {
        TextureName = textureName;
        Folder = folder;
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        font = scene.Assets.LoadFont("PressStart2P", "fonts");
    }
}
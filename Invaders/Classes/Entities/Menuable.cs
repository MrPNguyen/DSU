using System.Drawing;
using SFML.Graphics;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace Invaders.Classes;

public class Menuable : Entity
{
    private string TextureName;
    private string Folder;
    public Font font;

    public Menuable(string textureName, string folder) : base(textureName, folder)
    {
        TextureName = textureName;
        Folder = folder;
    }
}
using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class NameMenu : Menuable
{
    private Texture texture;
    private Buttons Play;
    private Text questionText;
    private char Letter;
    private string name;
    private Text Name;
    public NameMenu(string textureName, string folder) : base(textureName, folder)
    {
        sprite.TextureRect = new IntRect(192, 128, 64, 64);
        sprite.Origin = new Vector2f(32, 32);
        sprite.Scale = new Vector2f(3f, 3f);
        Play = new Buttons("Play", new Vector2f(40, 500), "MainMenu", "PlayButton", new Vector2f(0.7f, 0.7f));
        questionText = new Text();
        Name = new Text();
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        sprite.Position = new Vector2f(100, 340);
        font = scene.Assets.LoadFont("PressStart2P", "fonts");
        
        questionText.Font = font;
        questionText.DisplayedString = "What Is Your Name?";
        questionText.CharacterSize = 25;
        questionText.OutlineColor = Color.Black;
        questionText.OutlineThickness = 2;
        questionText.Position = new Vector2f(30, 220);
        
        Name.Font = font;
        Name.CharacterSize = 25;
        Name.OutlineColor = Color.Black;
        Name.OutlineThickness = 2;
        Name.Position = new Vector2f(30, 260);
        Name.DisplayedString = Letter.ToString();
        
        scene.Spawn(Play);
    }
    public override void Render(RenderTarget target)
    {
        base.Render(target);
        target.Draw(questionText);
        target.Draw(Name);
    }
    
}
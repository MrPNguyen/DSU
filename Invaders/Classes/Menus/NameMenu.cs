using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes;

public class NameMenu : Menus
{
    private Buttons Play;
    private Buttons Back;
    private Text questionText;
    private Text Name;
    private Text Underscore;
    public NameMenu(string textureName, string folder) : base(textureName, folder)
    {
        sprite.TextureRect = new IntRect(192, 128, 64, 64);
        sprite.Origin = new Vector2f(32, 32);
        sprite.Scale = new Vector2f(3f, 3f);
        Play = new Buttons("Play", new Vector2f(150, 450), "MainMenu", "PlayButton", new Vector2f(0.4f, 0.4f));
        Back = new Buttons("Back", new Vector2f(10, 600), "MainMenu", "BackButton", new Vector2f(0.4f, 0.4f));
        questionText = new Text();
        Name = new Text();
        Underscore = new Text();
        Program.window.KeyPressed += (sender, args) =>
        {
            if (args.Code >= Keyboard.Key.A && args.Code <= Keyboard.Key.Z)
            {
                Name.DisplayedString = args.Code.ToString();
            }
        };

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
        Name.CharacterSize = 40;
        Name.OutlineColor = Color.Black;
        Name.OutlineThickness = 2;
        Name.DisplayedString = "Name";
        Name.Position = new Vector2f(200, 330);
        
        Underscore.Font = font;
        Underscore.CharacterSize = 40;
        Underscore.OutlineColor = Color.Black;
        Underscore.OutlineThickness = 2;
        Underscore.DisplayedString = "_______";
        Underscore.Position = new Vector2f(200, 340);
        
        scene.Spawn(Play);
        scene.Spawn(Back);
    }
    public override void Render(RenderTarget target)
    {
        base.Render(target);
        target.Draw(questionText);
        target.Draw(Name);
        target.Draw(Underscore);
    }

    public override void Update(Scene scene, float deltaTime)
    {
    }
    
}
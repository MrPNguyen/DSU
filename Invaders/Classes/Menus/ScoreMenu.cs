using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class ScoreMenu : Menus
{
    private Buttons Back;
    private ScoreManager score;

    public ScoreMenu(string textureName, string folder) : base(textureName, folder)
    {
        Back = new Buttons("Back", new Vector2f(10, 600), "MainMenu", "BackButton", new Vector2f(0.4f, 0.4f));
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        sprite.Position = new Vector2f(10, 100);
        sprite.Scale = new Vector2f(8f, 8f);
        sprite.Color = new Color(255, 255, 255, 20);
        
        scene.Spawn(Back);
        scene.Score.LoadhighScores();
    }
}
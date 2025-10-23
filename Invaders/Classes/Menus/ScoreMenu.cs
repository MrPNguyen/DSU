using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class ScoreMenu : Menus
{
    private Buttons Back;
    private Text allScores;
    private Text Title;

    public ScoreMenu(string textureName, string folder) : base(textureName, folder)
    {
        Back = new Buttons("Back", new Vector2f(10, 600), "MainMenu", "BackButton", new Vector2f(0.4f, 0.4f));
        allScores = new Text();
        Title = new Text();
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        
        Title.Font = font;
        Title.CharacterSize = 30;
        Title.OutlineColor = Color.Black;
        Title.OutlineThickness = 2;
        Title.Position = new Vector2f(90, 135);
        Title.DisplayedString = "High Scores";
        /*List<string> scores = scene.Score.LoadhighScores();
        foreach (string score in scores)
        {
            allScores.Font = font;
            allScores.CharacterSize = 25;
            allScores.OutlineColor = Color.Black;
            allScores.OutlineThickness = 2;
            allScores.Position = new Vector2f(32, 200);
            allScores.LineSpacing = 2;
            allScores.DisplayedString += $"{scene.Score.placement}. {score} \r\n";
            scene.Score.placement++;
        }*/
        
        sprite.Position = new Vector2f(10, 100);
        sprite.Scale = new Vector2f(8f, 8f);
        sprite.Color = new Color(255, 255, 255, 20);
        
        scene.Spawn(Back);
    }

    public override void Render(Scene scene, RenderTarget target)
    {
        base.Render(scene, target);
        target.Draw(allScores);
        target.Draw(Title);
    }
}
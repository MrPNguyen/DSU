using System.Drawing;
using SFML.Graphics;
using SFML.System;
using Color = SFML.Graphics.Color;

namespace Invaders.Classes;

public class PauseMenu : Menus
{
    //PauseMenu asset source: https://gummypopcat.itch.io/2d-ui-assets
    //Credit to gummypopcat
    private Buttons ExitButton;
    private Buttons ContinueButton;
    private Text pauseText;
    public PauseMenu(string textureName, string folder) :  base(textureName, folder)
    {
        Zindex = 1;
        ExitButton = new Buttons("Exit", new Vector2f(40, 400), "MainMenu", "ExitGame", new Vector2f(0.7f, 0.7f));
        ContinueButton = new Buttons("Resume", new Vector2f(40, 250), "MainMenu", "ResumeGame", new Vector2f(0.7f, 0.7f));
        pauseText = new Text();
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        sprite.Position = new Vector2f(10, 100);
        sprite.Scale = new Vector2f(8f, 8f);
        font = scene.Assets.LoadFont("PressStart2P", "fonts");
        
        pauseText.Font = font;
        pauseText.DisplayedString = "Game Paused";
        pauseText.CharacterSize = 40;
        pauseText.OutlineColor = Color.Black;
        pauseText.OutlineThickness = 2;
        pauseText.Position = new Vector2f(30, 130);
        
        scene.Spawn(ContinueButton);
        scene.Spawn(ExitButton);
    }

    public override void Render(Scene scene, RenderTarget target)
    {
        base.Render(scene, target);
        target.Draw(pauseText);
    }
    public override void Update(Scene scene, float deltaTime)
    {
        if (!scene.PauseActive)
        {
            Dead = true;
            ContinueButton.Dead = true;
            ExitButton.Dead = true;
        }
    }
}
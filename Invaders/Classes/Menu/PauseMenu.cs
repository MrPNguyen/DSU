using System.Drawing;
using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class PauseMenu : Entity
{
    //PauseMenu asset source: https://gummypopcat.itch.io/2d-ui-assets
    //Credit to gummypopcat
    private string TextureName;
    private Buttons ExitButton;
    private Buttons ContinueButton;
    private Actor actors;
    public PauseMenu(string textureName, string folder) :  base(textureName, folder)
    {
        TextureName = textureName;
        Zindex = 1;
        ExitButton = new Buttons("Exit", new Vector2f(40, 400), "MainMenu", "ExitGame", new Vector2f(0.7f, 0.7f));
        ContinueButton = new Buttons("Continue", new Vector2f(40, 250), "MainMenu", "ContinueGame", new Vector2f(0.7f, 0.7f));
        actors = new Actor();
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        sprite.Position = new Vector2f(10, 100);
        sprite.Scale = new Vector2f(8f, 8f);
        scene.Spawn(ContinueButton);
        scene.Spawn(ExitButton);
    }

    public override void Update(Scene scene, float deltaTime)
    {
        if (!scene.PauseActive)
        {
            scene.entities.Remove(this);
            scene.entities.Remove(ContinueButton);
            scene.entities.Remove(ExitButton);
        }
    }
}
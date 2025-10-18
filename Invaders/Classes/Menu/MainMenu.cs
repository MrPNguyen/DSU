using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class MainMenu : Entity
{
    public Vector2f direction = new Vector2f(1, 1) / MathF.Sqrt(2.0f);
    private Vector2f newPos;
    private float speed;
    private Vector2f size;
    private Buttons HighScoreButton;
    private Buttons NewGameButton;
    private Buttons QuitButton;

    public MainMenu() : base("Title", "MainMenu")
    {
        sprite.Origin = new Vector2f(2016, 1512);
        sprite.Scale = new Vector2f(0.1f, 0.1f);
        speed = 30.0f;
        size = new Vector2f(
            sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
        HighScoreButton = new Buttons("NewGameButton", new Vector2f(40, 250), "MainMenu", "NewGame", new Vector2f(0.7f, 0.7f));
        NewGameButton = new Buttons("HighScoresButton", new Vector2f(40, 400), "MainMenu", "HighScores", new Vector2f(0.7f, 0.7f));
        QuitButton = new Buttons("QuitButton", new Vector2f(40, 550), "MainMenu", "Quit", new Vector2f(0.7f, 0.7f));
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        sprite.Position = new Vector2f(250, 110);
        scene.Spawn(HighScoreButton);
        scene.Spawn(NewGameButton);
        scene.Spawn(QuitButton);

    }

    public override void Update(Scene scene, float deltaTime)
    {
        newPos = sprite.Position;
        newPos += direction * deltaTime * speed;
        int TopMargin = 65;
        int SideMargins = 230;
        int BottomMargin = 567;
        
        if (newPos.X > Program.ScreenW - SideMargins) //Right side
        {
            newPos.X = Program.ScreenW - SideMargins;
            Reflect(new Vector2f(1, 0));
                
        }

        if (newPos.X < SideMargins) //Left side
        {
            newPos.X = SideMargins;
            Reflect(new Vector2f(1, 0));
        }

        if (newPos.Y > Program.ScreenH - 567) //Bottom
        {
            newPos.Y = Program.ScreenH - 567;
            Reflect(new Vector2f(0, -1));
        }
        
        if (newPos.Y < TopMargin) //Top
        {
            newPos.Y = TopMargin;
            Reflect(new Vector2f(0, 1));
        }
        
        sprite.Position = newPos;
        HighScoreButton.Update(scene, deltaTime);
    }
    
    public void Reflect(Vector2f normal)
    {
        direction -= normal * (2 * (
            direction.X * normal.X +
            direction.Y * normal.Y
        ));
    }
}
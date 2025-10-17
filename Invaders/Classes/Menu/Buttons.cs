using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes;

public class Buttons : Entity
{
    private string TextureName;
    private Vector2f SpawnPosition;
    private GameState state;

    public Buttons(string textureName, Vector2f spawnPosition, string folder) : base(textureName, folder)
    {
        TextureName = textureName;
        SpawnPosition = spawnPosition;
        sprite.Scale = new Vector2f(0.7f, 0.7f);
        sprite.Position = SpawnPosition;
    }

    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        Vector2i mousePosition = Mouse.GetPosition(Program.window);
        if (sprite.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
        {
            sprite.Color = sprite.Color = new Color(100, 100, 100);
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Click();
            }
        }
        else
        {
            sprite.Color = Color.White;
        }
    }
    public void Click()
    {
        state = GameState.GAME;
        Console.WriteLine("Clicked");
    }
    
}
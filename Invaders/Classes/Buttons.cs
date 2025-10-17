using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes;

public class Buttons : Entity
{
    private string TextureName;
    private Vector2f SpawnPosition;
    private GameState state;

    public Buttons(string textureName, Vector2f spawnPosition) : base(textureName)
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
                state = GameState.GAME;
            }
        }
        else
        {
            sprite.Color = Color.White;
        }

      
        
    }
    public void CheckForMouse(RenderWindow window)
    {
        Mouse.GetPosition();
        //Get mouse position, when mouse reaches button images y and x position change image slightly to indicate hovering
        //Then get mouse.Click and if Click when in range change enum
    }
    
}
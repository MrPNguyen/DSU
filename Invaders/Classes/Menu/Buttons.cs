using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes;

public class Buttons : Entity
{
    private string TextureName;
    private Vector2f SpawnPosition;
    private GameState State;
    private string ButtonName;
    private Vector2f ButtonScale;

    public Buttons(string textureName, Vector2f spawnPosition, string folder, string buttonName, Vector2f buttonScale) : base(textureName, folder)
    {
        TextureName = textureName;
        SpawnPosition = spawnPosition;
        ButtonScale = buttonScale;
        ButtonName = buttonName;
        sprite.Position = SpawnPosition;
        sprite.Scale = ButtonScale;
        Zindex = 1;
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
                if (ButtonName == "NewGame")
                {
                    SceneManager.LoadScene(GameState.GAME);
                }
                else if (ButtonName == "HighScores")
                {
                    SceneManager.LoadScene(GameState.SCOREMENU);
                }
                else if (ButtonName == "Quit")
                {
                    SceneManager.LoadScene(GameState.QUIT);
                }
                else if (ButtonName == "ContinueGame")
                {
                    scene.PauseActive = false;
                }
                else if (ButtonName == "ExitGame")
                {
                    SceneManager.LoadScene(GameState.MAINMENU);
                }
                if (ButtonName == "PauseButton")
                {
                    if (Mouse.IsButtonPressed(Mouse.Button.Left) || Keyboard.IsKeyPressed(Keyboard.Key.Escape) && !scene.PauseActive)
                    {
                        scene.Spawn(new PauseMenu("PauseMenu", "MainMenu"));
                        scene.PauseActive = true;
                    }
                }
            }
        }
        else
        {
            sprite.Color = Color.White;
        }
    }
}
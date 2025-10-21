using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes;

public class Buttons : Menus
{
    //Buttons asset source: https://nectanebo.itch.io/menu-buttons
    //Credit to: Nectanebo 
    private string TextureName;
    private Vector2f SpawnPosition;
    private GameState State;
    public string ButtonName;
    private Vector2f ButtonScale;
    private bool isButtonPressed;

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
                    if (!isButtonPressed)
                    {
                        if (ButtonName == "NewGame")
                        {
                            SceneManager.LoadScene(GameState.NAMEMENU);
                            isButtonPressed = true;
                        }
                        else if (ButtonName == "HighScores")
                        {
                            SceneManager.LoadScene(GameState.SCOREMENU);
                            isButtonPressed = true;
                        }
                        else if (ButtonName == "Quit")
                        {
                            SceneManager.LoadScene(GameState.QUIT);
                            isButtonPressed = true;
                        }
                        else if (ButtonName == "ResumeGame")
                        {
                            scene.PauseActive = false;
                            isButtonPressed = true;
                        }
                        else if (ButtonName == "ExitGame")
                        {
                            SceneManager.LoadScene(GameState.MAINMENU);
                            isButtonPressed = true;
                        }
                        else if (ButtonName == "PlayAgainButton")
                        {
                            scene.ResetGame = true;
                            isButtonPressed = true;
                        }
                        else if (ButtonName == "BackButton")
                        {
                            SceneManager.LoadScene(GameState.MAINMENU);
                            isButtonPressed = true;
                        }
                        if (ButtonName == "PauseButton")
                        {
                            if (Mouse.IsButtonPressed(Mouse.Button.Left) || Keyboard.IsKeyPressed(Keyboard.Key.Escape) && !scene.PauseActive)
                            {
                                scene.Spawn(new PauseMenu("PauseMenu", "MainMenu"));
                                scene.PauseActive = true;
                                isButtonPressed = true;
                            }
                        }
                    }
                    else
                    {
                        isButtonPressed = false;
                    }
                }
        }
        else
        {
            sprite.Color = Color.White;

        }
    }
}
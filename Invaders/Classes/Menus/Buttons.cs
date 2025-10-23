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
    private string Folder;
    private Vector2f SpawnPosition;
    private GameState State;
    public string ButtonName;
    private Vector2f ButtonScale;
    private bool isButtonPressed;

    public Buttons(string textureName, Vector2f spawnPosition, string folder, string buttonName, Vector2f buttonScale) : base(textureName, folder)
    {
        TextureName = textureName;
        Folder = folder;
        SpawnPosition = spawnPosition;
        ButtonScale = buttonScale;
        ButtonName = buttonName;
        sprite.Position = SpawnPosition;
        sprite.Scale = ButtonScale;
        Zindex = 1;
        if (Mouse.IsButtonPressed(Mouse.Button.Left))
        {
            isButtonPressed = true;
        }
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
                        else if (ButtonName == "ResumeGame" ||  ButtonName == "PlaySquareButton")
                        {
                            scene.PauseActive = false;
                        }
                        else if (ButtonName == "ExitGame")
                        {
                            SceneManager.LoadScene(GameState.MAINMENU);
                        }
                        else if (ButtonName == "PlayAgainButton")
                        {
                           SceneManager.LoadScene(GameState.GAME);
                        }
                        else if (ButtonName == "BackButton")
                        {
                            SceneManager.LoadScene(GameState.MAINMENU);
                        }
                        if (ButtonName == "PauseButton")
                        {
                            if (Mouse.IsButtonPressed(Mouse.Button.Left) && !scene.PauseActive)
                            {
                                scene.Spawn(new PauseMenu("PauseMenu", "MainMenu"));
                                scene.PauseActive = true;
                            }
                        }
                    }

                    isButtonPressed = true;
                }
                else
                {
                    isButtonPressed = false;
                }
        }
        else
        {
            sprite.Color = Color.White;
        }
    }

    public void ChangePause(Scene scene, string textureName, string folder, string NewName)
    {
        sprite.Texture = scene.Assets.LoadTexture(textureName, folder);
        ButtonName = NewName;
    }
}
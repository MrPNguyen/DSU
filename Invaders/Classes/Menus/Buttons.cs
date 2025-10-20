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
    private string ButtonName;
    private Vector2f ButtonScale;
    private float ClickCooldown;
    private bool clicked = false;

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
        ClickCooldown -= deltaTime;
        if (ClickCooldown < 0)
        {
            ClickCooldown = 0;
        }
        Vector2i mousePosition = Mouse.GetPosition(Program.window);
        if (sprite.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
        {
            sprite.Color = sprite.Color = new Color(100, 100, 100);
           
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                        if (ButtonName == "NewGame")
                        {
                            SceneManager.LoadScene(GameState.NAMEMENU);
                        }
                        else if (ButtonName == "HighScores")
                        {
                            SceneManager.LoadScene(GameState.SCOREMENU);
                        }
                        else if (ButtonName == "Quit")
                        {
                            if (ClickCooldown == 0)
                            {
                                SceneManager.LoadScene(GameState.QUIT);
                                ClickCooldown = 0.2f;
                            }
                        }
                        else if (ButtonName == "ResumeGame")
                        {
                            scene.PauseActive = false;
                        }
                        else if (ButtonName == "ExitGame")
                        {
                            SceneManager.LoadScene(GameState.MAINMENU);
                        }
                        else if (ButtonName == "PlayButton")
                        {
                            SceneManager.LoadScene(GameState.GAME);
                        }
                        else if (ButtonName == "PlayAgainButton")
                        {
                            scene.Loader.Reload(scene);
                        }
                        else if (ButtonName == "BackButton")
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
                    Mouse.SetPosition(new Vector2i(950, 350));
                }
        }
        else
        {
            sprite.Color = Color.White;
        }
    }
}
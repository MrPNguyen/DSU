using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class GameOverMenu : Menus
{
    private Text GameOver;
    private Buttons NewGame;
    private Buttons Quit;
    private Text AskPlayAgain;
    private Text AskQuit;
    private Text YourScore;
    private ScoreManager Score;
    private Text highscoreText;
    
    public GameOverMenu(ScoreManager score) : base("PauseMenu", "MainMenu")
    {
        sprite.Color = new Color(0, 0, 0);
        NewGame = new Buttons("PlayAgainButton", new Vector2f(40, 450), "MainMenu", "PlayAgainButton", new Vector2f(0.3f, 0.3f));
        Quit = new Buttons("QuitButton", new Vector2f(270, 450), "MainMenu", "ExitGame", new Vector2f(0.3f, 0.3f));
        GameOver = new Text();
        AskPlayAgain = new Text();
        AskQuit = new Text();
        YourScore = new Text();
        Zindex = 1;
        Score = score;
        highscoreText = new Text();
    }

    public override void Create(Scene scene)
    {
            base.Create(scene);
            scene.Spawn(NewGame);
            scene.Spawn(Quit);
            Score.LoadhighScore();

            font = scene.Assets.LoadFont("PressStart2P", "fonts");

            GameOver.Font = font;
            GameOver.DisplayedString = "Game Over, You Lost";
            GameOver.CharacterSize = 25;
            GameOver.OutlineColor = Color.Black;
            GameOver.OutlineThickness = 2;
            GameOver.Position = new Vector2f(12, 250);
            
            YourScore.Font = font;
            YourScore.DisplayedString = "Your Score";
            YourScore.CharacterSize = 25;
            YourScore.OutlineColor = Color.Black;
            YourScore.OutlineThickness = 2;
            YourScore.Position = new Vector2f(12, 290);
            
            highscoreText.Font = font;
            highscoreText.DisplayedString = "HighScore";
            highscoreText.CharacterSize = 25;
            highscoreText.DisplayedString = $"HighScore: {Score.highScore}";
            highscoreText.Position = new Vector2f(14, 340);
        
            AskPlayAgain.Font = font;
            AskPlayAgain.DisplayedString = "Play Again?";
            AskPlayAgain.CharacterSize = 20;
            AskPlayAgain.OutlineColor = Color.Black;
            AskPlayAgain.OutlineThickness = 2;
            AskPlayAgain.Position = new Vector2f(20, 410);
        
            AskQuit.Font = font;
            AskQuit.DisplayedString = "Quit? ;(";
            AskQuit.CharacterSize = 20;
            AskQuit.OutlineColor = Color.Black;
            AskQuit.OutlineThickness = 2;
            AskQuit.Position = new Vector2f(290, 410);
    }
    
    public override void Render(Scene scene, RenderTarget target)
    {
        base.Render(scene, target);
        target.Draw(GameOver);
        target.Draw(AskPlayAgain);
        target.Draw(AskQuit);
        YourScore.DisplayedString = $"Your Score: {Score.CurrentScore}";
        target.Draw(YourScore);
        target.Draw(highscoreText);
    }
}
using Invaders;
using Invaders.Classes;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class NewHighScore : Menus
{
    private Buttons Play;
    private Buttons Back;
    private Text gameOverText;
    private Text Name;
    private Text instructionsText;
    private Text congratsText;
    private Text displayHighScore;
    private Text typeName;

    private List<Text> texts;
    
    private NameManager input;
    
    public NewHighScore(string textureName, string folder) : base(textureName, folder)
    {
        sprite.TextureRect = new IntRect(192, 128, 64, 64);
        sprite.Origin = new Vector2f(32, 32);
        sprite.Scale = new Vector2f(3f, 3f);
        Back = new Buttons("Back", new Vector2f(10, 600), "MainMenu", "BackButton", new Vector2f(0.4f, 0.4f));
        texts = new List<Text>();
        
        gameOverText = new Text();
        Name = new Text();
        instructionsText = new Text();
        congratsText = new Text();
        displayHighScore = new Text();
        typeName = new Text();
        
        texts.Add(gameOverText);
        texts.Add(Name);
        texts.Add(instructionsText);
        texts.Add(congratsText);
        texts.Add(displayHighScore);
        texts.Add(typeName);
     
        input = new NameManager();
        
        Program.window.KeyPressed += TypeThis;
    }
    
    public override void Create(Scene scene)
    {
        base.Create(scene);
        sprite.Position = new Vector2f(100, 340);
        font = scene.Assets.LoadFont("PressStart2P", "fonts");
        foreach (Text text in texts)
        {
            text.Font = font;
            text.OutlineColor = Color.Black;
            text.OutlineThickness = 2;
        }
        gameOverText.DisplayedString = "Game Over, You Lost";
        gameOverText.CharacterSize = 25;
        gameOverText.OutlineThickness = 2;
        gameOverText.Position = new Vector2f(15, 120);

        congratsText.DisplayedString = "Congrats On Your New High Score!";
        congratsText.CharacterSize = 14;
        congratsText.Position = new Vector2f(25, 160);

        displayHighScore.DisplayedString = $"High Score: {scene.Score.highScore}";
        displayHighScore.CharacterSize = 14;
        displayHighScore.Position = new Vector2f(165, 200);
        
        typeName.DisplayedString = "Type Your Name to memorize \r\n this momentous occasion!";
        typeName.LineSpacing = 2;
        typeName.CharacterSize = 12;
        typeName.Position = new Vector2f(165, 260);
        
        Name.CharacterSize = 40;
        Name.Position = new Vector2f(200, 330);
        
        instructionsText.DisplayedString = "Press Enter to Continue...";
        instructionsText.CharacterSize = 18;
        instructionsText.Position = new Vector2f(25, 440);

        scene.Spawn(Back);
    }
    public override void Render(Scene scene, RenderTarget target)
    {
        base.Render(scene, target);
        target.Draw(gameOverText);
        target.Draw(Name);
        target.Draw(instructionsText);
        target.Draw(congratsText);
        target.Draw(displayHighScore);
        target.Draw(typeName);
    }

    public override void Update(Scene scene, float deltaTime)
    {
        Name.DisplayedString = input.playerName.PadRight(7, '_');
        if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
        {
            scene.Score.playerName = input.playerName;
            SceneManager.LoadScene(GameState.MAINMENU);
            
            if (scene.Score.CurrentScore > scene.Score.highScore)
            { 
                scene.Score.highScore = scene.Score.CurrentScore;
                Console.WriteLine($"OnScoreGain: {scene.Score.highScore}");
                scene.Score.SaveHighScore();
                scene.Score.SaveHighScores();
                //SaveHighScore elsewhere, when game is over and currentscore is higher than highscore
            }
        }
    }
    
    private void TypeThis(object? ender, KeyEventArgs args)
    {
        if (args.Code >= Keyboard.Key.A && args.Code <= Keyboard.Key.Z && input.playerName.Length < 7)
        {
           input.playerName += args.Code.ToString();
        }
        if (args.Code == Keyboard.Key.Backspace)
        {
            if (input.playerName.Length > 0)
            {
                input.playerName = input.playerName.Substring(0, input.playerName.Length - 1);
            }
        }
    }
}
}


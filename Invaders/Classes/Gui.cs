using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Invaders.Classes
{
    public class Gui : Entity
    {
        private Text scoreText;
        public Text highscoreText;
        private int maxHealth = 3;
        private int currentHealth;
        private float currentScore;
        public int highScore;
        private Font font;
        //private static readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HighScore");
        //private static readonly string filePath = Path.Combine(folderPath, "HighScore.txt");
        
        public Gui() : base("pacman")
        {
            scoreText = new Text();
            highscoreText = new Text();
        }
        
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(72, 36, 18, 18);
            font = scene.Assets.LoadFont("PressStart2P");
            scoreText.Font = font;
            //highscoreText.Font = font;
            scoreText.DisplayedString = "Score";
            //highscoreText.DisplayedString = "HighScore";
            scoreText.CharacterSize = 23;
            //highscoreText.CharacterSize = 12;
            currentHealth = maxHealth;
            scene.Events.LoseHealth +=OnLoseHealth;
            scene.Events.GainScore += OnScoreGain;
            //LoadhighScore();
      
        }
        public override void Render(RenderTarget target)
        {
            sprite.Position = new Vector2f(5, 5);
            for (int i = 0; i < maxHealth; i++) 
            {
                sprite.TextureRect = i < currentHealth
                    ? new IntRect(72, 36, 18, 18) // Full heart
                    : new IntRect(72, 0, 18, 18); // Empty heart
                base.Render(target);
                sprite.Position += new Vector2f(50, 0);
                sprite.Scale = new Vector2f(3, 3);
            
            }
            scoreText.DisplayedString = $"Score: {currentScore}";
            //highscoreText.DisplayedString = $"HighScore: {highScore}";
            /* highscoreText.Position = new Vector2f(
                405 - highscoreText.GetGlobalBounds().Width, 415);*/
            scoreText.Position = new Vector2f(
                490 - scoreText.GetGlobalBounds().Width, 8
            );
            target.Draw(scoreText);
            //target.Draw(highscoreText);
        }
        private void OnLoseHealth(int amount, Scene scene)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                DontDestroyOnLoad = false;
            }
        }
        private void OnScoreGain(int value, Scene scene)
        {
            currentScore += 100;
            /*if (currentScore > highScore)
            {
                highScore = currentScore;
                SaveHighScore(currentScore);
            }*/
        }
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            currentScore += (int)Math.Round(deltaTime * 1000);
        }
    }
}


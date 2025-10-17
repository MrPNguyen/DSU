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
        public int maxHealth = 3;
        public int currentHealth;
        private Font font;
        private ScoreManager Score;
        public Gui(ScoreManager score) : base("pacman", "tilesets")
        {
            scoreText = new Text();
            highscoreText = new Text();
            Score = score;
        }
        
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(72, 36, 18, 18);
            font = scene.Assets.LoadFont("PressStart2P", "fonts");
            scoreText.Font = font;
            //highscoreText.Font = font;
            scoreText.DisplayedString = "Score";
            //highscoreText.DisplayedString = "HighScore";
            scoreText.CharacterSize = 23;
            //highscoreText.CharacterSize = 12;
            currentHealth = maxHealth;
            scene.Events.LoseHealth += OnLoseHealth;
            //scene.Events.GainScore += Score.OnScoreGain;
            //LoadhighScore();

        }
        
        private void OnLoseHealth(int amount, Scene scene)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                scene.GameLost = true;
            }
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
            scoreText.DisplayedString = $"Score: {Score.currentScore}";
            //highscoreText.DisplayedString = $"HighScore: {highScore}";
            /* highscoreText.Position = new Vector2f(
                405 - highscoreText.GetGlobalBounds().Width, 415);*/
            scoreText.Position = new Vector2f(
                490 - scoreText.GetGlobalBounds().Width, 8
            );
            target.Draw(scoreText);
            //target.Draw(highscoreText);
        }
       
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            Score.Update(deltaTime);
        }
    }
}


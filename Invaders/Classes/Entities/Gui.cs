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
        private Font font;
        private ScoreManager Score;
        private HealthManager Health;
        public Gui(ScoreManager score, HealthManager health) : base("pacman", "tilesets")
        {
            scoreText = new Text();
            highscoreText = new Text();
            Score = score;
            Health = health;
        }
        
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(72, 36, 18, 18);
            font = scene.Assets.LoadFont("PressStart2P", "fonts");
            scoreText.Font = font;
            scoreText.DisplayedString = "Score";
            scoreText.CharacterSize = 23;
            Health.currentHealth = Health.maxHealth;
            scene.Events.LoseHealth += Health.OnLoseHealth;
            scene.Events.GainScore += Score.OnScoreGain;
           

        }

        public void DisplayHighscore(RenderTarget target)
        {
            //highscoreText.Font = font;
            //highscoreText.DisplayedString = "HighScore";
            //highscoreText.CharacterSize = 12;
            //highscoreText.DisplayedString = $"HighScore: {highScore}";
            /* highscoreText.Position = new Vector2f(
                405 - highscoreText.GetGlobalBounds().Width, 415);*/
            //target.Draw(highscoreText);
            //LoadhighScore();
        }
        
        public override void Render(RenderTarget target)
        {
            sprite.Position = new Vector2f(55, 5);
            for (int i = 0; i < Health.maxHealth; i++) 
            {
                sprite.TextureRect = i < Health.currentHealth
                    ? new IntRect(72, 36, 18, 18) // Full heart
                    : new IntRect(72, 0, 18, 18); // Empty heart
                base.Render(target);
                sprite.Position += new Vector2f(50, 0);
                sprite.Scale = new Vector2f(3, 3);
            
            }
            scoreText.DisplayedString = $"Score: {Score.currentScore}";
           
            scoreText.Position = new Vector2f(
                490 - scoreText.GetGlobalBounds().Width, 8
            );
            target.Draw(scoreText);
           
        }
       
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            Score.Update(deltaTime);
        }
    }
}


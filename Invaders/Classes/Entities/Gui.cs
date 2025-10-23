using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Invaders.Classes
{
    public class Gui : Entity
    {
        private Text scoreText;
        private Text highScoreText;
        private Font font;
        public Gui(ScoreManager score, HealthManager health) : base("pacman", "tilesets")
        {
            scoreText = new Text();
            highScoreText = new Text();
        }
        
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(72, 36, 18, 18);
            font = scene.Assets.LoadFont("PressStart2P", "fonts");
            scoreText.Font = font;
            highScoreText.Font = font;
            scoreText.DisplayedString = "Score";
            highScoreText.DisplayedString = "HighScore";
            scoreText.CharacterSize = 23;
            highScoreText.CharacterSize = 23;
            scene.Health.currentHealth = scene.Health.maxHealth;
            scene.Events.LoseHealth += scene.Health.OnLoseHealth;
            scene.Events.GainScore += scene.Score.OnScoreGain;
            scene.Score.LoadhighScores();
        }

        public override void Destroy(Scene scene)
        {
            base.Destroy(scene);
            scene.Events.LoseHealth -= scene.Health.OnLoseHealth;
            scene.Events.GainScore -= scene.Score.OnScoreGain;
        }


        public override void Render(Scene scene, RenderTarget target)
        {
            sprite.Position = new Vector2f(55, 5);
            for (int i = 0; i < scene.Health.maxHealth; i++) 
            {
                sprite.TextureRect = i < scene.Health.currentHealth
                    ? new IntRect(72, 36, 18, 18) // Full heart
                    : new IntRect(72, 0, 18, 18); // Empty heart
                base.Render(scene, target);
                sprite.Position += new Vector2f(50, 0);
                sprite.Scale = new Vector2f(3, 3);
            
            }
            scoreText.DisplayedString = $"Score: {scene.Score.CurrentScore}";
           
            scoreText.Position = new Vector2f(
                490 - scoreText.GetGlobalBounds().Width, 8
            );
            target.Draw(scoreText);
        }
       
        public override void Update(Scene scene, float deltaTime)
        {
            base.Update(scene, deltaTime);
            scene.Score.Update(scene, deltaTime);
        }
    }
}


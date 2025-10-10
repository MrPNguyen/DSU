using SFML.System;

namespace Invaders.Classes
{
    public delegate void ValueChangedEvent(int value, Scene scene);

    public delegate void PositionChangedEvent(Vector2f pos, float Y, Scene scene);

    public class EventManager
    {
        private int scoreGained;
        private int healthLost;
        private Vector2f originalposition;

        public event ValueChangedEvent GainScore;
        public event ValueChangedEvent LoseHealth;
        public event PositionChangedEvent SpawnBullet;

        public void PublishGainScore(int amount, Scene scene)
        {
            scoreGained += amount;
            if (scoreGained != 0)
            {
                GainScore?.Invoke(scoreGained, scene);
                scoreGained = 0;
            }
        }

        public void PublishLoseHealth(int amount, Scene scene)
        {
            healthLost += amount;
            if (healthLost != 0)
            {
                LoseHealth?.Invoke(healthLost, scene);
                healthLost = 0;
            }
        }

        public void PublishSpawnBullet(Vector2f pos, float Y, Scene scene)
        {
            originalposition = pos;
        }
    }
}


using SFML.System;

namespace Invaders.Classes
{
    public delegate void ValueChangedEvent(int value, Scene scene);

    public delegate void PositionChangedEvent(Vector2f pos, float Y, Scene scene, bool isPlayerBullet);
    
    public sealed class EventManager
    {
        private int scoreGained;
        private int healthLost;
        private Vector2f originalposition;
        private float y;
        private bool isPlayerBullet;

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

        public void PublishSpawnBullet(Vector2f pos, float Y, Scene scene, bool IsPlayerBullet)
        {
            originalposition = pos;
            y = Y;
            isPlayerBullet = IsPlayerBullet;
            if (y != 0)
            {
                SpawnBullet?.Invoke(originalposition, y, scene, isPlayerBullet);
                y = 0;
            }
        }
    }
}


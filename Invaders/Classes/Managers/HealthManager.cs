namespace Invaders.Classes;

public class HealthManager
{
    public int maxHealth = 3;
    public int currentHealth;
    
    public void OnLoseHealth(int amount, Scene scene)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            scene.GameLost = true;
        }
    }
}
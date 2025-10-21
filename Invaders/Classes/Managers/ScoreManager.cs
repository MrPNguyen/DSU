using System.Runtime.CompilerServices;
using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class ScoreManager
{
    public int highScore;
    public int CurrentScore;
    private static readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HighScore");
    private static readonly string filePath = Path.Combine(folderPath, "HighScore.txt");
    private Clock ScoreClock;
    private Actor actor;
    public List<int> scores; 
    
    public ScoreManager(int currentScore)
    {
        ScoreClock = new Clock();
        actor = new Actor();
        scores = new List<int>();
        CurrentScore = currentScore;
    }
    private void SaveHighScore()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        FileStream save = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            
        StreamWriter writer = new StreamWriter(save);
            
        writer.Write(CurrentScore);
        scores.Add(CurrentScore);
            
        writer.Dispose();
        save.Dispose();
    }

    private void LoadhighScore()
    {
        if (!File.Exists(filePath))
        {
            highScore = 0; // default value
            return;
        }
        FileStream open = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        
        StreamReader reader = new StreamReader(open);
        
        string line = reader.ReadToEnd().Trim();
        
        if(int.TryParse(line, out int score))
        {
            highScore = score;
            Console.WriteLine(highScore);
        }
        else
        {
            highScore = 0;
        }
        
        reader.Dispose();
        open.Dispose();
    }
    
    public void OnScoreGain(int value, Scene scene)
    {
        CurrentScore += value;
        if (CurrentScore > highScore)
        {
            highScore = CurrentScore;
            SaveHighScore();
        }
    }

    public void Update(Scene scene, float deltaTime)
    {
        if (actor.moving && !scene.GameLost)
        {
            if (ScoreClock.ElapsedTime.AsSeconds() >= 1)
            {
                CurrentScore++;
                ScoreClock.Restart();
            }
        }
        
        if (scene.PauseActive)
        {
            actor.moving = false;
        }
        else
        {
            actor.moving = true;
        }
    }
}
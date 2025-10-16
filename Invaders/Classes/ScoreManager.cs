using System.Runtime.CompilerServices;
using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class ScoreManager
{
    public int highScore;
    public int currentScore;
    private static readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HighScore");
    private static readonly string filePath = Path.Combine(folderPath, "HighScore.txt");
    private Clock ScoreClock;
    
    public ScoreManager()
    {
        ScoreClock = new Clock();
    }
    private void SaveHighScore(int score)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        FileStream save = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            
        StreamWriter writer = new StreamWriter(save);
            
        writer.Write(currentScore);
            
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
        currentScore += value;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore(currentScore);
        }
    }

    public void Update(float deltaTime)
    {
        if (ScoreClock.ElapsedTime.AsSeconds() >= 1)
        {
            currentScore++;
            ScoreClock.Restart();
        }
    }
}
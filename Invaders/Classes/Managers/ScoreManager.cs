using System.Runtime.CompilerServices;
using System.Xml.Schema;
using SFML.Graphics;
using SFML.System;

namespace Invaders.Classes;

public class ScoreManager
{
    public int CurrentScore;
    public int highScore;
    public string playerName;
    private static readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HighScore");
    private static readonly string filePath = Path.Combine(folderPath, "HighScore.txt");
    private static readonly string filePath2 = Path.Combine(folderPath, "HighScoreList.txt");
    private Clock ScoreClock;
    
    public ScoreManager()
    {
        ScoreClock = new Clock();
    }
    public void SaveHighScore()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        FileStream save = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            
        StreamWriter writer = new StreamWriter(save);
        writer.Write(CurrentScore);
        writer.Dispose();   
        save.Dispose();
    }
    public void LoadhighScore()
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
            //Console.WriteLine($"LoadHighScore: {highScore}");
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
    }
    public void Update(Scene scene, float deltaTime)
    {
        if (!scene.PauseActive && !scene.GameLost)
        {
            if (ScoreClock.ElapsedTime.AsSeconds() >= 1)
            {
                CurrentScore++;
                ScoreClock.Restart();
            }
        }
    }
}
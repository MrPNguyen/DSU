using SFML.Graphics;

namespace Invaders.Classes;

public class HighScoreManager
{
    private static readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HighScoreList");
    private static readonly string filePath = Path.Combine(folderPath, "HighScoreList.txt");
    public List<string> Scores;
    private Text noScore;

    public HighScoreManager()
    {
        Scores = new List<string>();
    }
    
    public void SaveHighScores()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        FileStream save = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            
        StreamWriter writer = new StreamWriter(save);

        foreach (string score in Scores)
        {
            writer.WriteLine($"{score}\r\n");
        }
            
        writer.Dispose();
        save.Dispose();
    }
    
    public List<string> LoadhighScores()
    {
        List<string> scores = new List<string>();
        if (!File.Exists(filePath))
        {
            return scores;
        }
        FileStream open = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        
        StreamReader reader = new StreamReader(open);
        
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            scores.Add(line);
        }
        
        reader.Dispose();
        open.Dispose();
        return scores;
    }
}
using SFML.Graphics;

namespace Invaders.Classes;

public struct HighScoreManager
{
    public int HighScores { get; set; }
    public string PlayerName { get; set; }

    public HighScoreManager(int highScores, string playerName)
    {
        HighScores = highScores;
        PlayerName = playerName;
    }

    public override string ToString()
    {
        return $"{PlayerName}: {HighScores}";
    }
}
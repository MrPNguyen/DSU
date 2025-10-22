namespace Invaders.Classes
{
    public static class SceneManager
    {
        public static GameState state { get; set; } = GameState.NEWHIGHSCORE;

        public static void LoadScene(GameState newState)
        {
            state = newState;
        }
    }
}


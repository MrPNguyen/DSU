namespace Invaders.Classes
{
    public static class SceneManager
    {
        public static GameState state { get; set; } = GameState.MAINMENU;

        public static void LoadScene(GameState newState)
        {
            state = newState;
        }
    }
}


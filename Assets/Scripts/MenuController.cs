using UnityEngine;

public class MenuController : MonoBehaviour
{

    public static void LoadGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Timer.strt = true;
    }


    public static void LoadMainMenu()
    {
        DisplayScores.collectableScore = 0;
        DisplayScores.deathCount = 0;
        DisplayScores.enemiesDefeated = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public static void LoadScores()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scores");
    }


    // quits game
    public void ExitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

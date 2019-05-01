using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMaster : Managers
{
    private static bool gamePaused = false;
    public static void OpenGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public static void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void PauseGame()
    {
        gamePaused = true;
    }

    public static void ContinueGame()
    {
        if (!gamePaused)
        {
            return;
        }
        gamePaused = false;
    }

    public static bool getIsGamePaused()
    {
        return gamePaused;
    }
}

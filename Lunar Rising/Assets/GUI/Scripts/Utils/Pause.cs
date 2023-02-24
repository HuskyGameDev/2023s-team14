using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pause
{
    public static bool gameIsPaused;

    public static void pauseGame()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public static void unpauseGame()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public static bool GameIsPaused()
    {
        return gameIsPaused;
    }
}

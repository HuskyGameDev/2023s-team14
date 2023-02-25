using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool _isGameOver;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _isGameOver = false;
    }

    public void HandlePausing(GameObject pauseMenu)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pause.GameIsPaused())
            {
                Pause.pauseGame();
                Menu.OpenMenu(pauseMenu);
            }
            else
            {
                Pause.unpauseGame();
                Menu.CloseMenu(pauseMenu);
            }
        }
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }
}
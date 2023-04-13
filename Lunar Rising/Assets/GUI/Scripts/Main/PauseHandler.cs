using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;

    private void Update()
    {
        GameManager.Instance.HandlePausing(pauseMenu, optionsMenu);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private void Update()
    {
        GameManager.Instance.HandlePausing(pauseMenu);
    }
}

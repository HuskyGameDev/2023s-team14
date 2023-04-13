using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("button_select_sound");
        SceneManager.LoadScene(1);
    }

    public void OpenOptions()
    {
        FindObjectOfType<AudioManager>().Play("button_select_sound");
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        FindObjectOfType<AudioManager>().Play("button_select_sound");
        optionsMenu.SetActive(false); 
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("button_select_sound");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("button_select_sound");
        Pause.unpauseGame();
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play("button_select_sound");
        Pause.unpauseGame();
        mainMenu.SetActive(false);
    }
}

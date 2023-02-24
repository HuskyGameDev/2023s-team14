using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Menu
{
    public static void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public static void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
}

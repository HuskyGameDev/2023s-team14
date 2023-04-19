using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float minutes;
    float seconds;
    public GameObject winnerMenu;
    public TextMeshProUGUI winnerTimeText;
    public GameObject player;
    public GameObject GUI;
    string m;
    string s;
    float time = 0;

    public void Start()
    { 
        m = "00";
        s = "00";
        minutes = Mathf.Floor(time / 60);
        seconds = Mathf.Round(time);
        timerText.text = "Time: " + m + ":" + s;
    }
    public void Update()
    {
        time = Time.timeSinceLevelLoad;
        minutes = Mathf.Floor(time / 60);
        seconds = Mathf.Round(time % 60);
        if (minutes < 10)
        {
            m = "0";
        }
        else
        {
            m = "";
        }

        if (seconds < 10)
        {
            s = "0";
        }
        else
        {
            s = "";
        }

        timerText.text = "Time: " + m + minutes + ":" + s + seconds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bring up a screen saying congratulation and tell the player their time
        winnerMenu.SetActive(true);
        winnerTimeText.text = "Your time: " + m + minutes + ":" + s + seconds;
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 10f, -10f);
        player.SetActive(false);
        GUI.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("rocket_thrust_sound");
        timerText.text = timerText.text = "Time: " + m + ":" + s;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerIsRunning = false;

    public GameObject endmenu;
    public GameObject bee;

    public TextMeshProUGUI timerText;   // Reference to the UI text component


    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
       
    }
    

    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(timeRemaining);
                timerText.text = "Time Remaining: " + seconds.ToString();


            }
            else
            {
                
                timeRemaining = 0;
                timerIsRunning = false;
                timerText.text = "TIME'S UP";
                endmenu.SetActive(true);
                bee.SetActive(false);



            }
        }
    }
}
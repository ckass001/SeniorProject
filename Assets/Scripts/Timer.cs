using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 100; // floating point variable declared to store the amount of time 
                                     //remaining in the countdown 
    
    public bool timerIsRunning = false;  

    public Text timerText; //declare text object used to diaplay time in the game

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning) // will only execute else statement to excute once while the timer is running 
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // every frame the duration from the previous frame is subtracted
                                             // from the time remaining until the timer runs out 
                DisplayTime(timeRemaining);
            }
            else // displays text when the timer runs out 
            {
                timeRemaining = 0;
                Debug.Log("Time has run out!");
                timerIsRunning = false;  
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
          timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // use string format to place varaibles inside of formatted string using double digit numbers that 
        // are seperated by a colon; 
        // Curly brackets represent minutes and secons values in time display
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  
    }
}


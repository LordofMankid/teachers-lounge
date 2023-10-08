using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // You need to include this for Text component.

public class GameTimer : MonoBehaviour
{
    public int timer = 120; // Set the initial timer value to 2 minutes (120 seconds).
    private float theTimer = 0f;
    public Text timerText;

    void FixedUpdate()
    {
        theTimer += 0.01f;
        if (theTimer >= 1f)
        {
            timer -= 1; // Decrement the timer by 1 second.
            theTimer = 0;
            UpdateTimer();
        }
    }

    void Start()
    {
        // Start the timer when the game begins 
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        // Ensure that timer cannot go below 0.
        if (timer < 0)
        {
            timer = 0;
        }

        // Update the displayed timer text.
        timerText.text = string.Format("{0}:{1:00}", timer / 60, timer % 60); // Format the timer as "mm:ss".
    }
}

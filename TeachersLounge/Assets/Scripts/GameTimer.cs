using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public int timer = 120;
    private float theTimer = 0f;
    public string timerTextTag = "gameTimer"; // Specify the tag for your Text object.

    void FixedUpdate()
    {
        theTimer += 0.01f;
        if (theTimer >= 1f)
        {
            timer -= 1;
            theTimer = 0;
            UpdateTimer();
        }
    }

    void Start()
    {
        // Find the GameObject with the specified tag and assign its Text component to timerText.
        GameObject timerObject = GameObject.FindWithTag(timerTextTag);
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<Text>();
            UpdateTimer();
        }
        else
        {
            Debug.LogError("Timer Text object with tag " + timerTextTag + " not found.");
        }
    }

    public Text timerText;

    public void UpdateTimer()
    {
        if (timer < 0)
        {
            timer = 0;
        }

        if (timerText != null)
        {
            timerText.text = string.Format("{0}:{1:00}", timer / 60, timer % 60);
        }
        else
        {
            Debug.LogError("Timer Text component is not assigned.");
        }
    }
}

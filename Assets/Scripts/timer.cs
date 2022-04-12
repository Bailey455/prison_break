using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class timer : MonoBehaviour
{
    float time = 601;
    float minutes = 0;
    float seconds = 0;

    public TextMeshProUGUI timerText;
    public GameObject loseScreen;
    public GameObject purpose;
    public GameObject instructions;
    public GameObject shop;

    bool timeStop = false;

    float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (!purpose.activeSelf && !instructions.activeSelf && !shop.activeSelf)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 0;
                loseScreen.SetActive(true);
            }

            SetTimerText(time);
        }
    }


    private void SetTimerText(float time)
    {
        if (time == 0)
        {
            timeStop = true;
            timerText.text = "Time left: " + string.Format("{0:00}:{1:00}", 0, 0);
        }
        else
        {
            currentTime = time - Time.deltaTime;
            minutes = Mathf.FloorToInt(currentTime / 60);
            seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void StopTimer()
    {
        if (timeStop)
        {

        }
    }
}

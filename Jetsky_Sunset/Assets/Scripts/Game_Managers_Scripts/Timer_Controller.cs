using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer_Controller : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    private float startTime;
    private bool stopTimer;

    private int minutes;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        stopTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTimer == false)
        {
            float t = Time.time - startTime;

            minutes = ((int)t / 60);
            seconds = (t % 60);
            string str_minutes = minutes.ToString();
            string str_seconds = seconds.ToString("f2");

            timerText.text = str_minutes + ":" + str_seconds;
        }
    }

    public void Stop_Timer()
    {
        stopTimer = true;
        timerText.color = Color.yellow;
    }
}

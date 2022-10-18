using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer_Controller1 : MonoBehaviour
{
    [SerializeField] TMP_Text timerText1;

    private float startTime1;
    private bool stopTimer1;

    private int minutes;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        startTime1 = Time.time;
        stopTimer1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTimer1 == false)
        {
            float t = Time.time - startTime1;

            minutes = ((int)t / 60);
            seconds = (t % 60);
            string str_minutes = minutes.ToString();
            string str_seconds = seconds.ToString("f2");

            timerText1.text = str_minutes + ":" + str_seconds;
        }
    }

    public void Stop_Timer1()
    {
        stopTimer1 = true;
        timerText1.color = Color.yellow;
    }
}

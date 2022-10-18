using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer_Controller : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    [SerializeField] TMP_Text timerLap1;
    [SerializeField] TMP_Text timerLap2;
    [SerializeField] TMP_Text timerLap3;

    private HighScorePosition m_highsScorePosition;

    public UnityEvent saveLapTime;

    private Vector2 v2_highScoreTime;

    private float startTime;
    private bool stopTimer;
    private int lapSaver = 0;
    private float lapTimer;
    private int lapMinutes;
    private float lapSeconds;
    private int minutes;
    private float seconds;

    void Start()
    {
        m_highsScorePosition = gameObject.GetComponent<HighScorePosition>();
        saveLapTime.AddListener(Lap_Time_UI);
        startTime = Time.time;
        stopTimer = false;
    }

    void Update()
    {
        if(stopTimer == false)
        {
            // Laps Timer calculatiosn 
            lapSeconds += Time.deltaTime;
            if(lapSeconds >= 60.0)
            {
                lapSeconds = 0.0f;
                lapMinutes += 1;
            }
            // Main Timer Calculatios
            float t = Time.time - startTime;

            minutes = ((int)t / 60);
            seconds = (t % 60);
            string str_minutes = minutes.ToString();
            string str_seconds = seconds.ToString("f2");

            timerText.text = str_minutes + ":" + str_seconds;
        }
    }

    void Lap_Time_UI()
    {
        lapSaver += 1;
        if(lapSaver == 1)
        {
            timerLap1.text = "L1: " + Lap_Time_Measurer();
            timerLap1.color = Color.red;
        }
        if(lapSaver == 2)
        {
            timerLap2.text = "L2: " + Lap_Time_Measurer();
            timerLap1.color = Color.white;
            timerLap2.color = Color.red;
        }
        if(lapSaver == 3)
        {
            timerLap3.text = "L3: " + Lap_Time_Measurer();
            timerLap1.color = Color.white;
            timerLap2.color = Color.white;
            timerLap3.color = Color.red;
        }
        lapMinutes = 0;
        lapSeconds = 0.0f;
    }

    string Lap_Time_Measurer()
    {
        string str_lapMinutes = lapMinutes.ToString();
        string str_lapSeconds = lapSeconds.ToString("f2");
        return str_lapMinutes + ":" + str_lapSeconds;
    }

    public void Stop_Timer()
    {
        stopTimer = true;
        timerText.color = Color.yellow;
        v2_highScoreTime.x = minutes;
        v2_highScoreTime.y = seconds;
        m_highsScorePosition.Fill_Vector_With_Data(v2_highScoreTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLap_TimeController : MonoBehaviour
{
    public Start_Line_Script _start_Line_Script;
    public int npcLaps;
    public int maxNpcLaps, npcMinutes;
    public float npcSeconds;

    private float startTime;
    private bool npcStopTimer;


    void Update()
    {
        if (npcStopTimer == false)
        {
            float t = Time.time - startTime;

            npcMinutes = ((int)t / 60);
            npcSeconds = (t % 60);
            string str_minutes = npcMinutes.ToString();
            string str_seconds = npcSeconds.ToString("f2");
        }
    }

    public void Stop_Timer()
    {
        npcStopTimer = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLap_TimeController : MonoBehaviour
{
    private HighScorePosition m_highScorePosition;
    private int npcLaps, npcMinutes;
    public int maxNpcLaps;

    private Vector2 v2_npcFinalScoreTime;
    private float startTime, npcSeconds;
    private bool npcStopTimer = false;
    private bool sendFinalTime = false;

    private void Start()
    {
        m_highScorePosition = GameObject.FindGameObjectWithTag("UIManager").GetComponent<HighScorePosition>();
    }

    void Update()
    {
        if (npcStopTimer == false)
        {
            float t = Time.time - startTime;

            npcMinutes = ((int)t / 60);
            npcSeconds = (t % 60);
        }
        if(sendFinalTime == true && npcLaps == maxNpcLaps)
        {
            v2_npcFinalScoreTime.x = npcMinutes;
            v2_npcFinalScoreTime.y = npcSeconds;
            m_highScorePosition.Fill_Vector_With_Data(v2_npcFinalScoreTime);
            sendFinalTime = false;
        }
    }

    public void NPC_Lap_Manager()
    {
        npcLaps += 1;
        if (npcLaps == maxNpcLaps)
        {
            npcStopTimer = true;
            sendFinalTime = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game_Manager : MonoBehaviour
{
    public Timer_Controller m_timerController;
    public Check_Point_List_Manager m_checkpointlistManager;

    public int lapAmount;
    public int totalLapAmount;

    public UnityEvent increaseLap;

    // Start is called before the first frame update
    void Start()
    {
        increaseLap.AddListener(Increase_Race_Lap);
    }

    void Increase_Race_Lap()
    {
        lapAmount += 1;
        m_timerController.saveLapTime.Invoke();
        if(lapAmount == totalLapAmount)
        {
            m_timerController.Stop_Timer();
            //Player finished the race 
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if(_collider.tag == "Player")
        {
            _collider.gameObject.GetComponent<Transform>().position = m_checkpointlistManager.previousCheckPointPosition;
        }
    }
}

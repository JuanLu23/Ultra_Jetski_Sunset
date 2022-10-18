using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Start_Line_Script : MonoBehaviour
{
    public UnityEvent startlineActivate;
    public UnityEvent startlineDeactivate;

    public BoxCollider startlineCollider;
    public Game_Manager m_gameManager;

    public Ocean_Manager m_oceanManager;

    private bool b_playerPassedFinalCheckPoint;
    private bool b_NpcPassedFinalCheckPoint;

    private void Start()
    {
        startlineActivate.AddListener(Activate_Start_Line);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.tag == "Player")
        {
            if(b_playerPassedFinalCheckPoint == true)
            {
                m_oceanManager.changePattern.Invoke();
                m_gameManager.increaseLap.Invoke();
                b_playerPassedFinalCheckPoint = false;
            }

        }else if (_collider.tag == "NpcRacer")
        {
            _collider.gameObject.GetComponent<NpcLap_TimeController>().NPC_Lap_Manager();
        }
    }

    void Activate_Start_Line()
    {
        b_playerPassedFinalCheckPoint = true;
    }
}

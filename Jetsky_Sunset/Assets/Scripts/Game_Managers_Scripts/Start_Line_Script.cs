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

    private void Start()
    {
        startlineActivate.AddListener(Activate_Start_Line);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_gameManager.increaseLap.Invoke();
            Debug.Log("Start Line");
            Deactivate_Start_Line();
        }
    }

    void Activate_Start_Line()
    {
        startlineCollider.enabled = true;
    }

    void Deactivate_Start_Line()
    {
        startlineCollider.enabled = false;
    }
}

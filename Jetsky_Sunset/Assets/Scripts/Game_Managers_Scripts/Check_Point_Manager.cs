using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Point_Manager : MonoBehaviour
{

    public Check_Point_List_Manager m_cplManager;

    public void Start()
    {
        m_cplManager.GetComponent<Check_Point_List_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 currentCheckPointPosition = this.transform.position;
            m_cplManager.previousCheckPointPosition = currentCheckPointPosition;
            m_cplManager.playerCrossedCheckPoint.Invoke();
        }
    }
}

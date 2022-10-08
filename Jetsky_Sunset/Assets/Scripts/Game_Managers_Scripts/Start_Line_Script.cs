using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Line_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Start");
        }
    }
}

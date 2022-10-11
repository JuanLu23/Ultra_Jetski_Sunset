using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game_Manager : MonoBehaviour
{

    public int lapAmount;

    public UnityEvent increaseLap;
    // Start is called before the first frame update
    void Start()
    {
        increaseLap.AddListener(Increase_Race_Lap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Increase_Race_Lap()
    {
        lapAmount += 1;
    }
}

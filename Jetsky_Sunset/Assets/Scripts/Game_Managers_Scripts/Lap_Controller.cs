using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Lap_Controller : MonoBehaviour
{

    public TMP_Text m_lapText;
    public Game_Manager m_GameManager;
    
    void Update()
    {

        string currentLap = m_GameManager.lapAmount.ToString();
        string totalLap = m_GameManager.totalLapAmount.ToString();
        m_lapText.text = currentLap + " / " + totalLap;
    }
}

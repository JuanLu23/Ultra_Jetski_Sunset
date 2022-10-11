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
        m_lapText.text = m_GameManager.lapAmount.ToString();
    }
}

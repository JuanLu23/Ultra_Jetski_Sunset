using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScorePosition : MonoBehaviour
{
    public TMP_Text[] highscoreFinalTimeText;
    private Vector2[] minutesAndSecondsContainer = new Vector2[4];
    public Canvas can_avtivateCanvas;
    public static int sizeVector2Array;
    private int i_contadorDeArrayTMP;

    void Start()
    {
        can_avtivateCanvas.enabled = false;
        i_contadorDeArrayTMP = 0;
    }

    public void Fill_Vector_With_Data(Vector2 _finalTimes)
    {
        if(i_contadorDeArrayTMP < highscoreFinalTimeText.Length)
        {
            minutesAndSecondsContainer[i_contadorDeArrayTMP] = _finalTimes;
            i_contadorDeArrayTMP++;
        }
        if(i_contadorDeArrayTMP == 4)
        {
            can_avtivateCanvas.enabled = true;
            Vector_List_Organizer();
        }
    }

    private void Vector_List_Organizer()
    {
        for (int i = 0; i < highscoreFinalTimeText.Length; i++)
        {
            string str_minutos = minutesAndSecondsContainer[i].x.ToString();
            string str_seconds = minutesAndSecondsContainer[i].y.ToString("f2");
            highscoreFinalTimeText[i].text = str_minutos + ":" + str_seconds;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScorePosition : MonoBehaviour
{
    public TMP_Text[] highscoreFinalTimeText;
    private Vector2[] minutesAndSecondsContainer = new Vector2[4];

    public static int sizeVector2Array;
    private int i_contadorDeArrayTMP;

    void Start()
    {
        i_contadorDeArrayTMP = 0;
    }

    public void Fill_Vector_With_Data(Vector2 _finalTimes)
    {
        if(i_contadorDeArrayTMP < highscoreFinalTimeText.Length)
        {
            Debug.Log("Hey my time was saved");
            Debug.Log(_finalTimes);
            minutesAndSecondsContainer[i_contadorDeArrayTMP] = _finalTimes;
            i_contadorDeArrayTMP++;
        }
        if(i_contadorDeArrayTMP >= highscoreFinalTimeText.Length)
        {
            Vector_List_Organizer();
        }
    }

    private void Vector_List_Organizer()
    {
        for (int i = 0; i < minutesAndSecondsContainer.Length; i++)
        {
            //bubble sort
        }
    }

    /*
    private void Vector_Array_Size()
    {
        Vector2[] minutesAndSecondsContainer = new Vector2[sizeVector2Array];
    }*/
}

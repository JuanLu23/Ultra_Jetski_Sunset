using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public TMP_Text timerText;
    static float timer;


    public TMP_Text lapText;


    void Start()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Escena_Principal_Carrera");
    }

    void Update()
    {

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string time = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = time;

        if (Input.GetKeyDown("9"))
        {
            RestartGame();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        lapText.text = "Lap: " + timerText.text;
        timer = 0.0f;
    }
}
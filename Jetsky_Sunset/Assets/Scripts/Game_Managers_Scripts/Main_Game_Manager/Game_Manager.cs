using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;


public class Game_Manager : MonoBehaviour
{
    public Timer_Controller m_timerController;
    public Check_Point_List_Manager m_checkpointlistManager;
    public TMP_Text tmp_startRaceTimerText;
    public GameObject c_pauseMenu;

    public int lapAmount;
    public int totalLapAmount;

    public UnityEvent increaseLap;

    private float f_startRaceTimer = 0;
    private bool b_startRaceCountdown;
    private GameObject go_playerObject;
    private GameObject[] go_npcObject;

    // Start is called before the first frame update
    void Start()
    {
        increaseLap.AddListener(Increase_Race_Lap);
        if (SceneManager.GetSceneByName("Escena_Principal_Carrera").isLoaded)
        {
            go_playerObject = GameObject.FindGameObjectWithTag("Player");
            go_npcObject = GameObject.FindGameObjectsWithTag("NpcRacer");
            b_startRaceCountdown = true;
        }
        else
            tmp_startRaceTimerText = null;
    }

    private void Update()
    {
        if (b_startRaceCountdown)
        {
            Start_Race_Timer();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause_Game();
        }
    }

    void Increase_Race_Lap()
    {
        if(lapAmount < totalLapAmount)
        {
            lapAmount += 1;
            m_timerController.saveLapTime.Invoke();
        }
        if(lapAmount == totalLapAmount)
        {
            m_timerController.Stop_Timer();
            go_playerObject.GetComponent<BoteMovement>().b_enableControls = false;
            go_playerObject.GetComponent<BoteMovement>().speedInput = 0;
            //Player finished the race 
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if(_collider.tag == "Player")
        {
            _collider.gameObject.GetComponent<Transform>().position = m_checkpointlistManager.previousCheckPointPosition;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Escena_Principal_Carrera");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Pause_Game()
    {
        c_pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void Resume_Game()
    {
        c_pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Return_To_Main_Menu()
    {
        SceneManager.LoadScene("Scene_Menu");
    }

    void Start_Race_Timer()
    {
        f_startRaceTimer += Time.deltaTime;

        string str_t = f_startRaceTimer.ToString("f0");

        tmp_startRaceTimerText.text = str_t;
        if(f_startRaceTimer >= 3)
        {
            m_timerController.b_startTimer = true;
            tmp_startRaceTimerText.enabled = false;
            b_startRaceCountdown = false;
            go_playerObject.GetComponent<BoteMovement>().b_enableControls = true;
            for (int i = 0; i < go_npcObject.Length; i++)
            {
                go_npcObject[i].GetComponent<NPC_Movement_Behaviour>().b_raceStarted = true;
            }
        }
    }
}

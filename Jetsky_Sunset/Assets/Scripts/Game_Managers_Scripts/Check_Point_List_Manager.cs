using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Check_Point_List_Manager : MonoBehaviour
{
    public Start_Line_Script m_startlineScript;

    public Transform[] checkPointsPositions;

    public Transform checkpointModel;

    int previusCP = 0;
    int CPlistLength;

    public UnityEvent playerCrossedCheckPoint;

    private void Start()
    {
        playerCrossedCheckPoint.AddListener(ChangeCheckPointPosition);
        checkpointModel.position = checkPointsPositions[previusCP].position;
        checkpointModel.rotation = checkPointsPositions[previusCP].rotation;
        CPlistLength = checkPointsPositions.Length;
    }

    void ChangeCheckPointPosition()
    {
        previusCP += 1;
        if (previusCP <= (CPlistLength - 1))
        {
            Checkpoint_Position_Rotation(previusCP);
        }
        else if (previusCP == (CPlistLength))
        {
            m_startlineScript.startlineActivate.Invoke();
            previusCP = 0;
            Checkpoint_Position_Rotation(previusCP);
        }
    }

    void Checkpoint_Position_Rotation(int _previusCP)
    {
        checkpointModel.position = checkPointsPositions[_previusCP].position;
        checkpointModel.rotation = checkPointsPositions[_previusCP].rotation;
    }
}

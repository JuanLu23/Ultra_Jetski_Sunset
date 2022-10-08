using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Check_Point_List_Manager : MonoBehaviour
{
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
        if (previusCP < (CPlistLength - 1))
        {
            previusCP += 1;
        }
        else
        {
            previusCP = 0;
        }
        checkpointModel.position = checkPointsPositions[previusCP].position;
        checkpointModel.rotation = checkPointsPositions[previusCP].rotation;
    }
}

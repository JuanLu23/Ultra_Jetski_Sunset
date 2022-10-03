using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Buoyancy_Script : MonoBehaviour
{
    public Transform[] floaters;

    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 0f;

    Ocean_Manager ocean_Manager;

    Rigidbody m_Rigidbody;

    int floatersUnderWater;
    public bool underwater;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        ocean_Manager = FindObjectOfType<Ocean_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        floatersUnderWater = 0;
        for(int i = 0; i < floaters.Length; i++)
        {
            float difference = floaters[i].position.y - ocean_Manager.WaterHeightAtPosition(floaters[i].position);

            if (difference < 0)
            {
                m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floaters[i].position, ForceMode.Force);
                floatersUnderWater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchState(true);
                }
            }

        }

        if (underwater && floatersUnderWater == 0)
        {
            underwater = false;
            SwitchState(false);

        }
    }

    void SwitchState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
}

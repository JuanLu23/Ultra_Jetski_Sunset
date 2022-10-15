using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ocean_Manager : MonoBehaviour
{

    private float waveHeight;

    private float waveFrequency;

    private float waveSpeed;

    private int currentWavePattern = 0;

    public Transform _ocean;

    public UnityEvent changePattern;

    Material _oceanMaterial;
    Texture2D _displacementWaves;


    void Start()
    {
        changePattern.AddListener(Ocean_Behaviour_Pattern);
        Ocean_Behaviour_Pattern();
        SetVariables();
    }

    void SetVariables()
    {
        _oceanMaterial = _ocean.GetComponent<Renderer>().sharedMaterial;
        _displacementWaves = (Texture2D)_oceanMaterial.GetTexture("_Wave_Displacement_Map");
    }

    public float WaterHeightAtPosition(Vector3 _position)
    {
        return _ocean.position.y + _displacementWaves.GetPixelBilinear(_position.x * waveFrequency/100, _position.z * waveFrequency/100 + Time.time * waveSpeed/100).g * waveHeight/100 * _ocean.localScale.x;
    }

    private void OnValidate()
    {
        if (!_oceanMaterial)
        {
            SetVariables();
        }
        UpdateMaterial();
    }

    void Ocean_Behaviour_Pattern()
    {
        switch (currentWavePattern)
        {
            case 0:
                waveHeight = 2f;
                waveFrequency = 0.15f;
                waveSpeed = 1f;
                currentWavePattern += 1;
                break;
            case 1:
                waveHeight = 3f;
                waveFrequency = 0.3f;
                waveSpeed = 1.5f;
                currentWavePattern += 1;
                break;
            case 2:
                waveHeight = 4f;
                waveFrequency = 0.14f;
                waveSpeed = 1.8f;
                currentWavePattern += 1;
                break;
            case 3:
                waveHeight = 5f;
                waveFrequency = 0.2f;
                waveSpeed = 2f;
                currentWavePattern += 1;
                break;
        }
        UpdateMaterial();

    }

    void UpdateMaterial()
    {
        _oceanMaterial.SetFloat("_Waves_Speed", waveSpeed/100);
        _oceanMaterial.SetFloat("_Waves_Frequency", waveFrequency/100);
        _oceanMaterial.SetFloat("_Wave_Height", waveHeight/100);
    }
}

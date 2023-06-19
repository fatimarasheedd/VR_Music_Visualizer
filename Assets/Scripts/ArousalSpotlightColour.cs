using System;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class ArousalSpotlightColour : MonoBehaviour
{
    public float _arousal;
    Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        Color arousalColor = CalculateArousalColor();
        spotlight.color = arousalColor;
    }

    Color CalculateArousalColor()
    {
        Color arousalColor;
        UnityEngine.Debug.Log(_arousal);
        if (_arousal <= 0.3f)
        {
            arousalColor = Color.blue; 
        }
        else if (_arousal <= 0.55f)
        {
            arousalColor = Color.green; 
        }
        else
        {
            arousalColor = Color.red;
        }

        return arousalColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class ValenceSpotlightColour : MonoBehaviour
{
    public float _valence;
    Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Color valenceColor = CalculateValenceColor();
        _light.color = valenceColor;
    }

    Color CalculateValenceColor()
    {
        Color valenceColor;

        if (_valence <= 0.3f)
        {
            valenceColor = new Color(0.5f, 0f, 0.5f); // Low valence color (purple)
        }
        else if (_valence <= 0.55f)
        {
            valenceColor = Color.yellow; // Medium valence color (yellow)
        }
        else
        {
            valenceColor = Color.green; // High valence color (green)
        }

        return valenceColor;
    }
}

using UnityEngine;

[RequireComponent(typeof(Light))]
public class ArousalSpotlightColour : MonoBehaviour
{
    public float arousalValue; // The arousal value ranging from 0.000 to 1.000

    // Define the colors for mapping
    public Color lowArousalColor = Color.blue;
    public Color mediumArousalColor = Color.green;
    public Color highArousalColor = Color.red;

    private Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // Map the arousal value to a color
        Color mappedColor;
        if (arousalValue <= 0.300f)
        {
            // Low arousal category
            mappedColor = lowArousalColor;
        }
        else if (arousalValue <= 0.550f)
        {
            // Medium arousal category
            mappedColor = mediumArousalColor;
        }
        else
        {
            // High arousal category
            mappedColor = highArousalColor;
        }

        // Set the mapped color to the spotlight
        spotlight.color = mappedColor;
    }
}

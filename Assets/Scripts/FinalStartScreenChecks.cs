using UnityEngine;

public class FinalStartScreenChecks : MonoBehaviour
{

    private ColourQuizManager colourQuizManager;

    public string lowValenceColor;
    public string lowMediumValenceColor;
    public string mediumHighValenceColor;
    public string highValenceColor;

    public string lowArousalColor;
    public string lowMediumArousalColor;
    public string mediumHighArousalColor;
    public string highArousalColor;


    // Start is called before the first frame update
    void Start()
    {
        // Find the ColourQuizManager component attached to the "Select Start Panel" game object.
        colourQuizManager = GameObject.Find("Select Start Panel").GetComponent<ColourQuizManager>();

        if (colourQuizManager == null)
        {
            Debug.LogError("ColourQuizManager not found in the scene or attached to the 'Select Start Panel' game object.");
        }
    }

    private void OnEnable()
    {
        // Check if the quiz is completed or not
        if (colourQuizManager != null && colourQuizManager.IsQuizComplete())
        {
            // Quiz completed
            Debug.Log("Quiz completed");
        }
        else
        {
            Debug.Log("Quiz completed");
            // Set the hex colors for different valence and arousal levels
            lowValenceColor = "#0D026E"; 
            lowMediumValenceColor = "#9DCAEB";
            mediumHighValenceColor = "#FFFF00"; 
            highValenceColor = "#FF00FF"; 

            lowArousalColor = "#ADD8E6"; 
            lowMediumArousalColor = "#F6C6BD"; 
            mediumHighArousalColor = "#FCDA3F"; 
            highArousalColor = "#F22400";

            Debug.Log("Quiz NOT completed");

        }
    }
}

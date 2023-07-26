using UnityEngine;

public class FinalStartScreenChecks : MonoBehaviour
{
    public string lowValenceColor;
    public string lowMediumValenceColor;
    public string mediumHighValenceColor;
    public string highValenceColor;

    public string lowArousalColor;
    public string lowMediumArousalColor;
    public string mediumHighArousalColor;
    public string highArousalColor;

    public Material LowValence;
    public Material LowMedValence;
    public Material MedHighValence;
    public Material HighValence;

    public Material LowArousal;
    public Material LowMedArousal;
    public Material MedHighArousal;
    public Material HighArousal;

    public void OnQuizCompleted()
    {
        // Quiz completed
        Debug.Log("Quiz completed");
        lowValenceColor = ColorUtility.ToHtmlStringRGB(LowValence.color);
        lowMediumValenceColor = ColorUtility.ToHtmlStringRGB(LowMedValence.color);
        Debug.Log("example mat colours");
        Debug.Log(lowValenceColor);
        Debug.Log(lowMediumValenceColor);
    }

    public void OnQuizNotCompleted(){

        Debug.Log("Quiz not completed");

        // Set the hex colors for different valence and arousal levels
        lowValenceColor = "0D026E"; 
        lowMediumValenceColor = "9DCAEB";
        mediumHighValenceColor = "FFFF00"; 
        highValenceColor = "FF00FF"; 

        lowArousalColor = "ADD8E6"; 
        lowMediumArousalColor = "F6C6BD"; 
        mediumHighArousalColor = "FCDA3F"; 
        highArousalColor = "F22400";

        Debug.Log("example preset colours");
        Debug.Log(lowValenceColor);
        Debug.Log(lowMediumValenceColor);

    }
    public void StartGame(){
        Debug.Log("Game starting!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("2. VR_Room_Official");

    }
    
}

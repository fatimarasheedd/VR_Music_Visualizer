using UnityEngine;

public class FinalStartScreenChecks : MonoBehaviour
{
    public static string lowValenceColor;
    public static string lowMediumValenceColor;
    public static string mediumHighValenceColor;
    public static string highValenceColor;

    public static string lowArousalColor;
    public static string lowMediumArousalColor;
    public static string mediumHighArousalColor;
    public static string highArousalColor;

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
        lowValenceColor = ColorUtility.ToHtmlStringRGB(LowValence.color);
        lowMediumValenceColor = ColorUtility.ToHtmlStringRGB(LowMedValence.color);
        mediumHighValenceColor = ColorUtility.ToHtmlStringRGB(MedHighValence.color);
        highValenceColor = ColorUtility.ToHtmlStringRGB(HighValence.color);

        lowArousalColor = ColorUtility.ToHtmlStringRGB(LowArousal.color);
        lowMediumArousalColor = ColorUtility.ToHtmlStringRGB(LowMedArousal.color);
        mediumHighArousalColor = ColorUtility.ToHtmlStringRGB(MedHighArousal.color);
        highArousalColor = ColorUtility.ToHtmlStringRGB(HighArousal.color);

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

    }
    public void StartGame(){
        Debug.Log("Game starting!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("2. VR_Room_Official");

    }
    
}

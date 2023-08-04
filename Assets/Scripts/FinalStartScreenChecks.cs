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

    // all the combined materials based on the grid
    public Material HighALowV;
    public Material HighAMedV;
    public Material HighAHighV;
    public Material MedALowV;
    public Material MedAMedV;
    public Material MedAHighV;
    public Material LowALowV;
    public Material LowAMedV;
    public Material LowAHighV;

    public static string HighALowVColour;
    public static string HighAMedVColour;
    public static string HighAHighVColour;
    public static string MedALowVColour;
    public static string MedAMedVColour;
    public static string MedAHighVColour;
    public static string LowALowVColour;
    public static string LowAMedVColour;
    public static string LowAHighVColour;

    public GameObject selectArousalValue;
    public GameObject colourQuizPanel; 

    public void OnQuizCompleted()
    {
        // Quiz completed

        if (colourQuizPanel == null )
        {
            lowValenceColor = "#" + ColorUtility.ToHtmlStringRGB(LowValence.color);
            lowMediumValenceColor = "#" + ColorUtility.ToHtmlStringRGB(LowMedValence.color);
            mediumHighValenceColor = "#" + ColorUtility.ToHtmlStringRGB(MedHighValence.color);
            highValenceColor = "#" + ColorUtility.ToHtmlStringRGB(HighValence.color);
        
            if (selectArousalValue != null) {
                lowArousalColor = "#" + ColorUtility.ToHtmlStringRGB(LowArousal.color);
                lowMediumArousalColor = "#" + ColorUtility.ToHtmlStringRGB(LowMedArousal.color);
                mediumHighArousalColor = "#" + ColorUtility.ToHtmlStringRGB(MedHighArousal.color);
                highArousalColor = "#" + ColorUtility.ToHtmlStringRGB(HighArousal.color);
            } 
        }

        else {
            HighALowVColour = "#" + ColorUtility.ToHtmlStringRGB(HighALowV.color);
            MedALowVColour = "#" + ColorUtility.ToHtmlStringRGB(MedALowV.color);
            LowALowVColour = "#" + ColorUtility.ToHtmlStringRGB(LowALowV.color);
            HighAMedVColour = "#" + ColorUtility.ToHtmlStringRGB(HighAMedV.color);
            MedAMedVColour = "#" + ColorUtility.ToHtmlStringRGB(MedAMedV.color);
            LowAMedVColour = "#" + ColorUtility.ToHtmlStringRGB(LowAMedV.color);
            HighAHighVColour = "#" + ColorUtility.ToHtmlStringRGB(HighAHighV.color);
            MedAHighVColour = "#" + ColorUtility.ToHtmlStringRGB(MedAHighV.color);
            LowAHighVColour = "#" + ColorUtility.ToHtmlStringRGB(LowAHighV.color);

        }

    }

    public void OnQuizNotCompleted(){

        if (colourQuizPanel == null )
        {
            // Set the hex colors for different valence and arousal levels
            lowValenceColor = "#0D026E"; 
            lowMediumValenceColor = "#9DCAEB";
            mediumHighValenceColor = "#FFFF00"; 
            highValenceColor = "#FF00FF"; 
            
            if (selectArousalValue != null){
                lowArousalColor = "#ADD8E6"; 
                lowMediumArousalColor = "#F6C6BD"; 
                mediumHighArousalColor = "#FCDA3F"; 
                highArousalColor = "#F22400";
            }
        }
        else {
            // red ish colour
            HighALowVColour = "#FF1100";
            // dark purple ish 
            MedALowVColour = "#3D0087";
            // black - dark brown - grey 
            LowALowVColour = "#4A4A4A";
            // light pink 
            HighAMedVColour = "#FFA6F9";
            // yellow - green
            MedAMedVColour = "#89AD4E";
            // dark green
            LowAMedVColour = "#003006";
            // yellow 
            HighAHighVColour = "#DCE305";
            // bright blue
            MedAHighVColour = "#29DFFF";
            // white 
            LowAHighVColour = "#F0F0F0";
        }
        

    }
    public void StartGame(){
        Debug.Log("Game starting!");
        if (colourQuizPanel == null ){
            if (selectArousalValue != null){
            UnityEngine.SceneManagement.SceneManager.LoadScene("2. VR_Room_Official");
            }
            else {
                UnityEngine.SceneManagement.SceneManager.LoadScene("2. VR_Room_Official3");
            }
        }
        else {
            UnityEngine.SceneManagement.SceneManager.LoadScene("2. VR_Room_Official2");
        }
        
    }
    
}

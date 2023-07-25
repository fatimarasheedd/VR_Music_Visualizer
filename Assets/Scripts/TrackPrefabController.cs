using UnityEngine;
using UnityEngine.UI;

public class TrackPrefabController : MonoBehaviour
{
    // Store the selected track details in static variables
    public static string selectedSong;
    public static float selectedValence;
    public static float selectedArousal;

    private string trackName;
    private float valence;
    private float arousal;

    public void Initialize(string trackName, float valence, float arousal)
    {
        this.trackName = trackName;
        this.valence = valence;
        this.arousal = arousal;
    }

    public void OnTrackButtonClick()
    {
        selectedSong = trackName;
        selectedValence = valence;
        selectedArousal = arousal;

        Debug.Log("Selected Song: " + selectedSong);
        Debug.Log("Selected Valence: " + selectedValence);
        Debug.Log("Selected Arousal: " + selectedArousal);

        GameObject libraryPanel = GameObject.Find("Library Panel");

        // Disable the Library panel
        if (libraryPanel != null)
        {
            libraryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("LibraryPanel GameObject not found.");
        }

        GameObject selectPanel = GameObject.Find("Select Start Panel");

        // Enable the Select panel
        if (selectPanel != null)
        {
            selectPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("SelectPanel GameObject not found.");
        }
    }
}

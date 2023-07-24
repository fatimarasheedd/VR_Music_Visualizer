using UnityEngine;
using UnityEngine.UI;

public class TrackPrefabController : MonoBehaviour
{
    private string trackName;


    public void Initialize(string trackName)
    {
        this.trackName = trackName;
    }

    public void OnTrackButtonClick()
    {
        Debug.Log(trackName + " button clicked");

        GameObject libraryPanel = GameObject.Find("Library Panel");

        // Disable the Library panel
        if (libraryPanel != null)
        {
            libraryPanel.SetActive(false);
            Debug.Log("Lib panel found");
        }
        else
        {
            Debug.LogError("LibraryPanel GameObject not found.");
        }

        GameObject selectPanel = GameObject.Find("Select Panel");

        // Enable the Select panel
        if (selectPanel != null)
        {
            selectPanel.SetActive(true);
            Debug.Log("Select panel found");

        }
        else
        {
            Debug.LogError("SelectPanel GameObject not found.");
        }
    }
}

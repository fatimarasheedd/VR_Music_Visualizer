using UnityEngine;

public class SetupVisualiser : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("audio process start");
        string selectedTrackName = TrackPrefabController.selectedSong;
        
        Debug.Log("Looking for " + selectedTrackName);
        // Load the selected audio clip based on the selectedTrackName
        AudioClip selectedAudioClip = Resources.Load<AudioClip>(selectedTrackName);

        // Check if the audio clip is valid
        if (selectedAudioClip != null)
        {
            // Find the existing audio source component on the audio game object
            AudioSource audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();

            // Assign the loaded audio clip to the existing audio source component
            audioSource.clip = selectedAudioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Selected audio clip is null. Make sure the audio clip exists in the 'Audio' folder.");
        }

        // Get the reference to the Lights game object
        GameObject lightsGameObject = GameObject.Find("Lights");

        // Get the ValenceSpotLight and ArousalSpotLight child game objects
        GameObject valenceSpotLight = lightsGameObject.transform.Find("ValenceSpotLight").gameObject;
        GameObject arousalSpotLight = lightsGameObject.transform.Find("ArousalSpotLight").gameObject;

        // // Set the color of the ValenceSpotLight based on selected valence
        // if (TrackPrefabController.selectedValence <= 0.25f)
        // {
        //     valenceSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.lowValenceColor;
        // }
        // else if (TrackPrefabController.selectedValence <= 0.5f)
        // {
        //     valenceSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.lowMediumValenceColor;
        // }
        // else if (TrackPrefabController.selectedValence <= 0.75f)
        // {
        //     valenceSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.mediumHighValenceColor;
        // }
        // else if (TrackPrefabController.selectedValence <= 1.5f)
        // {
        //     valenceSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.highValenceColor;
        // }

        // // Set the color of the ArousalSpotLight based on selected arousal
        // if (TrackPrefabController.selectedArousal <= 0.25f)
        // {
        //     arousalSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.lowArousalColor;
        // }
        // else if (TrackPrefabController.selectedArousal <= 0.5f)
        // {
        //     arousalSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.lowMediumArousalColor;
        // }
        // else if (TrackPrefabController.selectedArousal <= 0.75f)
        // {
        //     arousalSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.mediumHighArousalColor;
        // }
        // else if (TrackPrefabController.selectedArousal <= 1.0f)
        // {
        //     arousalSpotLight.GetComponent<Light>().color = FinalStartScreenChecks.highArousalColor;
        // }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

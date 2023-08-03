
using UnityEngine;

public class SetupVariablesExperiment3 : MonoBehaviour
{
// Start is called before the first frame update
    void Awake()
    {
        string selectedTrackName = TrackPrefabController.selectedSong;
        
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
        GameObject valenceSpotLight2 = lightsGameObject.transform.Find("ValenceSpotLight2").gameObject;
        GameObject arousalSpotLight2 = lightsGameObject.transform.Find("ArousalSpotLight2").gameObject;

        Debug.Log(TrackPrefabController.selectedValence + " this is the value");
        
        if (TrackPrefabController.selectedValence <= 0.25f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.lowValenceColor, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;

        }
        else if (TrackPrefabController.selectedValence <= 0.5f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.lowMediumValenceColor, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;

        }
        else if (TrackPrefabController.selectedValence <= 0.75f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.mediumHighValenceColor, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;

        }
        else if (TrackPrefabController.selectedValence <= 1.0f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.highValenceColor, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }


    }
}

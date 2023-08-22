using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupVariableExperiment2 : MonoBehaviour
{
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


        // low A low V
        if (TrackPrefabController.selectedArousal <= 0.33f && TrackPrefabController.selectedValence <= 0.33f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.LowALowVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // low A med V
        else if (TrackPrefabController.selectedArousal <= 0.33f && TrackPrefabController.selectedValence <= 0.66f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.LowAMedVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // low A high  V
        else if (TrackPrefabController.selectedArousal <= 0.33f && TrackPrefabController.selectedValence <= 1.00f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.LowAHighVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // med A low V
        else if (TrackPrefabController.selectedArousal <= 0.66f && TrackPrefabController.selectedValence <= 0.33f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.MedALowVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // med A med V
        else if (TrackPrefabController.selectedArousal <= 0.66f && TrackPrefabController.selectedValence <= 0.66f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.MedAMedVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // med A high  V
        else if (TrackPrefabController.selectedArousal <= 0.66f && TrackPrefabController.selectedValence <= 1.00f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.MedAHighVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // high A low V
        else if (TrackPrefabController.selectedArousal <= 1.00f && TrackPrefabController.selectedValence <= 0.33f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.HighALowVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // high A med V
        else if (TrackPrefabController.selectedArousal <= 1.00f && TrackPrefabController.selectedValence <= 0.66f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.HighAMedVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

        // high A high  V
        else if (TrackPrefabController.selectedArousal <= 1.00f && TrackPrefabController.selectedValence <= 1.00f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.HighAHighVColour, out Color color);
            arousalSpotLight.GetComponent<Light>().color = color;
            arousalSpotLight2.GetComponent<Light>().color = color;
            valenceSpotLight.GetComponent<Light>().color = color;
            valenceSpotLight2.GetComponent<Light>().color = color;
        }

    }
}

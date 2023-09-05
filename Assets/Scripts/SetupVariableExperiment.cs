using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupVariableExperiment : MonoBehaviour
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
        GameObject Spotlight1 = lightsGameObject.transform.Find("Spotlight1").gameObject;
        GameObject Spotlight2 = lightsGameObject.transform.Find("Spotlight2").gameObject;
        GameObject Spotlight3 = lightsGameObject.transform.Find("Spotlight3").gameObject;
        GameObject Spotlight4 = lightsGameObject.transform.Find("Spotlight4").gameObject;


        // low A low V
        if (TrackPrefabController.selectedArousal <= 0.33f && TrackPrefabController.selectedValence <= 0.33f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.LowALowVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // low A med V
        else if (TrackPrefabController.selectedArousal <= 0.33f && TrackPrefabController.selectedValence <= 0.66f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.LowAMedVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // low A high  V
        else if (TrackPrefabController.selectedArousal <= 0.33f && TrackPrefabController.selectedValence <= 1.00f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.LowAHighVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // med A low V
        else if (TrackPrefabController.selectedArousal <= 0.66f && TrackPrefabController.selectedValence <= 0.33f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.MedALowVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // med A med V
        else if (TrackPrefabController.selectedArousal <= 0.66f && TrackPrefabController.selectedValence <= 0.66f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.MedAMedVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // med A high  V
        else if (TrackPrefabController.selectedArousal <= 0.66f && TrackPrefabController.selectedValence <= 1.00f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.MedAHighVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // high A low V
        else if (TrackPrefabController.selectedArousal <= 1.00f && TrackPrefabController.selectedValence <= 0.33f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.HighALowVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // high A med V
        else if (TrackPrefabController.selectedArousal <= 1.00f && TrackPrefabController.selectedValence <= 0.66f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.HighAMedVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

        // high A high  V
        else if (TrackPrefabController.selectedArousal <= 1.00f && TrackPrefabController.selectedValence <= 1.00f)
        {
            ColorUtility.TryParseHtmlString(FinalStartScreenChecks.HighAHighVColour, out Color color);
            Spotlight1.GetComponent<Light>().color = color;
            Spotlight2.GetComponent<Light>().color = color;
            Spotlight3.GetComponent<Light>().color = color;
            Spotlight4.GetComponent<Light>().color = color;
        }

    }
}

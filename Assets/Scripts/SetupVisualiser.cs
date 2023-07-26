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


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

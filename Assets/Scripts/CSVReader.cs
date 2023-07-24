using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.EventSystems;


public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;
    public GameObject trackPanelPrefab;
    public static string selectedSong; 
    public static int selectedValence; 
    public static int selectedArousal;

    [System.Serializable]

    public class TrackInfo
    {
        public string Track;
        public string Artist;
        public string ID;
        public float Valence;
        public float Energy;
    }

    [System.Serializable]

    public class TrackList
    {
        public TrackInfo[] track;
    }

    public TrackList myTrackList = new TrackList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    // Read CSV file
    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);
        int tableSize = data.Length / 4 - 1;
        myTrackList.track = new TrackInfo[tableSize];
        
        // track the spacing
        float verticalSpacing = 100f;
        float currentVerticalPosition = 0f;

        // creating memory space for those variables
        for (int i = 0; i < tableSize; i++)
        {
            myTrackList.track[i] = new TrackInfo();
            myTrackList.track[i].Track = data[5 * (i + 1)];
            myTrackList.track[i].Artist = data[5 * (i + 1) + 1];
            myTrackList.track[i].ID = data[5 * (i + 1) + 2];
            myTrackList.track[i].Valence = float.Parse(data[5 * (i + 1) + 3]);
            myTrackList.track[i].Energy = float.Parse(data[5 * (i + 1) + 4]);

            if (!string.IsNullOrEmpty(myTrackList.track[i].Track))
            {
                
                // Load the sprite from the "album_artwork" folder using the Track-Artist name
                string imagePath = "Assets/album_artwork/" + myTrackList.track[i].Track + "-" + myTrackList.track[i].Artist + ".jpg";
                Sprite loadedSprite = LoadSpriteFromFile(imagePath);

                GameObject newTrack = Instantiate(trackPanelPrefab, transform.position, transform.rotation) as GameObject;
                newTrack.transform.SetParent(GameObject.FindGameObjectWithTag("Lib").transform, false);
                
                TrackPrefabController trackPrefabController = newTrack.GetComponent<TrackPrefabController>();

                // Check if the component exists (it should if you attached the TrackPrefabController script to the prefab)
                if (trackPrefabController != null)
                {
                    // Initialize the trackPrefabController with the track name
                    trackPrefabController.Initialize(myTrackList.track[i].Track);
                }
                else
                {
                    Debug.LogError("TrackPrefabController component not found on the prefab.");
                }
                
                Image coverImage = newTrack.transform.Find("Cover")?.GetComponent<Image>();

                if (coverImage != null && loadedSprite != null)
                {
                    coverImage.sprite = loadedSprite;

                    // add album name and artist name
                    TextMeshProUGUI songNameText = newTrack.transform.Find("SongName")?.GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI artistText = newTrack.transform.Find("Artist")?.GetComponent<TextMeshProUGUI>();

                    if (songNameText != null)
                    {
                        songNameText.text = myTrackList.track[i].Track;
                    }
                    else
                    {
                        Debug.LogError("SongName TextMeshProUGUI component not found on the prefab.");
                    }

                    if (artistText != null)
                    {
                        artistText.text = myTrackList.track[i].Artist;
                    }
                    else
                    {
                        Debug.LogError("Artist TextMeshProUGUI component not found on the prefab.");
                    }
                    
                }
            
            }

        }
    }

    private Sprite LoadSpriteFromFile(string path)
    {
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2); // You can adjust the texture size according to your images
            if (texture.LoadImage(bytes))
            {
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        }
        return null;
    }

}

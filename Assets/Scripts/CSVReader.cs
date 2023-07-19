using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;
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

        // creating memory space for those variables
        for (int i = 0; i < tableSize; i++)
        {
            myTrackList.track[i] = new TrackInfo();
            myTrackList.track[i].Track = data[5 * (i + 1)];
            myTrackList.track[i].Artist = data[5 * (i + 1) + 1];
            myTrackList.track[i].ID = data[5 * (i + 1) + 2];
            myTrackList.track[i].Valence = float.Parse(data[5 * (i + 1) + 3]);
            myTrackList.track[i].Energy = float.Parse(data[5 * (i + 1) + 4]);

        }

    }

}

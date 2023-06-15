using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// require component of audio
[RequireComponent (typeof (AudioSource))]

public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public float[] _freqBand = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++){

            int sampleCount = (int)Mathf.Pow(2,i)*2;
            float average = 0;

            if (i==7) {
                sampleCount += 2;
            }

            // send samples into frequency bands
            for (int j = 0; j <sampleCount; j++) {
                average += _samples[count] * (count + 1);
                    count++;
            }

            average /= count;
            _freqBand[i] = average * 10;
        }
    }
}


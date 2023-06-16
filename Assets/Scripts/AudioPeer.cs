using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// require component of audio
[RequireComponent (typeof (AudioSource))]

public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    float[] _freqBand = new float[8];
    float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    // new + everything above used to be public static
    float[] _freqBandHighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

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
        BandBuffer();
        CreateAudioBands();
    }
    // new 
    void CreateAudioBands()
    {
        for(int i=0; i<8;i++)
        {
            if (_freqBand[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);


        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g){
            if (_freqBand [g] > _bandBuffer[g]){
                _bandBuffer [g] = _freqBand [g];
                _bufferDecrease[g] = 0.0001f;
            }
            if (_freqBand [g] < _bandBuffer[g]){
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.05f;
            }

        }


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


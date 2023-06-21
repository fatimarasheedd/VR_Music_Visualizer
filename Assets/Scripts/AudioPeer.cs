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

    float[] _freqBandHighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

    public static float[] _Amplitude, _AmplitudeBuffer;
    float _AmplitudeHighest;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _Amplitude = new float[1]; // Allocate memory for _Amplitude array
        _AmplitudeBuffer = new float[1]; // Allocate memory for _AmplitudeBuffer array
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }
    
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

    void GetAmplitude()
    {
        float _CurrentAmplitude = 0;
        float _CurrentAmplitudeBuffer = 0;

        for (int i=0; i < 8; i++){
            _CurrentAmplitude += _audioBand[i];
            _CurrentAmplitudeBuffer += _audioBandBuffer[i];
        }
        if (_CurrentAmplitude > _AmplitudeHighest) {
            _AmplitudeHighest = _CurrentAmplitude;
        }
        _Amplitude[0] = _CurrentAmplitude / _AmplitudeHighest;
        _AmplitudeBuffer[0] = _CurrentAmplitudeBuffer / _AmplitudeHighest;

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
                _bufferDecrease[g] = 0.1f;
            }
            if (_freqBand [g] < _bandBuffer[g]){
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.08f;
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


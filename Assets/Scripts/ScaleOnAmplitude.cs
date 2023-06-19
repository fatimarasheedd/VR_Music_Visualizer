using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float _startScale, _maxScale;
    public bool _useBuffer;
    Material _material;
    public float _red, _green, _blue;

    // so it follows bpm
    public float _bpm;
    private float _beatInterval;
    private float _nextBeatTime;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer> ().materials [0];

        // Calculate the time interval between beats based on the BPM
        _beatInterval = 60f / _bpm;
        _nextBeatTime = Time.time + _beatInterval; // Schedule the first beat
    
    }

    // Update is called once per frame
    void Update()
    {
        if(!_useBuffer){
            transform.localScale = new Vector3((AudioPeer._Amplitude[0] * _maxScale) + _startScale,(AudioPeer._Amplitude[0] * _maxScale) + _startScale,(AudioPeer._Amplitude[0] * _maxScale) + _startScale );
            Color _color = new Color (_red * AudioPeer._Amplitude[0], _green * AudioPeer._Amplitude[0], _blue * AudioPeer._Amplitude[0] );
            _material.SetColor ("_EmissionColor", _color);
        }
        if(_useBuffer){
            transform.localScale = new Vector3((AudioPeer._AmplitudeBuffer[0] * _maxScale) + _startScale,(AudioPeer._AmplitudeBuffer[0] * _maxScale) + _startScale,(AudioPeer._AmplitudeBuffer[0] * _maxScale) + _startScale );
            Color _color = new Color (_red * AudioPeer._AmplitudeBuffer[0], _green * AudioPeer._AmplitudeBuffer[0], _blue * AudioPeer._AmplitudeBuffer[0]);
            _material.SetColor ("_EmissionColor", _color);
        }

        if (Time.time >= _nextBeatTime)
        {
            // Randomly increase or decrease the scale of the object
            float randomScale = Random.Range(-0.1f, 0.1f);
            transform.localScale += new Vector3(randomScale, randomScale, randomScale);

            // Schedule the next beat
            _nextBeatTime += _beatInterval;
        }
    }
}

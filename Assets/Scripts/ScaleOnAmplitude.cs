using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float _startScale, _maxScale;
    public bool _useBuffer;
    Material _material;
    public float _red, _green, _blue;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer> ().materials [0];

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

    }
}

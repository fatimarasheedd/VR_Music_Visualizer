using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    AudioPeer _audioPeer;

    // Start is called before the first frame update
    void Start()
    {
        _audioPeer = FindObjectOfType<AudioPeer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x,(_audioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    public float _maxScale;
    // store in an array
    GameObject[] _sampleCube = new GameObject[512];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;

            // make it in a circle (360/512)
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 400;
            _sampleCube[i] = _instanceSampleCube;

        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(50, (AudioPeer._samples[i] * _maxScale) * 50, 50);
            }
        }
    }
}


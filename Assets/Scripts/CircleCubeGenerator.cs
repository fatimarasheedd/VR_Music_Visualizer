using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCubeGenerator : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    public int _numCubes = 32;
    public float _radius = 10f;
    public float _maxScale = 2f;
    public float _thicknessScale = 2f; 

    public Material _paramCubeMaterial; 

    private GameObject[] _sampleCube;


    void Start()
    {
        _sampleCube = new GameObject[_numCubes];

        float angleIncrement = 360f / _numCubes;

        for (int i = 0; i < _numCubes; i++)
        {
            GameObject _instanceSampleCube = Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = transform.position + Quaternion.Euler(0, angleIncrement * i, 0) * Vector3.forward * _radius;
            _instanceSampleCube.transform.parent = transform;
            _instanceSampleCube.name = "SampleCube" + i;

            // Apply the ParamCube material
            MeshRenderer cubeRenderer = _instanceSampleCube.GetComponent<MeshRenderer>();
            cubeRenderer.material = _paramCubeMaterial;
            
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    void Update()
    {
        for (int i = 0; i < _numCubes; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(1, (AudioPeer._audioBandBuffer[i % AudioPeer._audioBandBuffer.Length] * _maxScale * _thicknessScale) + 1f, 1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundWaveGenerator : MonoBehaviour
{
    AudioPeer _audioPeer;
    // represents audio spectrum split into 8192 frequency bins
    const int SpectrumSize = 8192;
    readonly float[] _spectrum = new float[SpectrumSize];
    public LineRenderer _topLine;
    public LineRenderer _bottomLine;

    public void Start()
    {
        _audioPeer = FindObjectOfType<AudioPeer>();
    }

    public void Update()
    {
        _audioPeer.GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);

        var bandSize = 1.1f;
        var crossover = bandSize;
        var viewSpectrum = new List<float>();
        var b = 0f;

        // taking the data from _spectrum and creating a simplified version in viewSpectrum array
        for (var i = 0; i < SpectrumSize; i++)
        {
            var d = _spectrum[i];
            b = Mathf.Max(d, b); // find the max as the peak value in that frequency band.
            if (i > crossover - 3)
            {
                crossover *= bandSize; // frequency crossover point for each band.
                viewSpectrum.Add(b);
                b = 0;
            }
        }

        SetLinePoints(viewSpectrum, _topLine);
        SetLinePoints(viewSpectrum, _bottomLine, -1);
    }

    private void SetLinePoints(List<float> viewSpectrum, LineRenderer lineRenderer, float modifier = 1)
    {
        // this value is increased to create the illusion of thickness
        var pointDistance = 0.5f;
        var width = pointDistance * (viewSpectrum.Count - 1);

        lineRenderer.positionCount = viewSpectrum.Count;
        lineRenderer.SetPositions(viewSpectrum.Select((x, i) => new Vector3(-width / 2 + i * pointDistance, x * 34 * modifier, 0)).ToArray());
    }
}

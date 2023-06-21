using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMController : MonoBehaviour
{
    public AudioSource audioSource;
    public float sphereSpeedMultiplier = 1f;
    public GameObject[] ampSpheres;

    public float bpm;
    private float previousTime;
    private float deltaTime;
    private bool isCalculatingBPM; 

    // Start is called before the first frame update
    void Start()
    {
        previousTime = Time.time;
        deltaTime = 0f;
        isCalculatingBPM = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCalculatingBPM)
        {
            deltaTime += Time.time - previousTime;
            previousTime = Time.time;

            if (deltaTime >= 60f)
            {
                bpm = 60f/deltaTime;
                deltaTime = 0f;
                isCalculatingBPM = false;
                AdjustSphereSpeed();
            }
        }

        UnityEngine.Debug.Log(bpm);
    }

    void AdjustSphereSpeed(){
        float speedSphere = bpm * sphereSpeedMultiplier;

        foreach (GameObject ampSphere in ampSpheres)
        {
            if (ampSphere != null){
                Rigidbody sphereRigidBody = ampSphere.GetComponent<Rigidbody>();
                if (sphereRigidBody != null)
                {
                    sphereRigidBody.velocity =Vector3.forward * speedSphere;
                }
            }
        }

    }
}

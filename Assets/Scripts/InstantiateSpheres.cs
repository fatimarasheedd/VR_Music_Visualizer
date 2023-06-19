using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpheres : MonoBehaviour
{
    public GameObject spherePrefab;
    public int numSpheres = 10;
    public float radius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate spheres within the room object
        for (int i = 0; i < numSpheres; i++)
        {
            // Calculate the position of the sphere along a circle
            float angle = i * 2f * Mathf.PI / numSpheres;
            Vector3 position = transform.position + new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);

            // Instantiate the sphere
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
            sphere.transform.parent = transform;
        }
    }
}
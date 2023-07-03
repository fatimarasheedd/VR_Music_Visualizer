using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoundsCalculator : MonoBehaviour
{
    public GameObject Room;
    public GameObject AmplitudeSpheres;

    public Bounds CalculateRoomBounds()
    {
        // Get the colliders of the room walls
        Collider[] wallColliders = Room.GetComponentsInChildren<Collider>();

        // Get the colliders of the spheres
        Collider[] sphereColliders = AmplitudeSpheres.GetComponentsInChildren<Collider>();

        // Create an empty bounds object to hold the room bounds
        Bounds roomBounds = new Bounds();

        // Iterate over the wall colliders and encapsulate their bounds within roomBounds
        foreach (Collider wallCollider in wallColliders)
        {
            roomBounds.Encapsulate(wallCollider.bounds);
        }

        // Iterate over the sphere colliders and encapsulate their bounds within roomBounds
        foreach (Collider sphereCollider in sphereColliders)
        {
            roomBounds.Encapsulate(sphereCollider.bounds);
        }

        // Return the calculated room bounds
        return roomBounds;
    }


    // Start is called before the first frame update
    void Start()
    {
        Bounds roomBounds = CalculateRoomBounds();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

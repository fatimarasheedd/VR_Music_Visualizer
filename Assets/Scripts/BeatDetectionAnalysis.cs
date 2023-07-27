using UnityEngine;

public class BeatDetectionAnalysis : MonoBehaviour
{
    private int beatCount = 0; // Counter for beat detection
    private float elapsedTime = 0f; // Elapsed time since the last BPM calculation
    private int beatsInInterval = 0; // Number of beats in the current interval
    private float intervalDuration = 15f; // Duration of the interval in seconds

    // Reference to the RoomBoundsCalculator GameObject
    public GameObject calculateBoundary;

    // Reference to the calculated room bounds
    private Bounds roomBounds;

    void Start()
    {
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);

        // Get the room bounds from the RoomBoundsCalculator script
        RoomBoundsCalculator boundsCalculator = calculateBoundary.GetComponent<RoomBoundsCalculator>();
        roomBounds = boundsCalculator.CalculateRoomBounds();
        ConstrainChildSpheresToBounds();
    }

    //this event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector
    //to adjust the sensitivity
    void onOnbeatDetected()
    {
        beatCount++;
        beatsInInterval++;
    }

    //This event will be called every frame while music is playing
    void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }

        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the interval has passed
        if (elapsedTime >= intervalDuration)
        {
            // Calculate the BPM
            float bpm = (beatsInInterval / intervalDuration) * 60f;

            // Reset the counters and elapsed time
            beatsInInterval = 0;
            elapsedTime = 0f;

            // Log the BPM
            Debug.Log("BPM: " + bpm);

            // Set the velocity of child spheres based on BPM
            SetChildSpheresVelocity(bpm);
            ConstrainChildSpheresToBounds();
        }
    }

    void SetChildSpheresVelocity(float bpm)
    {
        // Find all child spheres with the name "AmpSphere"
        ScaleOnAmplitude[] childSpheres = GetComponentsInChildren<ScaleOnAmplitude>();

        // Set the velocity of each child sphere
        foreach (ScaleOnAmplitude sphere in childSpheres)
        {
            Rigidbody rb = sphere.GetComponent<Rigidbody>();
            if (rb != null)
            {
                 // Adjust the vertical velocity based on the BPM
                Vector3 velocity = new Vector3(rb.velocity.x, bpm, rb.velocity.z);
                rb.velocity = velocity;
            }
        }
    }

    // confinement and redirection logic
    void ConstrainChildSpheresToBounds()
    {
        ScaleOnAmplitude[] childSpheres = GetComponentsInChildren<ScaleOnAmplitude>();

        foreach (ScaleOnAmplitude sphere in childSpheres)
        {
            Rigidbody rb = sphere.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Constrain the sphere within the room bounds
                Vector3 newPosition = roomBounds.ClosestPoint(rb.position);
                rb.position = newPosition;
            }
        }
    }
}

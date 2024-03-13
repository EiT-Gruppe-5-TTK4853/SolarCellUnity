using UnityEngine;

public class SunSimulator : MonoBehaviour
{
    public float dayDurationInSeconds = 60f; // Duration of one full day cycle in seconds.
    private float startTime; // Time when the simulation started.

    private void Start()
    {
        // Record the start time of the simulation.
        startTime = Time.time;
    }

    private void Update()
    {
        // Calculate the current time elapsed since the start of the simulation.
        float timeSinceStart = Time.time - startTime;
        // Calculate the current angle of rotation around the Y axis.
        float yaw = (timeSinceStart / dayDurationInSeconds) * 360f % 360;
        // Set the pitch to a constant 30 degrees.
        float pitch = 30f;
        // Keep the roll at 0 degrees.
        float roll = 0f;

        // Apply the calculated rotation to the sun.
        transform.rotation = Quaternion.Euler(pitch, yaw, roll);
    }
}


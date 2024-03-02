using UnityEngine;

public class SunSimulator : MonoBehaviour
{
    public float dayDurationInSeconds = 60f; // Duration of one full day cycle in seconds.

    private void Update()
    {
        // Calculate the rotation speed based on the day duration
        float rotationSpeed = 360f / dayDurationInSeconds; // 360 degrees divided by the number of seconds in a day
        // Rotate around the Y axis at rotationSpeed degrees per second
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}


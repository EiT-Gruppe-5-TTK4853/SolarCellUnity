using UnityEngine;

public class PlaneRotator : MonoBehaviour
{
    public float rotationSpeed = 10f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate around the Y axis at the specified speed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}

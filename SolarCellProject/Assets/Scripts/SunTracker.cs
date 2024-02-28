
using UnityEngine;

public class SunTracker : MonoBehaviour
{

    public Transform directionalLight;

    // Update is called once per frame
    void Update()
    {
        // Ensure there is a target to look at
        if (directionalLight != null)
        {
            Vector3 sunDirection = directionalLight.forward;

            float yaw = Mathf.Atan2(sunDirection.x, sunDirection.z) * Mathf.Rad2Deg;
            float pitch = Mathf.Asin(sunDirection.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }
    }
}

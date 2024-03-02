
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

            float yaw = Mathf.Atan2(sunDirection.x, sunDirection.z) * Mathf.Rad2Deg + 180f;
            float pitch = Mathf.Asin(sunDirection.y) * Mathf.Rad2Deg + 90f;
            if (pitch > 65f)
            {
                pitch = 65f;
            }
            else if (pitch < 10f)
            {
                pitch = 10f;
            }

            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }
    }
}

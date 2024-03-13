using UnityEngine;

public class SunTrackerYaw : MonoBehaviour
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

            if (yaw > 0)
            {
                yaw = yaw + 360;
            }
            
            transform.rotation = Quaternion.Euler(-90, yaw, 180f);
        }
    }
}


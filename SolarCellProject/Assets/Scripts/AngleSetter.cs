
using UnityEngine;

public class AngleSetter : MonoBehaviour
{
    public float yaw = 0f;
    public float pitch = 0f;

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = Quaternion.Euler(pitch, yaw, 0f);

        transform.rotation = newRotation;
    }
}

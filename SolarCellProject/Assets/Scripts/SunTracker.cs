
using UnityEngine;

public class SunTracker : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // Ensure there is a target to look at
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            target.rotation = targetRotation;
        }
    }
}

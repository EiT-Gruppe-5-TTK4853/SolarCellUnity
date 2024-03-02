using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualRefreshTrigger : MonoBehaviour
{
    public APIAccessor dataLoader; // Reference to your APIDataLoader script

    // Update is called once per frame
    void Update()
    {
        // Check if the R key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(dataLoader != null)
            {
                Debug.Log("Manually calling RefreshData");
                dataLoader.onRefresh();
            }
            else
            {
                Debug.LogError("DataLoader reference not set.");
            }
        }
    }
}

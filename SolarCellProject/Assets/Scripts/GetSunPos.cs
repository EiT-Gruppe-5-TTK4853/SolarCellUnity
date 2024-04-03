using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json;
using TMPro;

public class SunPositionController : MonoBehaviour
{
    public string apiUrl = "http://192.168.6.220:5000/solar/position"; // URL of the API
    public Light directionalLight; // Drag your directional light here in the inspector
    public TextMeshProUGUI sunPositionText;

    void getData()
    {
        if (directionalLight == null)
        {
            Debug.LogError("Directional light not assigned.");
            return;
        }
        if (sunPositionText == null)
        {
            Debug.LogError("TextMeshProUGUI not assigned.");
            return;
        }

        StartCoroutine(GetSunPosition());
    }

    void Start()
    {
        InvokeRepeating(nameof(getData), 0f, 10f); // Call getData every 10 seconds
    }

    IEnumerator GetSunPosition()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            // Send the request and wait for the response
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {   
                long statusCode = webRequest.responseCode;
                string statusMessage;
                if (statusCode == 0)
                {
                    statusMessage = "Server error. \nStatus code: 500";
                }
                else
                {
                    statusMessage = $"Error. \nStatus code: {statusCode}";
                }
                Debug.LogError("Error fetching sun position: " + webRequest.error);
                sunPositionText.text = $"Error fetching sun position \n{statusMessage}";
            }
            else
            {
                // Parse the response
                SunPositionData sunPosition = JsonConvert.DeserializeObject<SunPositionData>(webRequest.downloadHandler.text);

                sunPositionText.text = $"Altitude: {sunPosition.altitude * Mathf.Rad2Deg} deg\nAzimuth: {(sunPosition.azimuth + Mathf.PI) * Mathf.Rad2Deg} deg";

                // Convert azimuth angle to Unity rotation. Assume latitude is used for tilt.
                Quaternion sunRotation = Quaternion.Euler(sunPosition.altitude* Mathf.Rad2Deg, (sunPosition.azimuth + Mathf.PI)*Mathf.Rad2Deg, 0);
                directionalLight.transform.rotation = sunRotation;
            }
        }
    }

    // Class to match the JSON structure returned by the API
    private class SunPositionData
    {
        public float altitude { get; set; }
        public float azimuth { get; set; }
    }
}

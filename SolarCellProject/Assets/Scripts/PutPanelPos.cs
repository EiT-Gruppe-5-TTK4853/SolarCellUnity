using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class SolarPanelDataSender : MonoBehaviour
{
    public GameObject solarPanelObject; // Assign your solar panel object in the inspector
    private string url = "http://192.168.6.220:5000/solar/move"; // Your API endpoint

    void sendData()
    {
        StartCoroutine(SendSolarPanelData());
    }

    private void Start()
    {
        InvokeRepeating(nameof(sendData), 0f, 5f);
    }

    IEnumerator SendSolarPanelData()
    {
        // Extract pitch and yaw from the solar panel's rotation
        Vector3 rotation = solarPanelObject.transform.localEulerAngles;
        float pitch = rotation.x;
        float yaw = rotation.y;

        // Create the data object
        var dataObject = new
        {
            pitch = pitch,
            yaw = yaw
        };

        // Serialize the data object to JSON
        string jsonData = JsonConvert.SerializeObject(dataObject);

        using (UnityWebRequest www = UnityWebRequest.Put(url, jsonData))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
                Debug.LogError("Response: " + www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Success");
                Debug.Log("Response: " + www.downloadHandler.text);
            }
        }
    }
}

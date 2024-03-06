using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections;
using TMPro;

public class APIdata : MonoBehaviour
{
    public class Data
    {
        public double battery_current { get; set; }
        public double battery_temp { get; set; }
        public double battery_voltage { get; set; }
        public int id { get; set; }
        public double load_current { get; set; }
        public double load_voltage { get; set; }
        public double solar_current { get; set; }
        public double solar_power { get; set; }
        public double solar_voltage { get; set; }
    }

    public TextMeshProUGUI text; // Assign this in the inspector with your UI Text

    void Start()
    {
        Debug.Log("Start method called");
        // Assuming you have a different URI that returns the Root object data
        StartCoroutine(GetRequest("http://192.168.6.220:5000/solar"));
    }

    public void onRefresh()
    {
        Debug.Log("Refresh button clicked");
        Start();
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError($"Something went wrong: {webRequest.error}");
                    break;
                case UnityWebRequest.Result.Success:
                    Data data = JsonConvert.DeserializeObject<Data>(webRequest.downloadHandler.text);
                    // Example of how to display some of the data. Customize as needed.
                    string displayText = $"Battery Current: {data.battery_current}A\n" +
                                          $"Battery Temp: {data.battery_temp}deg\n" +
                                          $"Battery Voltage: {data.battery_voltage}V\n" +
                                          $"Load Current: {data.load_current}A\n" +
                                          $"Load Voltage: {data.load_voltage}V\n" +
                                          $"Solar Current: {data.solar_current}A\n" +
                                          $"Solar Power: {data.solar_power}W\n" +
                                          $"Solar Voltage: {data.solar_voltage}V";
                                          
                                          
                    text.text = displayText;
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Networking;

public class jsonformat : MonoBehaviour
{
  [System.Serializable]
public class JSONContainer
{
    public WorkcenterData[] data;
}
    public TextAsset jsonFile;
    // Start is called before the first frame update
    void Start()
    {
        //http://192.168.1.7:8080/get_machine_data
        Parser2();
     //   StartCoroutine(SendWebRequest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Parser2()
    {
        string json = "{\"data\":[{\"WorkcenterID\":1,\"WO_Number\":\"WO12345\",\"Workcenter_Name\":\"Rotor Shaft Press Fit\",\"Status\":\"Running\",\"Operation\":\"Rotor Shaft Press Fit\",\"Oil_Contamination\":20,\"Temperature\":80}]}";

        JSONContainer container = JsonUtility.FromJson<JSONContainer>(json);

        if (container != null && container.data != null && container.data.Length > 0)
        {
            WorkcenterData workcenterData = container.data[0];

            Debug.Log("Workcenter ID: " + workcenterData.WorkcenterID);
            Debug.Log("WO Number: " + workcenterData.WO_Number);
            Debug.Log("Workcenter Name: " + workcenterData.Workcenter_Name);
            Debug.Log("Status: " + workcenterData.Status);
            Debug.Log("Operation: " + workcenterData.Operation);
            Debug.Log("Oil_Contamination: " + workcenterData.Oil_Contamination);
            Debug.Log("Temperature: " + workcenterData.Temperature);
        }
        else
        {
            Debug.LogError("Failed to parse JSON.");
        }
    }
    IEnumerator SendWebRequest()
    {
        string url = "https://api.thingspeak.com/channels/308375/feeds.json?results=1"; // Replace with your web service URL
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        // Send the request
        yield return webRequest.SendWebRequest();

        // Handle the response
        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + webRequest.error);
        }
        else
        {
            // Request was successful; you can access the response data here
            string responseText = webRequest.downloadHandler.text;
            Debug.Log("Response: " + responseText);
        //  MyParser(responseText);
        }
    }   
}

[System.Serializable]
public class WorkcenterData
{
    [SerializeField]
    public int WorkcenterID;
    
    [SerializeField]
    public string WO_Number;

    [SerializeField]
    public string Workcenter_Name;

    [SerializeField]
    public string Status;

    [SerializeField]
    public string Operation;

    [SerializeField]
    public int Oil_Contamination;

    [SerializeField]
    public int Temperature;
}



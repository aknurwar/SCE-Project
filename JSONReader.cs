using UnityEngine;
using System.Collections.Generic;
public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile; // Reference to your JSON file in Unity's assets
    /*
{
    "data": [
        {
            "Oil_Contamination_Per": 20,
            "Operation": "Rotor Shaft Press Fit",
            "Status": "Running",
            "Temperature_Deg": 80,
            "WO_Number": "WO12345",
            "WorkcenterID": 1,
            "Workcenter_Name": "Rotor Shaft Press Fit"
        }
    ]
}
    */
    void Start()
    {
        // Read the JSON file as a string
        string jsonText = jsonFile.text;

        // Deserialize the JSON data into C# objects
        MyData myData = JsonUtility.FromJson<MyData>(jsonText);

        // Access the data
        foreach (DataItem item in myData.data)
        {
            Debug.Log("Operation: " + item.Operation);
            Debug.Log("Status: " + item.Status);
            Debug.Log("Temperature: " + item.Temperature_Deg);
            // Access other fields as needed
        }
    }
}
[System.Serializable]
public class MyData
{
    public List<DataItem> data;
}

[System.Serializable]
public class DataItem
{
    public float Oil_Contamination_Per;
    public string Operation;
    public string Status;
    public float Temperature_Deg;
    public string WO_Number;
    public int WorkcenterID;
    public string Workcenter_Name;
}


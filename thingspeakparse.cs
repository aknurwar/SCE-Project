using UnityEngine;

[System.Serializable]
public class Channel
{
    public int id;
    public string name;
    public string description;
    public string latitude;
    public string longitude;
    public string field1;
    public string field2;
    public string field3;
    public string field4;
    public string field5;
    public string field6;
    public string field7;
    public string created_at;
    public string updated_at;
    public int last_entry_id;
}

[System.Serializable]
public class Feed
{
    public string created_at;
    public int entry_id;
    public string field1;
    public string field2;
    public string field3;
    public string field4;
    public string field5;
    public string field6;
    public string field7;
}

[System.Serializable]
public class Data
{
    public Channel channel;
    public Feed[] feeds;
}

public class JsonParser : MonoBehaviour
{
    private void Start()
    {
        string json = "{\"channel\":{\"id\":308375,\"name\":\"Rotor Shaft Press Fit\",\"description\":\"Rotor Shaft Press Fit\",\"latitude\":\"0.0\",\"longitude\":\"0.0\",\"field1\":\"workcenterID\",\"field2\":\"wo_Number\",\"field3\":\"workcenter_Name\",\"field4\":\"status\",\"field5\":\"operation\",\"field6\":\"oil_Contamination\",\"field7\":\"temperature\",\"created_at\":\"2017-07-27T10:41:36Z\",\"updated_at\":\"2023-10-09T06:48:10Z\",\"last_entry_id\":1},\"feeds\":[{\"created_at\":\"2023-10-09T06:51:57Z\",\"entry_id\":1,\"field1\":\"1\",\"field2\":\"\\\"WO12345\\\"\",\"field3\":\"\\\"Rotor Shaft Press Fit\\\"\",\"field4\":\"\\\"Running\\\"\",\"field5\":\"\\\"Rotor Shaft Press Fit\\\"\",\"field6\":\"20\",\"field7\":\"80\"}]}";

        // Parse the JSON data into the Data class
        Data data = JsonUtility.FromJson<Data>(json);

        // Access the parsed data
        Debug.Log("Channel Name: " + data.channel.name);
        Debug.Log("First Feed Entry Field1: " + data.feeds[0].field1);
        Debug.Log("First Feed Entry Field2: " + data.feeds[0].field2);
        // Continue accessing other fields as needed
    }
}

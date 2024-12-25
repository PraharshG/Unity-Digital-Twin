using UnityEngine;
using System.Net.Sockets;
using System.IO;

public class MPUOrientation : MonoBehaviour
{
    TcpClient client;
    StreamReader reader;

    private float roll, pitch, yaw;

    void Start()
    {
        try
        {
            client = new TcpClient("localhost", 65432);
            reader = new StreamReader(client.GetStream());
            Debug.Log("Connected to Python socket server.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to connect to Python socket server: " + e.Message);
        }
    }

    void Update()
    {
        if (client != null && client.Connected && reader != null)
        {
            try
            {
                string data = reader.ReadLine();
                if (!string.IsNullOrEmpty(data))
                {
                    ParseData(data);
                    ApplyOrientation();
                }
            }
            catch (System.IO.IOException e)
            {
                Debug.LogError("Socket read error: " + e.Message);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Unexpected error: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("Client or reader is not initialized.");
        }
    }

    void ParseData(string data)
    {
        string[] values = data.Split(',');
        foreach (string value in values)
        {
            if (value.StartsWith("ROLL:"))
                roll = float.Parse(value.Substring(5));
            else if (value.StartsWith("PITCH:"))
                pitch = float.Parse(value.Substring(6));
            else if (value.StartsWith("YAW:"))
                yaw = float.Parse(value.Substring(4));
        }
    }

    void ApplyOrientation()
    {
        transform.rotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void OnApplicationQuit()
    {
        if (client != null)
        {
            client.Close();
            Debug.Log("Closed connection to Python socket server.");
        }
    }
}

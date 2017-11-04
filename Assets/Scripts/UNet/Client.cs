using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Client : MonoBehaviour
{
    [SerializeField] private NetworkSettings _settings;
    private NetworkClient _client;
    private string _guiText;

	private void Start ()
    {
        Debug.Log("Connecting to server: " + _settings.IpAddress + " on port: " + _settings.Port);
        _client = new NetworkClient();
        _client.RegisterHandler(MsgType.Connect, OnConnected);
        _client.Connect(_settings.IpAddress, _settings.Port);
	}

    private void OnConnected(NetworkMessage msg)
    {
        Debug.Log("Connected to server!");
        _guiText = "Connected to server!";
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), _guiText);
    }

}

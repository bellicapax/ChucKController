using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Sockets;

public class Server : MonoBehaviour {

    [SerializeField] private NetworkSettings _settings;

	// Use this for initialization
	void Start ()
    {
        var success = NetworkServer.Listen(_settings.IpAddress, _settings.Port);
        Debug.Log(success ? "Listening..." : "Failed to listen. I'm a bad boy.");
        Debug.Log(Network.player.ipAddress);
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Active? " + NetworkServer.active + " Port: " + NetworkServer.listenPort + " Connections: " + NetworkServer.connections.Count);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "NetworkSettings", menuName = "ScriptableObject/Network Settings")]
public class NetworkSettings : ScriptableObject
{
    [SerializeField] private string _ipAddress;
    public string IpAddress { get { return _ipAddress; } }
    [SerializeField] private int _port;
    public int Port { get { return _port; } }
}

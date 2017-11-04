using UnityEngine;

[CreateAssetMenu(fileName = "UdpSettings", menuName = "ScriptableObject/UDP Settings")]
public class UdpSettings : ScriptableObject
{
    [SerializeField] private int _port;
    public int Port { get { return _port; } }
}

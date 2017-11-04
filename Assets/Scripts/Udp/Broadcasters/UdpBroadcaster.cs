using System.Collections;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public abstract class UdpBroadcaster : MonoBehaviour {

    [SerializeField] private UdpSettings _settings;
    private UdpClient _sender;

    void Start()
    {
        _sender = new UdpClient(AddressFamily.InterNetwork);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Broadcast, _settings.Port);
        _sender.Connect(groupEP);
        StartCoroutine(SendDataOverTime());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator SendDataOverTime()
    {
        while (true)
        {
            SendData();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SendData()
    {

        Debug.Log("Trying to send data");
        var msg = _message;
        if (msg != null)
        {

            Debug.Log("Sending message of length " + msg.Length);
            _sender.Send(msg, msg.Length);
        }
    }

    protected abstract byte[] _message { get; }
}

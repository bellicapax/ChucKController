using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public abstract class UdpReceiver : MonoBehaviour
{

    [SerializeField] private UdpSettings _settings;
    private UdpClient _receiver;

    private void Awake()
    {
        StartReceivingIP();
    }

    public void StartReceivingIP()
    {
        try
        {
            if (_receiver == null)
            {
                _receiver = new UdpClient(_settings.Port);
                _receiver.BeginReceive(new AsyncCallback(ReceiveData), null);
            }
        }
        catch (SocketException e)
        {
            Debug.Log(e.Message);
        }
    }

    private void ReceiveData(IAsyncResult result)
    {
        var receiveIPGroup = new IPEndPoint(IPAddress.Any, _settings.Port);
        byte[] received;
        if (_receiver != null)
        {
            received = _receiver.EndReceive(result, ref receiveIPGroup);
        }
        else
        {
            return;
        }

        Debug.Log("Got bytes of length " + received.Length);
        HandleBytesReceived(received);
        _receiver.BeginReceive(new AsyncCallback(ReceiveData), null);
    }

    protected abstract void HandleBytesReceived(byte[] received);
}

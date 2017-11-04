using System;
using UnityEngine;

public abstract class AccelerationReceiver : UdpReceiver
{
    protected override void HandleBytesReceived(byte[] received)
    {
        bool isLittleEndian = BitConverter.ToBoolean(received, 0);
        Vector3 vect = Vector3.zero;
        vect.x = BitConverter.ToSingle(received, 1 + 0 * sizeof(float));
        vect.y = BitConverter.ToSingle(received, 1 + 1 * sizeof(float));
        vect.z = BitConverter.ToSingle(received, 1 + 2 * sizeof(float));
        HandleAcceleration(vect);
    }

    protected abstract void HandleAcceleration(Vector3 accel);
}

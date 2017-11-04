using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationBroadcaster : UdpBroadcaster
{
    private void OnEnable()
    {
        Input.gyro.enabled = true;
    }

    private void OnDisable()
    {
        Input.gyro.enabled = false;
    }

    protected override byte[] _message
    {
        get
        {
            byte[] buff = new byte[sizeof(float) * 3 + 1];
            var vect = Input.gyro.userAcceleration;
            Debug.Log("Getting x: " + vect.x + " y: " + vect.y + " z " + vect.z);
            buff[0] = Convert.ToByte(BitConverter.IsLittleEndian);
            Buffer.BlockCopy(BitConverter.GetBytes(vect.x), 0, buff, 1 + 0 * sizeof(float), sizeof(float));
            Buffer.BlockCopy(BitConverter.GetBytes(vect.y), 0, buff, 1 + 1 * sizeof(float), sizeof(float));
            Buffer.BlockCopy(BitConverter.GetBytes(vect.z), 0, buff, 1 + 2 * sizeof(float), sizeof(float));
            return buff;
        }
    }

    
}

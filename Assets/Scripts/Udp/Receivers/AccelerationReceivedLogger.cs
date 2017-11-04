using UnityEngine;

public class AccelerationReceivedLogger : AccelerationReceiver
{
    protected override void HandleAcceleration(Vector3 accel)
    {
        Debug.Log("x: " + accel.x + " y: " + accel.y + " z " + accel.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedView : AView
{
    public float yaw;
    public float pitch;
    public float roll;
    public float fov;

    public override CameraConfiguration GetConfiguration()
    {
        CameraConfiguration config = new CameraConfiguration();
        config.yaw = yaw;
        config.pitch = pitch;
        config.roll = roll;
        config.fov = fov;
        config.pivot = transform.position;
        config.distance = 0;

        return config;
    }


}

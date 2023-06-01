using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedView : AView
{
    [Range(0f, 360f)]
    public float yaw;
    [Range(-90f, 90f)]
    public float pitch;
    [Range(-180f, 180f)]
    public float roll;
    [Range(0f, 180f)]
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

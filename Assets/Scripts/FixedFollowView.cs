using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FixedFollowView : AView
{
    [Range(-180f, 180f)]
    public float roll;
    [Range(0f, 180f)]
    public float fov;
    [Range(0f, 180f)]
    public float yawOffsetMax;
    [Range(0f, 90f)]
    public float pitchOffsetMax;

    public GameObject target;
    private Vector3 dir = Vector3.zero;

    public GameObject centralPoint;


    public override CameraConfiguration GetConfiguration()
    {
        CameraConfiguration config = new CameraConfiguration();
        dir = transform.position - target.transform.position;
        config.yaw = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        if (config.yaw > yawOffsetMax || config.yaw < -yawOffsetMax)
            config.yaw = yawOffsetMax;
        config.pitch = -Mathf.Asin(dir.y) * Mathf.Rad2Deg;
        if (config.pitch > pitchOffsetMax || config.pitch < -pitchOffsetMax)
            config.pitch = pitchOffsetMax;
        config.roll = roll;
        config.fov = fov;
        config.pivot = transform.position;
        config.distance = 0;

        return config;
    }

}

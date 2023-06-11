using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyView : AView
{
    [Range(0f, float.PositiveInfinity)]
    public float distance;
    [Range(-180f, 180f)]
    public float roll;
    [Range(0f, 180f)]
    public float fov;

    public GameObject target;

    public Rail rail;
    public float distanceOnRail;
    public float speed;

    public override CameraConfiguration GetConfiguration()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        float yaw = lookRotation.eulerAngles.y;
        float pitch = lookRotation.eulerAngles.x;

        float horizontalInput = Input.GetAxis("Horizontal");
        distanceOnRail += horizontalInput * speed * Time.deltaTime;

        Vector3 railPosition = rail.GetPosition(distanceOnRail);


        CameraConfiguration config = new CameraConfiguration();
        config.yaw = yaw;
        config.pitch = pitch;
        config.roll = roll;
        config.pivot = railPosition;
        config.distance = distance;
        config.fov = fov;
        return config;
    }
}

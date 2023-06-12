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

    public bool isAuto;

    public override CameraConfiguration GetConfiguration()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        float yaw = lookRotation.eulerAngles.y;
        float pitch = lookRotation.eulerAngles.x;

        if (isAuto)
        {
            Vector3 projectedPosition = GetProjectedPositionOnRail(target.transform.position);
            distanceOnRail = GetDistanceOnRail(projectedPosition);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            distanceOnRail += horizontalInput * speed * Time.deltaTime;
        }

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

    private Vector3 GetProjectedPositionOnRail(Vector3 target)
    {
        Vector3 projectedPosition = Vector3.zero;
        float minDistance = float.MaxValue;

        for (int i = 0; i < rail.node.Count-1; i++)
        {
            Vector3 segmentStart = rail.node[i].transform.position;
            Vector3 segmentEnd = rail.node[i + 1].transform.position;

            Vector3 projectedPoint = MathUtils.GetNearestPointOnSegment(segmentStart, segmentEnd, target);
            float distanceToTarget = Vector3.Distance(projectedPoint, target);

            if (distanceToTarget < minDistance)
            {
                minDistance = distanceToTarget;
                projectedPosition = projectedPoint;
            }
        }

        return projectedPosition;
    }

    private float GetDistanceOnRail(Vector3 position)
    {
        float minDistance = float.MaxValue;
        float distance = 0f;

        for (int i = 0; i < rail.node.Count - 1; i++)
        {
            Vector3 segmentStart = rail.node[i].transform.position;
            Vector3 segmentEnd = rail.node[i + 1].transform.position;

            Vector3 nearestPoint = MathUtils.GetNearestPointOnSegment(segmentStart, segmentEnd, position);
            float distanceToPoint = Vector3.Distance(position, nearestPoint);

            if (distanceToPoint < minDistance)
            {
                minDistance = distanceToPoint;
                distance += Vector3.Distance(segmentStart, nearestPoint);
            }
        }

        return distance;
    }
}

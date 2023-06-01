using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CameraConfiguration
{
    public  float yaw;
    public  float pitch;
    public  float roll;
    public  Vector3 pivot;
    public  float distance;
    public  float fov;

    public Quaternion GetRotation() { return Quaternion.Euler(yaw, pitch, roll); }
    public Vector3 GetPosition() { return pivot + GetRotation() * (Vector3.back * distance); }

    public void DrawGizmos(Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(pivot, 0.25f);
        Gizmos.DrawLine(pivot, GetPosition());
        Gizmos.matrix = Matrix4x4.TRS(GetPosition(), GetRotation(), Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, fov, 0.5f, 0f, Camera.main.aspect);
        Gizmos.matrix = Matrix4x4.identity;
    }
}
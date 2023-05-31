using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraConfiguration
{
    public static float yaw;
    public static float pitch;
    public static float roll;
    public static Vector3 pivot;
    public static float distance;
    public static float fov;

    public static Quaternion GetRotation = Quaternion.Euler(yaw, pitch, roll);
    public static Vector3 GetPosition = pivot + GetRotation * (Vector3.back * distance);

    public void DrawGizmos(Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(pivot, 0.25f);
        Gizmos.DrawLine(pivot, GetPosition);
        Gizmos.matrix = Matrix4x4.TRS(GetPosition, GetRotation, Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, fov, 0.5f, 0f, Camera.main.aspect);
        Gizmos.matrix = Matrix4x4.identity;
    }
}
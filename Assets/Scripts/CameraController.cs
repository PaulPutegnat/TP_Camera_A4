using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController instance;

    private List<AView> activeViews;

    public static CameraController Instance
    {
        get
        {
            if (instance == null) instance = new CameraController();
            return instance;
        }
    }

    public new Camera camera;

    public float ComputeAverageYaw()
    {
        Vector2 sum = Vector2.zero;
        foreach (AView view in activeViews)
        {
            CameraConfiguration config = view.GetConfiguration();
            sum += new Vector2(Mathf.Cos(config.yaw * Mathf.Deg2Rad),
            Mathf.Sin(config.yaw * Mathf.Deg2Rad)) * view.weight;
        }
        return Vector2.SignedAngle(Vector2.right, sum);
    }

    public void ApplyConfiguration(Camera camera, CameraConfiguration configuration) { }

    public void AddView(AView view) { }
    public void RemoveView(AView view) { }
}

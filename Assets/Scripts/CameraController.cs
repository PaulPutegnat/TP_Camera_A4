using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController instance;

    [Range(0f, 1f)]
    public float interpolation = 0;

    private List<AView> activeViews = new List<AView>();

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

    public void ApplyConfiguration(Camera camera, CameraConfiguration configuration) 
    {
        camera.transform.position = configuration.GetPosition();
        camera.transform.rotation = configuration.GetRotation();
        camera.fieldOfView = configuration.fov;
    }

    public void AddView(AView view) 
    {
        activeViews.Add(view);
    }
    public void RemoveView(AView view) 
    {
        activeViews.Remove(view);
    }

    private void Update()
    {
        ApplyConfiguration(camera, );
    }
}

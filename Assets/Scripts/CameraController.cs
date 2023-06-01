using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    static CameraController instance;

    public List<AView> activeViews;

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

    public float ComputeAverageRoll()
    {
        float angle = 0;
        float totalWeight = 0;
        foreach (AView view in activeViews)
        {
            CameraConfiguration config = view.GetConfiguration();
            angle += config.roll * view.weight;
            totalWeight++;
        }
        return angle/totalWeight;
    }

    public float ComputeAveragePitch()
    {
        float angle = 0;
        float totalWeight = 0;
        foreach (AView view in activeViews)
        {
            CameraConfiguration config = view.GetConfiguration();
            angle += config.pitch * view.weight;
            totalWeight++;
        }
        return angle/totalWeight;
    }

    public Vector3 ComputeAveragePivot()
    {
        Vector3 position = Vector3.zero;
        float totalWeight = 0;
        foreach (AView view in activeViews)
        {
            CameraConfiguration config = view.GetConfiguration();
            position += config.pivot * view.weight;
            totalWeight += view.weight;
        }
        return position/totalWeight;
    }


    public void ApplyConfiguration(Camera camera/*, CameraConfiguration configuration*/) 
    {
        camera.transform.rotation = Quaternion.Euler(ComputeAveragePitch(), ComputeAverageYaw(), ComputeAverageRoll());
        camera.transform.position = ComputeAveragePivot();
    }

    public void AddView(AView view) 
    {
    }
    public void RemoveView(AView view) { }

    public void Update()
    {
        ApplyConfiguration(camera);
    }
}

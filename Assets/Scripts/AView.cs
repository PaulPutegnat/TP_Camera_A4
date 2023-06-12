using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AView : MonoBehaviour
{
    public float weight;
    //public bool isActiveOnStart;

    public abstract CameraConfiguration GetConfiguration();

    public void SetActive(bool isActive) 
    {
        if (isActive)
        {
            CameraController.Instance.AddView(this);
        }
        else 
        {
            CameraController.Instance.RemoveView(this);
        }
    }

    /*private void Start()
    {
        if (isActiveOnStart)
        {
            SetActive(true);
        }
        else
        {
            isActiveOnStart = false;
        }
    }*/
}

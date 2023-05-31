using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AView : MonoBehaviour
{
    public float weight;
    public bool isActiveOnStart;

    public virtual CameraConfiguration GetConfiguration() 
    {
        return null;
    }

    public void SetActive(bool isActive) { }

    private void Start()
    {
        if (isActiveOnStart)
        {
            SetActive(true);
        }
    }
}

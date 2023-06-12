using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AViewVolume : MonoBehaviour
{
    public int priority = 0;
    public Vector3 view;

    private int uid;

    private static int nextUid = 0;

    protected bool isActive { get; private set; }

    protected virtual void SetActive(bool active)
    {
        if (active && !isActive)
        {
            
        }
        else if (!active && isActive)
        {
            
        }

        isActive = active;
    }

    public void Awake()
    {
        uid = nextUid;
        nextUid++;
    }

    public virtual float ComputeSelfWeight()
    {
        return 1.0f;
    }
}

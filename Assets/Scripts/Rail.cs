using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Rail : MonoBehaviour
{
    public bool isLoop;

    public List<GameObject> node;

    private GameObject lastNode;
    private float length;

    public float GetLength()
    {
        foreach (var node in node)
        {
            //length += node.transform.position - lastNode.transform.position;
        }
        return length;
    }

    void OnDrawGizmosSelected()
    {
        if (node != null)
        {
            Gizmos.color = Color.red;
            foreach (var node in node)
            {
                if (lastNode != null)
                    Gizmos.DrawLine(lastNode.transform.position, node.transform.position);
                else
                    Gizmos.DrawLine(transform.position, node.transform.position);
                lastNode = node;
            }
        }
    }
}

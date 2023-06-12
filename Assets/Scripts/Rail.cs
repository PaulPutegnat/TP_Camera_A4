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

    

    private void Start()
    {
        length = GetLength();
    }

    public float GetLength()
    {
        lastNode = node[0];
        foreach (var node in node)
        {
            if (node != null)
                length += Vector3.Distance(lastNode.transform.position, node.transform.position); ;
            lastNode = node;
        }

        if (isLoop && node.Count > 1)
        {
            length += Vector3.Distance(lastNode.transform.position, node[0].transform.position);
        }

        return length;
    }

    public Vector3 GetPosition(float distance)
    {
        if (isLoop && node.Count > 1)
        {
            float currentDistance = 0f;
            lastNode = null;

            foreach (var node in node)
            {
                if (lastNode != null)
                {
                    float partLength = Vector3.Distance(lastNode.transform.position, node.transform.position);
                    if (distance >= currentDistance && distance < currentDistance + partLength)
                    {
                        length = (distance - currentDistance) / partLength;
                        return Vector3.Lerp(lastNode.transform.position, node.transform.position, length);
                    }
                    currentDistance += partLength;
                }
                lastNode = node;
            }
        }
        else if (node.Count > 0)
        {
            float currentDistance = 0f;
            lastNode = null;

            foreach (var node in node)
            {
                if (lastNode != null)
                {
                    float partLength = Vector3.Distance(lastNode.transform.position, node.transform.position);
                    if (distance >= currentDistance && distance < currentDistance + partLength)
                    {
                        length = (distance - currentDistance) / partLength;
                        return Vector3.Lerp(lastNode.transform.position, node.transform.position, length);
                    }
                    currentDistance += partLength;
                }
                lastNode = node;
            }
        }
        return Vector3.zero;
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

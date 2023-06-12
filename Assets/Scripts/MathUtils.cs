using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils
{
    public static Vector3 GetNearestPointOnSegment(Vector3 a, Vector3 b, Vector3 target)
    {
        Vector3 ab = b - a;
        Vector3 ac = target - a;

        float scalaire = Vector3.Dot(ac, ab) / Vector3.Dot(ab, ab);
        scalaire = Mathf.Clamp01(scalaire);

        Vector3 projC = a + scalaire * ab;

        return projC;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{



    public static Vector3 Randomize(this Vector3 vect, Vector3 VectorIntensity)
    {
        Vector3 vector;
        vector.x = Random.Range(0, VectorIntensity.x);
        vector.y = Random.Range(0, VectorIntensity.y);
        vector.z = Random.Range(0, VectorIntensity.z);
        return vect + vector;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAlphaDecreaser : MonoBehaviour
{


    private void OnTriggerEnter(Collider col)
    {
        Material mat = col.GetComponent<MeshRenderer>().material;
        col.GetComponent<MeshRenderer>().material.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.66f);
    }
    private void OnTriggerExit(Collider col)
    {
        Material mat = col.GetComponent<MeshRenderer>().material;
        col.GetComponent<MeshRenderer>().material.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1);
    }
}

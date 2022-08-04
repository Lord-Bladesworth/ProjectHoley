using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingObject : MonoBehaviour
{
    bool IsDropped;
    float DefaultElevation;
    int DefaultLayer;

    public bool isDropped { private set { IsDropped = value; } get { return IsDropped; } }
    // Start is called before the first frame update
    void Start()
    {
        DefaultLayer = gameObject.layer;
        DefaultElevation = transform.position.y;
    }
    void Fall()
    {
        gameObject.layer = 8;

    }
    void Interrupt()
    {
        gameObject.layer = DefaultLayer;
        transform.position = new Vector3(transform.position.x, DefaultElevation, transform.position.z);
    }
}

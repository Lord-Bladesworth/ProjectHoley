using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for both the Disk and Hole scripts
/// </summary>
[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public abstract class HoleCollider : MonoBehaviour
{
    Rigidbody body;
    Collider holeCol;
    protected virtual void CustomStart()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeAll;
        holeCol = GetComponent<Collider>();
        holeCol.isTrigger = true;
        GetComponent<MeshRenderer>().receiveShadows = false;
        CustomStart();
    }

    public virtual void CustomLogic()
    {

    }
    // Update is called once per frame
    void Update()
    {
        CustomLogic();
    }

    protected abstract void BoxCollisionEnter(BoxClass box);
    protected abstract void BoxCollisionExit(BoxClass box);
    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<BoxClass>())
        {
            BoxCollisionEnter(col.GetComponent<BoxClass>());
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.GetComponent<BoxClass>())
        {
            BoxCollisionExit(col.GetComponent<BoxClass>());
        }
    }
}

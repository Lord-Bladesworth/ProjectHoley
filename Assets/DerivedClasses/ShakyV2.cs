using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyV2 :BoxClass
{
    bool isShaking;
    Vector3 DefaultPosition;
    public override void InitializeBox()
    {
        isShaking = false;
        DefaultPosition = transform.position;
    }

    private void LateUpdate()
    {
        if(isShaking)
        {
            transform.position = DefaultPosition.Randomize(new Vector3(0.25f, 0, 0.25f));
        }
    }
    public override void OnHoleEntry()
    {
        body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        body.velocity = new Vector3(0, -20, 0);
        gameObject.layer = 6;
        ObjectDisable();
    }
    public override void OnDiskEntry(bool IsEntry)
    {
        isShaking = IsEntry;
    }

}

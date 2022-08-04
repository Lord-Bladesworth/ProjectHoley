using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiVisualBox :BoxClass
{

    float RestScaleY;
    float InitialScale;
    [SerializeField]
    float MaxScaleY;
    [Range(1, 31)]
    public int SpecIndex;
    float DampenedFactor = .66f;
    bool isDampened;
    bool IsPlaying;
    public override void InitializeBox()
    {
        isDampened = false;
        IsPlaying = true;
        InitialScale = transform.localScale.y;
        RestScaleY = transform.localScale.y;
    }

    public override void OnDiskEntry(bool IsEntry)
    {
        if (IsEntry)
        {
            RestScaleY = RestScaleY * DampenedFactor;
        }
        else
        {
            RestScaleY = InitialScale;
        }
    }
    protected override void OnUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x, RestScaleY + (MaxScaleY * SpectrumEngine.SpectrumArray[SpecIndex]), transform.localScale.z);
    }

    public override void ResetGameObject()
    {
        base.ResetGameObject();
        body.constraints= RigidbodyConstraints.FreezeAll;
        body.velocity = Vector3.zero;
    }
    public override void OnHoleEntry()
    {
        IsPlaying = false;
        body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        body.velocity = new Vector3(0, -20, 0);
        gameObject.layer = 6;
        ObjectDisable();

    }

}

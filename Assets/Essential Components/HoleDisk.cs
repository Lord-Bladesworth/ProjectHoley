using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoleDisk : HoleCollider
{

    protected override void BoxCollisionEnter(BoxClass box)
    {
        box.OnDiskEntry(true);
    }
    protected override void BoxCollisionExit(BoxClass box)
    {
        box.OnDiskEntry(false);
    }

}

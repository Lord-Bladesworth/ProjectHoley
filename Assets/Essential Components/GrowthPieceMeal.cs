using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sample script for the growth class
public class GrowthPieceMeal : HoleGrowth
{
    Transform Hole;
    Transform Disk;

    public override void GrowerInitialize()
    { 
        Hole = GetComponentInChildren<HoleDisk>().transform;
        Disk = GetComponentInChildren<HoleCentral>().transform;
       
    }
    public override void OnGrow()
    { 
        //transform.localScale += new Vector3(0.25f, 0, 0.25f);
        Hole.localScale += new Vector3(.22f, 0, .30f);
        Disk.localScale += new Vector3(0.25f, 0, 0.25f);
    }
}

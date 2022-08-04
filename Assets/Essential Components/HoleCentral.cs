using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HoleCentral :HoleCollider 
{
    Action<BoxClass> OnHoleEntry;
 
    public void AddEntryEvent(Action<BoxClass> act)
    {
        OnHoleEntry += act;
    }
    protected override void BoxCollisionEnter(BoxClass box)
    {
        if(OnHoleEntry != null)
        {
            OnHoleEntry(box);
        }
    }
    protected override void BoxCollisionExit(BoxClass box)
    {
       
    }
}

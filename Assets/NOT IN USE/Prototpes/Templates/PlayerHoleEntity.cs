using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace prototypes { 
//the player hole itself
public class PlayerHoleEntity : MonoBehaviour
{
    BlackHole hole;
    EventHorizon horizon;
    int playerLevel;
    public int getLevel { get { return playerLevel; } }
    //TODO: customizability of the EventHorizon and the Hole Radius rather than having to tinker with it on the heiharchy
    // Start is called before the first frame update
    void Start()
    {
        hole = GetComponentInChildren<BlackHole>();
        hole.touchedActionSubscribe += EvaluateTouched;
        horizon = GetComponentInChildren<EventHorizon>();
    }

    public void SubscribeTouchEvent(Action<BoxTouchClass> act)
    {
        hole.touchedActionSubscribe += act;
    }
    public void EvaluateTouched(BoxTouchClass touched)
    {
        if(touched.IsEntity)
        {
            if(touched.GetLevel - playerLevel <=0)
            {
                touched.HoleTouchedAction();
            }
        }
    }

}
}

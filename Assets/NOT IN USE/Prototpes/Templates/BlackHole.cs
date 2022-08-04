using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace prototypes { 
//the small hole in the middle where the falling starts
public class BlackHole : MonoBehaviour
{
    //Delegates in which objects are subscribed to when the hole touches a BoxTouchClass
    Action<BoxTouchClass> _holeTouchedAction;

    public Action<BoxTouchClass> touchedActionSubscribe { get { return _holeTouchedAction; } set { _holeTouchedAction = value; } }
    //delegate for level evaluation, set in a way that only the main player component sets up the function, this eliminating dependency if this script is only deployed
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void BoxTouchEvent(BoxTouchClass touched)
    {
        _holeTouchedAction.Invoke(touched);
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<BoxTouchClass>())
        {
            BoxTouchClass touched = col.GetComponent<BoxTouchClass>();
            BoxTouchEvent(touched);
        }
    }

}
}

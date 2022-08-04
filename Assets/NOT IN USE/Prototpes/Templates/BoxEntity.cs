using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace prototypes { 
//box entity itself
[RequireComponent(typeof(BoxTouchClass))]
public class BoxEntity : MonoBehaviour
{
    int entityLevel;
    BoxTouchClass touchClass;
    public int Level { get { return entityLevel; } }
    private void Awake()
    {
        if(!GetComponent<BoxTouchClass>())
        {
            gameObject.AddComponent<BoxTouchClass>();
        }
        touchClass = GetComponent<BoxTouchClass>();
    }
    void Kill()
    {

    }
    void setInactive()
    {

    }
    

}
}
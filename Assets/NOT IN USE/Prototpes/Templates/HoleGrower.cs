using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototypes { 
public class HoleGrower : MonoBehaviour, IPlayerHoleGrower
{
    protected PlayerHoleEntity Ent;
    // Start is called before the first frame update
    private void Start()
    {
        Ent = GetComponent<PlayerHoleEntity>();
        Ent.SubscribeTouchEvent(OnTouchEvent);
        GrowerInitialize();
    }
    public void GrowerInitialize()
    {

    }

    public void OnGrow()
    {
       
    }
    void OnTouchEvent(BoxTouchClass box)
    {
        if ((box.GetLevel- Ent.getLevel) <= 0)
            OnGrow();

    }
}
}
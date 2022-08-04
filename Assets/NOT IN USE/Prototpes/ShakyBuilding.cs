using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace prototypes
{
    public class ShakyBuilding : BoxTouchClass
    {
        Vector3 defaultposition;
        public override void TouchClassInitialize()
        {
            defaultposition = transform.position;
        }
        public override void HorizonTouchedAction()
        {
            // transform.position = defaultposition.Randomize(new Vector3(0.50f,0,0.50f));
        }
        public override void HoleTouchedAction()
        {
            getBody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        public override void TouchExitEvent()
        {

        }
        public override void LateUpdate()
        {
            base.LateUpdate();
            if (transform.position.y < -22)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

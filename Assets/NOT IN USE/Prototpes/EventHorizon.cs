using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace prototypes
{
    public class EventHorizon : MonoBehaviour
    {
        Vector3 HorizionRadius { get { return transform.localScale; } set { transform.localScale = value; } }
        Action act;
        // Start is called before the first frame update
        void Start()
        {

        }

        public virtual void BoxTouchEnter(BoxTouchClass box)
        {
            box.HorizonTouch(true);
        }
        public virtual void BoxTouchExit(BoxTouchClass box)
        {
            Debug.Log("Confirming Exit");
            box.HorizonTouch(false);
            box.TouchExitEvent();
        }
        private void OnTriggerEnter(Collider collision)
        {

            if (collision.gameObject.GetComponent<BoxTouchClass>())
            {
                BoxTouchClass affectedBox = collision.gameObject.GetComponent<BoxTouchClass>();
                BoxTouchEnter(affectedBox);
            }


        }
        private void OnTriggerStay(Collider collision)
        {

        }
        private void OnTriggerExit(Collider collision)
        {

            if (collision.gameObject.GetComponent<BoxTouchClass>())
            {
                BoxTouchClass affectedBox = collision.gameObject.GetComponent<BoxTouchClass>();
                BoxTouchExit(affectedBox);
            }
        }
    }

}
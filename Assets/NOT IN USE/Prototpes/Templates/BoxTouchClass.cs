using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototypes
{
    //class that handles touch events by the EventHorizon and the BlackHole object
    public class BoxTouchClass : MonoBehaviour
    {
        BoxEntity Entity;
        bool HorizonTouched;
        bool HoleTouched;
        Rigidbody body;
        protected Rigidbody getBody { get { return body; } set { body = value; } }
        public bool IsEntity { get { return !(Entity == null); } }
        public int GetLevel { get { return Entity.Level; } }

        public virtual void TouchClassInitialize()
        {

        }
        private void Awake()
        {
            if (!gameObject.GetComponent<Rigidbody>())
            {
                gameObject.AddComponent<Rigidbody>();
            }
            body = gameObject.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotation;

        }

        void Start()
        {
            HorizonTouched = false;
            HoleTouched = false;
            if (GetComponent<BoxTouchClass>())
                Entity = GetComponent<BoxEntity>();
            TouchClassInitialize();
        }

        public virtual void HorizonTouchedAction()
        {

        }
        public virtual void HoleTouchedAction()
        {

        }
        public virtual void LateUpdate()
        {
            if (HorizonTouched)
            {
                HorizonTouchedAction();
            }
            if (HoleTouched)
            {
                HoleTouchedAction();
            }
        }
        public void HoleTouch(bool isTouched)
        {
            HoleTouched = isTouched;
        }
        public void HorizonTouch(bool isTouched)
        {
            HorizonTouched = isTouched;
        }
        //event that will be called if the player stops touching it
        public virtual void TouchExitEvent()
        {

        }
    }

    class FoodData
    {
        public int FoodLevel;

    }
}
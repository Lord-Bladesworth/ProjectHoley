using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//camera that will follow the player hole and will dynamically adjust according to the Disk's Size
[ExecuteAlways]
public class CameraHoist : MonoBehaviour
{
    
    Transform tgtObject;
    [SerializeField]
    int FieldOfViewIncrement;

    // Start is called before the first frame update
    void Start()
    {
        tgtObject = GameObject.FindObjectOfType<PlayerClass>().transform;
       if(tgtObject.gameObject.GetComponent<PlayerClass>())
        {
            tgtObject.gameObject.GetComponent<PlayerClass>().SubscribetoGrowth(ExpandFOV);
        }
        GameManager.SaveInitialFOV(Camera.main.fieldOfView);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tgtObject)
        transform.position = tgtObject.position;
    }

    void ExpandFOV()
    {
        Camera.main.fieldOfView += FieldOfViewIncrement;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerClass))]
public class DiskMovement : MonoBehaviour
{
    CharacterController Controller;
    Rigidbody body;
    [SerializeField]
    bool OnDebug;
    ScreenTracker tracker = new ScreenTracker(new Vector2(Screen.width, Screen.height));
    /// <summary>
    /// Player's Movement speed. value will be overwritten by the playerobject
    /// </summary>
    [SerializeField]
    int speed;

    public int SetSpeed { set { speed = value; } }
    public void LinkSpeed(ref int link)
    {
        speed = link;

    }
    string MouseCoord = "";
    private void Awake()
    {
        if(!gameObject.GetComponent<CharacterController>())
        {
            gameObject.AddComponent<CharacterController>();
        }
        if (!gameObject.GetComponent<Rigidbody>())
        {
            gameObject.AddComponent<Rigidbody>();
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        Controller = gameObject.GetComponent<CharacterController>();
        body = gameObject.GetComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
       // Controller.attachedRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.GameState == GameStateEnum.Running)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 testvect = Input.mousePosition;
                DiskMove(tracker.ConvertAngletoVector(tracker.CalculateRelativeTarget(testvect), tracker.CalculateAngle(tracker.CalculateRelativeTarget(testvect))));
                MouseCoord = tracker.CalculateAngle(tracker.CalculateRelativeTarget(testvect)).ToString() + " \n " + tracker.CalculateRelativeTarget(testvect) + " units away from center" + "\n" + "Vector Directions at: " + tracker.ConvertAngletoVector(tracker.CalculateRelativeTarget(testvect), tracker.CalculateAngle(tracker.CalculateRelativeTarget(testvect)));
            }
            if (Input.GetMouseButtonUp(0))
            {
                body.velocity = Vector3.zero;
            }
        }
        else
            body.velocity = Vector3.zero;

    }


    void DiskMove(Vector2 MoveDirection)
    {

        //Controller.SimpleMove(new Vector3(MoveDirection.x * speed,0,MoveDirection.y * speed));
        body.velocity= new Vector3(MoveDirection.x * speed,0, MoveDirection.y * speed);
    }

    void DiskMove(float Angle)
    {

    }

    private void OnGUI()
    {
        if(OnDebug)
        GUI.Label(new Rect(50, 50, 400, 200), MouseCoord);
    }
}

class ScreenTracker
{
    Vector2 CenterPoint = new Vector2();
    public Vector2 getCenterpoint { get { return CenterPoint; } }
    public ScreenTracker(Vector2 screenSize, int OffsetX = 0, int OffsetY = 0)
    {
        CenterPoint.x = screenSize.x / 2 + OffsetX ;
        CenterPoint.y = screenSize.y / 2 + OffsetY ;
    }
    //calculates the distance from the target centerpoint
    public Vector2 CalculateRelativeTarget(Vector2 targetPoint)
    {
        Vector2 point = new Vector2(targetPoint.x - CenterPoint.x, targetPoint.y - CenterPoint.y);
        return point;
    }
    public float CalculateAngle(Vector2 targetRelativePosition)
    {
        return Mathf.Atan2(targetRelativePosition.y, targetRelativePosition.x) * Mathf.Rad2Deg;
    }
    public Vector2 ConvertAngletoVector(Vector2 RelativePosition,float Angle)
    {
        Vector2 Direction;
        float Hypotenuse = Mathf.NextPowerOfTwo(Mathf.NextPowerOfTwo((int)RelativePosition.x) + Mathf.NextPowerOfTwo((int)RelativePosition.y));
        Direction.x = Mathf.Cos(Angle * Mathf.PI / 180);
        Direction.y = Mathf.Sin(Angle * Mathf.PI / 180);
        return Direction;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[ExecuteInEditMode]
[RequireComponent(typeof(DiskMovement))]
public class PlayerClass : MonoBehaviour
{
    private const float HOLETHICKNESS = 0.15f;

    public PlayerData data;
    HoleCentral hole;
    HoleDisk disk;

    public int GetLevel { get { return data.Level; } }
    public float GetHoleRadius { get { return data.HoleRadius; } }
    public float GetDiskRadius { get { return data.DiskRadius; } }
    Action GrowthDelegate; //mainly to be used for the hoist class
    Action HoleEntrySuccess; //if touched box is eaten
    Action HoleEntryFail;   // if touched box is not eaten
    private void Awake()
    {
        
        
    }
    void Start()
    {
        hole = gameObject.GetComponentInChildren<HoleCentral>();
        disk = gameObject.GetComponentInChildren<HoleDisk>();
        hole.AddEntryEvent(EvaluateEntry);
        if(GetComponent<DiskMovement>())
        {
            GetComponent<DiskMovement>().LinkSpeed(ref data.Speed);
        }
        GameManager.SubscribePlayer(this.gameObject, transform.position, data);

    }

    // Update is called once per frame
    void Update()
    {

        if(!Application.isPlaying)
        UpdateEditedValues();

    }

    //for editor only, applies all the changes to the related hole and disk children
    void UpdateEditedValues()
    {
#if UNITY_EDITOR
        if (GetComponent<DiskMovement>())
        {
            // GetComponent<DiskMovement>().SetSpeed =  data.Speed;
            GetComponent<DiskMovement>().SetSpeed = data.Speed;
        }

        if (GetComponentInChildren<HoleCentral>())
        {
            GetComponentInChildren<HoleCentral>().transform.localScale = new Vector3(data.HoleRadius,HOLETHICKNESS, data.HoleRadius);
        }
        if (GetComponentInChildren<HoleDisk>())
        {
            GetComponentInChildren<HoleDisk>().transform.localScale = new Vector3(data.DiskRadius + data.HoleRadius, HOLETHICKNESS, data.DiskRadius+data.HoleRadius);
        }
        if (GetComponentInChildren<HoleCentral>() && GetComponentInChildren<HoleDisk>())
        {
            GetComponentInChildren<HoleCentral>().GetComponent<MeshRenderer>().material = data.HoleMaterial;
            GetComponentInChildren<HoleDisk>().GetComponent<MeshRenderer>().material = data.HoleMaterial;
        }
#endif

    }
    public void UpdateHoleStats(float HoleRadius, float DiskRadius,int speed)
    {
        GetComponentInChildren<HoleCentral>().transform.localScale = new Vector3(HoleRadius,HOLETHICKNESS, HoleRadius);
        GetComponentInChildren<HoleDisk>().transform.localScale = new Vector3(DiskRadius + HoleRadius, HOLETHICKNESS, DiskRadius + HoleRadius);
        GetComponent<DiskMovement>().SetSpeed = data.Speed;
        if (GrowthDelegate != null)
        GrowthDelegate();

    }
    public void PlayerRestart(Vector3 startPosition,PlayerData startingData)
    {
        transform.position = startPosition;
        data.Level = startingData.Level;
        UpdateHoleStats(startingData.HoleRadius, startingData.DiskRadius, startingData.Speed);
    }
    public virtual void UpdateScore()
    {
        data.Level++;
    }
    public void SubscribetoGrowth(Action act)
    {
        GrowthDelegate += act;
    }
    public void HoleEntrySucessSubscribe(Action act)
    {
        HoleEntrySuccess+= act;
    }
    public void HoleEntryFailSubscribe(Action act)
    {
        HoleEntryFail += act;
    }
    void EvaluateEntry(BoxClass box)
    {
     if((box.GetLevel - GetLevel) <= 0)
        {
            box.OnHoleEntry();
            UpdateScore();
            if(HoleEntrySuccess != null)
            HoleEntrySuccess.Invoke();
        }
    }
}

[Serializable]
public class PlayerData
{
    public string Name;
    public int Level=1;
    public int Speed;
    public float HoleRadius, DiskRadius;
    public Material HoleMaterial;

    public PlayerData(string name = "player", int lvl = 1, int speed = 2, float holerad = 1, float diskrad = 1)
    {
        Name = name;
        Level = lvl;
        Speed = speed; 
        HoleRadius = holerad;
        DiskRadius = diskrad;
    }
}
[Serializable]
public class GrowthData
{

}
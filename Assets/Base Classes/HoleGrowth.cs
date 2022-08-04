using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HoleGrowth : MonoBehaviour, IPlayerHoleGrower
{
    protected PlayerClass player;
    protected Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerClass>();
        playerTransform = transform;
        if(player != null)
        {
            player.HoleEntrySucessSubscribe(OnGrow);
        }
        GrowerInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {

    }
    public abstract void GrowerInitialize();

    public abstract void OnGrow();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierGrowth :HoleGrowth
{
    [SerializeField]
    float GrowthFactor;

    [SerializeField]
    public GrowthTiers[] tiers;
    public override void GrowerInitialize()
    {
       
    }
    public override void OnGrow()
    {
        if (tiers != null)
        {
            for (int x = 0; x < tiers.Length; x++)
            {
                if (player.GetLevel == tiers[x].PlayerLevel)
                {
                    player.UpdateHoleStats(tiers[x].HoleRadius, tiers[x].DiskRadius, tiers[x].Speed);
                }
            }
        }
    }

}
[System.Serializable]
public class GrowthTiers
{
    public int PlayerLevel;
    public float HoleRadius;
    public float DiskRadius;
    public int Speed;
}

using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public struct FSpawnInfo
{
    public float TimeTillNextSpawn;
    public EHMinion MinionToSpawn;
}
public class EHMinionSpawner : MonoBehaviour
{
    // NOTE: These would be moved to a data table in the future.
    private List<FSpawnInfo> MinionSpawnSequenceRound1;
    private List<FSpawnInfo> MinionSpawnSequenceRound2;
    private List<FSpawnInfo> MinionSpawnSequenceRound3;

    private float RemainingTimeTillNextSpawn;
    private int Index;

    private void Awake()
    {
        
    }

    private void Update()
    {
        // if (RemainingTimeTillNextSpawn <= 0)
        // {
        //     if (!SpawnMinion())
        //     {
        //         this.enabled = false;
        //     }
        // }
        // RemainingTimeTillNextSpawn -= Time.deltaTime;
        
    }

    private bool SpawnMinion()
    {
        if (Index < 0 || Index >= MinionSpawnSequenceRound1.Count)
        {
            return false;
        }
        FSpawnInfo SpawnInfo = MinionSpawnSequenceRound1[Index++];
        RemainingTimeTillNextSpawn += SpawnInfo.TimeTillNextSpawn;
        EHMinion newMinion = Instantiate(SpawnInfo.MinionToSpawn, transform.position, transform.rotation);
        return true;
    }
}

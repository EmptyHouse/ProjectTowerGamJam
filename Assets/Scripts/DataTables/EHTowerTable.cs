using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHTowerDataEntry : EHDataTableRow
{
    [Tooltip("The cost of our tower at various levels")]
    public List<int> TowerCosts;
    [Tooltip("The return value of our tower at various levels")]
    public List<int> ReturnValue;
    [Tooltip("The Prefab reference of the tower that will be constructed at various levels")]
    public List<EHTowerUnit> TowerLevels;
}

[CreateAssetMenu(fileName = "TowerDataTable", menuName = "ScriptableObjects/TowerTable", order = 1)]
public class EHTowerTable : EHDataTable<EHTowerDataEntry>
{
    
}

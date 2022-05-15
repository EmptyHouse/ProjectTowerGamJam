using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHTowerUnit : EHActor
{
    [SerializeField]
    private float RotationSpeed = 100f;
    [SerializeField]
    private Transform RotationTransform;

    private List<EHActor> Targets = new List<EHActor>();
    private EHActor EnemyTarget;
    
    #region monobehaviour methods
    private void Update()
    {
        if (EnemyTarget != null)
        {
            UpdateRotation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EHMinion Minion = other.GetComponent<EHMinion>();
        if (Minion != null)
        {
            if (!Targets.Contains(Minion))
            {
                Targets.Add(Minion);
                EnemyTarget = Targets[0];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EHMinion Minion = other.GetComponent<EHMinion>();
        if (Minion != null)
        {
            if (Targets.Contains(Minion))
            {
                Targets.Remove(Minion);
            }

            if (Targets.Count > 0)
            {
                EnemyTarget = Targets[0];
            }
            else
            {
                EnemyTarget = null;
            }
        }
        
    }

    private void UpdateRotation()
    {
        Vector3 OffsetPosition = EnemyTarget.GetActorLocation() - GetActorLocation();
        float YRotation = Mathf.Atan2(OffsetPosition.x, OffsetPosition.z) * Mathf.Rad2Deg;
        Quaternion GoalRotation = Quaternion.Euler(-90, YRotation, 0);
        RotationTransform.localRotation = Quaternion.Slerp(RotationTransform.localRotation, GoalRotation, RotationSpeed * Time.deltaTime);
    }
    #endregion monobehaviour methods
    
}

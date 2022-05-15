using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHTowerUnit : EHActor
{
    [SerializeField]
    private EHProjectiles ProjectileToFire;
    [SerializeField]
    private float RotationSpeed = 100f;
    [SerializeField]
    private Transform RotationTransform;

    private List<EHActor> Targets = new List<EHActor>();
    [SerializeField]
    private List<Transform> LaunchPoints = new List<Transform>();
    private int LaunchIndex;
    private EHActor EnemyTarget;
    [SerializeField]
    private float DelayFire = .1f;

    private float TimeTillNextFire = 0;
    
    #region monobehaviour methods
    private void Update()
    {
        if (EnemyTarget != null)
        {
            UpdateRotation();
            if (TimeTillNextFire <= 0)
            {
                FireWeapon();
            }

            TimeTillNextFire -= Time.deltaTime;
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

    private void FireWeapon()
    {
        TimeTillNextFire += DelayFire;
        Transform LaunchTransform = LaunchPoints[LaunchIndex++];
        LaunchIndex %= LaunchPoints.Count;
        EHProjectiles Projectile = Instantiate(ProjectileToFire, LaunchTransform.position, Quaternion.identity);
        Vector3 LaunchDirection = EnemyTarget.GetActorLocation() - LaunchTransform.position;
        Projectile.LaunchProjectile(LaunchDirection);
    }
    #endregion monobehaviour methods
    
}

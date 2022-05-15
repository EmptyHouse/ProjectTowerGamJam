using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHProjectiles : EHActor
{
    private int EnemyMask;
    [SerializeField] private float ProjectileSpeed = 50f;

    protected override void Awake()
    {
        base.Awake();
        EnemyMask = LayerMask.GetMask("Enemy");
    }
    protected void Update()
    {
        UpdateProjectilePosition();
        DetectHit();
    }

    public void LaunchProjectile(Vector3 LaunchVector)
    {
        this.transform.forward = LaunchVector;
    }

    private void UpdateProjectilePosition()
    {
        SetActorLocation(GetActorLocation() + ((transform.forward * ProjectileSpeed) * Time.deltaTime));
    }

    private void DetectHit()
    {
        Ray ProjectileRay = new Ray(GetActorLocation(), transform.forward);
        
        if (Physics.Raycast(ProjectileRay, out RaycastHit RayHit, Time.deltaTime * ProjectileSpeed, EnemyMask))
        {
            EHMinion Minion = RayHit.collider.GetComponent<EHMinion>();
            if (Minion != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

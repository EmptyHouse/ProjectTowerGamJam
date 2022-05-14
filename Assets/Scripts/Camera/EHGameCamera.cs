using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHGameCamera : EHActor
{
    public Camera CameraComponent { get; private set; }
    public EHActor FollowTarget { get; private set; }
    
    [SerializeField]
    private float CameraSpeed = 100f;

    private Vector3 Offset;
    protected override void Awake()
    {
        base.Awake();
        CameraComponent = GetComponentInChildren<Camera>();
    }

    protected void Start()
    {
        SetFollowTarget(this.transform.parent.GetComponent<EHActor>());
        Offset = GetActorLocation() - FollowTarget.GetActorLocation();
        this.transform.SetParent(null);
    }

    protected void LateUpdate()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        SetActorLocation(Vector3.Lerp(GetActorLocation(), FollowTarget.GetActorLocation() + Offset, 
            CameraSpeed * Time.deltaTime));
    }

    public void SetFollowTarget(EHActor FollowTarget)
    {
        this.FollowTarget = FollowTarget;
    }
}

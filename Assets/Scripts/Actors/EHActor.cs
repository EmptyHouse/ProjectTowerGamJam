using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHActor : MonoBehaviour
{
    public Animator Anim { get; private set; }
    
    #region monobehaviour functions

    protected virtual void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    #endregion monbehaviour functions
    
    #region getter functions

    public Vector3 GetActorLocation()
    {
        return transform.position;
    }

    public Quaternion GetActorRotation()
    {
        return transform.rotation;
    }

    public Vector3 GetActorScale()
    {
        return transform.localScale;
    }
    #endregion getter functions
    
    #region setter functions

    public void SetActorLocation(Vector3 Location)
    {
        transform.position = Location;
    }

    public void SetActorRotation(Quaternion Rotation)
    {
        transform.rotation = Rotation;
    }

    public void SetActorScale(Vector3 Scale)
    {
        transform.localScale = Scale;
    }
    #endregion setter functions
    
    #region actor functionality

    public T CreateActor<T>(T ActorToSpawn, Vector3 Position, Quaternion Rotation) where T : EHActor
    {
        if (ActorToSpawn == null)
        {
            Debug.LogWarning("Attempting to create an null actor");
            return null;
        }
        return Instantiate(ActorToSpawn, Position, Rotation);
    }

    public void DestroyActor(EHActor ActorToDestroy)
    {
        Destroy(ActorToDestroy.gameObject);
    }
    #endregion actor functionality
}

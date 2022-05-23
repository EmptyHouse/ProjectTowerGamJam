using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHActorComponent : MonoBehaviour
{
    public EHActor OwningActor { get; private set; }

    #region monobehaviour functions
    protected virtual void Awake()
    {
        InitializeOwningActor();
    }
    
    #endregion monobehaviour functions

    protected virtual void InitializeOwningActor()
    {
        OwningActor = GetComponent<EHActor>();
    }
    
    #region Owning Actor Functions

    public void SetActorLocation(Vector3 Position)
    {
        OwningActor.SetActorLocation(Position);
    }

    public void SetActorRotation(Vector3 Rotation)
    {
        OwningActor.SetActorRotation(Quaternion.Euler(Rotation));
    }

    public void SetActorRotation(Quaternion Rotation)
    {
        OwningActor.SetActorRotation(Rotation);
    }

    public void SetActorScale(Vector3 Scale)
    {
        OwningActor.SetActorScale(Scale);
    }

    public Quaternion GetActorRotation() => OwningActor.GetActorRotation();

    #endregion
}
